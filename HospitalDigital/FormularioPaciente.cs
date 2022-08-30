using Entidades;
using System;
using System.Windows.Forms;

namespace HospitalDigital
{
    public partial class FormularioPaciente : Form
    {
        public long IdPaciente;

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
                decimal estatura = Convert.ToDecimal(txtEstatura.Text);

                bool error = false;
                string errores = string.Empty;

                erpError.SetError(txtPrimerNombre, null);
                if (string.IsNullOrEmpty(primerNombre))
                {
                    erpError.SetError(txtPrimerNombre, "Por favor ingrese el primer del paciente");
                    errores += "Primer nombre";
                    error = true;
                }

                string valores = dtpFechaNacimiento.Value.ToString("dd/MMM/yyyy");
                if (!error)
                    MessageBox.Show($"El paciente fue almacenado exitosamente: {valores}", "Paciente",
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

        private static bool Validardatos()
        {
            var valor = true;


            return valor;
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numero = e.KeyChar; 
            if(numero < (int)TablaASCII.CERO || numero > (int)TablaASCII.NUEVE)
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
