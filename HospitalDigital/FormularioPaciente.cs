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
            try
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

                if (!error)
                    MessageBox.Show("El paciente fue almacenado exitosamente", "Paciente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Por favor revise los datos del paciente: \n" +
                        errores, "Paciente",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Por favor revise los datos del paciente: \n" +
                                        exc.Message, "Paciente",
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Error);
                //Envío email
                //Log
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numero = e.KeyChar; 
            if(numero < 48 || numero > 57 )
            {
                e.Handled = true;
            }
        }

        private void FormularioPaciente_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtPrimerNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(txtPrimerNombre.Text.Contains("@"))
            {
                erpError.SetError(txtPrimerNombre, "El " +
                    "primer nombre contiene caracteres extraños");
                e.Cancel = true;
            }
            else
            {
                erpError.SetError(txtPrimerNombre, null);
            }
        }

        private void txtEstatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numero = e.KeyChar;
            if ((numero < 48 || numero > 57) && numero != 44 && numero != 8)
            {
                e.Handled = true;
            }
        }

        private void txtEstatura_Leave(object sender, EventArgs e)
        {
            double estatura = 0;
            if (!double.TryParse(txtEstatura.Text, out estatura))
            {
                erpError.SetError(txtEstatura, "La estatura no es válida");
            }
            else
            {
                erpError.SetError(txtEstatura, null);
            }
        }
    }
}
