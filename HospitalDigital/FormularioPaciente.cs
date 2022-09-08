using Entidades;
using Negocio;
using Repositorio;
using System;
using System.Windows.Forms;

namespace HospitalDigital
{
    public partial class FormularioPaciente : Form
    {
        public long IdPaciente;
        public IRepositorioPaciente repositorioPaciente;
        public IRepositorioMaestro repositorioMaestro;

        public FormularioPaciente()
        {
            InitializeComponent();
            repositorioPaciente = new RepositorioPacienteEF();
            repositorioMaestro = new RepositorioMaestroEF();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string numeroDocumento = txtNumeroDocumento.Text;
                var tipoDocumento = cboTipoDocumento.SelectedItem as TipoDocumento;
                string primerNombre = txtPrimerNombre.Text;
                string segundoNombre = txtSegundoNombre.Text;
                string primerApellido = txtPrimerApellido.Text;
                string segundoApellido = txtSegundoApellido.Text;
                string telefono = txtTelefono.Text;
                decimal estatura = Convert.ToDecimal(txtEstatura.Text);
                string valores = dtpFechaNacimiento.Value.ToString("dd/MMM/yyyy");

                var estado = ValidarDatos();
                if (estado)
                {
                    var paciente = new Paciente()
                    {
                         Estatura = estatura,
                         FechaNacimiento = dtpFechaNacimiento.Value,
                         PrimerApellido = primerApellido,
                         SegundoApellido = segundoApellido,
                         PrimerNombre = primerNombre,
                         SegundoNombre = segundoNombre,
                         Telefono = telefono,
                         TipoDocumento = tipoDocumento,
                         NumeroDocumento = numeroDocumento,
                         Id = new Random().Next()
                    };
                    var negocio = new NegocioPaciente(repositorioPaciente);
                    negocio.IngresarPaciente(paciente);

                    MessageBox.Show($"El paciente fue almacenado exitosamente: {valores}", "Paciente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Por favor revise los datos del paciente", "Paciente",
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

        private bool ValidarDatos()
        {
            bool estado = true;

            erpError.SetError(cboTipoDocumento, null);
            if (cboTipoDocumento.SelectedItem == null)
            {
                erpError.SetError(txtTelefono, "Por favor seleccione el tipo de documento");
                estado = false;
            }

            erpError.SetError(txtNumeroDocumento, null);
            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                erpError.SetError(txtNumeroDocumento, "Por favor ingrese el número de documento");
                estado = false;
            }
            erpError.SetError(txtPrimerNombre, null);
            if (string.IsNullOrEmpty(txtPrimerNombre.Text))
            {
                erpError.SetError(txtPrimerNombre, "Por favor ingrese el primer del paciente");
                estado = false;
            }
            erpError.SetError(txtPrimerApellido, null);
            if (string.IsNullOrEmpty(txtPrimerApellido.Text))
            {
                erpError.SetError(txtPrimerApellido, "Por favor ingrese el primer del apellido");
                estado = false;
            }

            erpError.SetError(txtEstatura, null);
            if (string.IsNullOrEmpty(txtEstatura.Text))
            {
                erpError.SetError(txtEstatura, "Por favor ingrese la estatura");
                estado = false;
            }

            erpError.SetError(txtTelefono, null);
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                erpError.SetError(txtTelefono, "Por favor ingrese el teléfono");
                estado = false;
            }

            erpError.SetError(dtpFechaNacimiento, null);
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                erpError.SetError(txtTelefono, "La fecha de nacimiento no puede ser mayor a la fecha actual");
                estado = false;
            }

            return estado;
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

        private void FormularioPaciente_Load(object sender, EventArgs e)
        {
            var negocioMaestro = new NegocioMaestro(repositorioMaestro);
            var tiposDocumento = negocioMaestro.ObtenerTiposDocumento();
            cboTipoDocumento.DataSource = tiposDocumento;
            cboTipoDocumento.DisplayMember = "Nombre";
        }
    }
}
