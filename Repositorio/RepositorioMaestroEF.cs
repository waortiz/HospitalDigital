using Entidades;
using Modelo;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RepositorioMaestroEF : IRepositorioMaestro
    {
        private ContextoHospitalDigital contexto = new ContextoHospitalDigital();
        public List<Entidades.TipoDocumento> ObtenerTiposDocumento()
        {
            return contexto.TiposDocumento.OrderBy(t => t.Nombre).Select(t => new Entidades.TipoDocumento()
            {
                Id = t.Id,
                Nombre = t.Nombre
            }).ToList();
        }
    }
}
