﻿using System;
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
    public partial class FormularioIngreso : Form
    {
        public FormularioIngreso()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender1"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender1, EventArgs e)
        {
            var form = new FormularioPaciente();
            form.IdPaciente = 20; 
            form.Show();
            this.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerPassword_Click(object sender, EventArgs e)
        {
            //Este código permite mostrar el caracter ingresado por el usuario
            /*
             * Este bloque de código verifica el caracter oculto
             * 
             */
            if (txtContraseña.PasswordChar == (char)0)
            {
                txtContraseña.PasswordChar = '*';
            }
            else
            {
                txtContraseña.PasswordChar = (char)0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
