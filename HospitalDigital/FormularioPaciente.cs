using System;
using System.Windows.Forms;

namespace HospitalDigital
{
    public partial class FormularioPaciente : Form
    {
        public FormularioPaciente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string primerNombre = txtPrimerNombre.Text;
            string segundoNombre = txtSegundoNombre.Text;
            string primerApellido = txtPrimerApellido.Text;
            string segundoApellido = txtSegundoApellido.Text;

            bool error = false;
            string errores = string.Empty;

            erpError.SetError(txtPrimerNombre, null);
            if (string.IsNullOrEmpty(primerNombre))
            {
                erpError.SetError(txtPrimerNombre, "Por favor ingrese el primer del paciente");
                errores += "Primer nombre";
                error = true;
            }

            if(!error)
                MessageBox.Show("El paciente fue almacenado exitosamente","Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information );
            else
                MessageBox.Show("Por favor revise los datos del paciente: \n" +
                    errores, "Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
