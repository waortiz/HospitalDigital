using Entidades;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioPacienteEF : IRepositorioPaciente
    {
        private ContextoHospitalDigital contexto = new ContextoHospitalDigital();

        public void IngresarPaciente(Entidades.Paciente paciente)
        {
            var pacienteNuevo = new Modelo.Paciente()
            {
                PrimerApellido = paciente.PrimerApellido,
                Estatura = paciente.Estatura,
                FechaNacimiento = paciente.FechaNacimiento,
                IdTipoDocumento = paciente.TipoDocumento.Id,
                NumeroDocumento = paciente.NumeroDocumento,
                PrimerNombre = paciente.PrimerNombre,
                SegundoApellido = paciente.SegundoApellido,
                SegundoNombre = paciente.SegundoNombre,
                Telefono = paciente.Telefono
            };

            contexto.Pacientes.Add(pacienteNuevo);
            contexto.SaveChanges();

            paciente.Id = pacienteNuevo.Id;
        }
    }
}
