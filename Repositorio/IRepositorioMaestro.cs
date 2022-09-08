using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public interface IRepositorioMaestro
    {
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}