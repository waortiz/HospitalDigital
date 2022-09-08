using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioPacienteJSON : IRepositorioPaciente
    {
        public static List<Paciente> pacientes = new List<Paciente>();

        public void IngresarPaciente(Paciente paciente)
        {
            File.WriteAllText("pacientes.json", JsonConvert.SerializeObject(paciente));
        }
    }
}
