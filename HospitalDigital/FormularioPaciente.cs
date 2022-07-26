using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            byte numero = 10;
            int otroNumero = (int)10L;
            numero = (byte)otroNumero;

            var valor = numero > 20 ? numero - 20 : (numero > 5 ? numero+10 :numero * 10);
            if (numero > 20)
            {
                valor = numero - 20;
            }
            else if(numero < 5)
                valor = numero - 5;
            else
            {
                valor = numero * 10;
            }

            int mes = 2;
            int descuento = 0;
            switch(numero)
            {
                case 1:
                    descuento = 10;
                    break;
                case 2:
                    descuento = 5;
                    break;
                case 3:
                case 4:
                    descuento = 3;
                    break;
                default:
                    descuento = 2;
                    break;

            }
        }
    }
}
