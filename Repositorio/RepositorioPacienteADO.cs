using Entidades;
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
    public class RepositorioPacienteADO : IRepositorioPaciente
    {
        public void IngresarPaciente(Paciente paciente)
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["HospitalDigitalEsperanza"].ConnectionString;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var comando = new SqlCommand();
                comando.CommandText = "IngresarPaciente";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexion;

                comando.Parameters.Add("@PrimerNombre", System.Data.SqlDbType.NVarChar, 50).Value = paciente.PrimerNombre;
                comando.Parameters.Add("@SegundoNombre", System.Data.SqlDbType.NVarChar, 50).Value = paciente.SegundoNombre;
                comando.Parameters.Add("@PrimerApellido", System.Data.SqlDbType.NVarChar, 50).Value = paciente.PrimerApellido;
                comando.Parameters.Add("@SegundoApellido", System.Data.SqlDbType.NVarChar, 50).Value = paciente.SegundoApellido;
                comando.Parameters.Add("@Estatura", System.Data.SqlDbType.Decimal, 10).Value = paciente.Estatura;
                comando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime2, 50).Value = paciente.FechaNacimiento;
                comando.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar, 50).Value = paciente.Telefono;
                comando.Parameters.Add("@IdTipoDocumento", System.Data.SqlDbType.NVarChar, 50).Value = paciente.TipoDocumento.Id;
                comando.Parameters.Add("@NumeroDocumento", System.Data.SqlDbType.NVarChar, 50).Value = paciente.NumeroDocumento;

                comando.ExecuteNonQuery();
            }
        }
    }
}
