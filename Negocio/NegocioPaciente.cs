using Entidades;
using Repositorio;

namespace Negocio
{
    public class NegocioPaciente
    {
        IRepositorioPaciente repositorioPaciente;
        public NegocioPaciente(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public void IngresarPaciente(Paciente paciente)
        {
            //Aplicar reglas de negocio

            //Guardamos en el repositorio
            repositorioPaciente.IngresarPaciente(paciente);
        }
    }
}
