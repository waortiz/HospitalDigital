using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMaestro
    {
        IRepositorioMaestro repositorioMaestro;
        public NegocioMaestro(IRepositorioMaestro repositorioMaestro)
        {
            this.repositorioMaestro = repositorioMaestro;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            return repositorioMaestro.ObtenerTiposDocumento();
        }
    }
}
