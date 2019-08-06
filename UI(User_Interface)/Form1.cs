using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BLL_Bussines_Logic_Layer_;

namespace UI_User_Interface_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMassage(System.IntPtr hand, int wmsg, int wparam, int lparam);

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
             String usuario = txtUsuario.Text;
             String contrasena = txtContrasena.Text;
             Boolean existData = clsProcesaDatos.VerificarDatos(usuario, contrasena);
             if (existData == true || txtUsuario.Text != "Usuario" && txtContrasena.Text != "Contraseña")
             {
                this.Hide();
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.recibeNomUsuario(usuario);
                formPrincipal.Show();
             }
             else
             {
                //  Se cambian de color los campos de texto a rojo en caso de que
                //  el inicio de sesión sea incorrecto.
                txtUsuario.Text = "Usuario";
                txtContrasena.Text = "Contraseña";
                txtUsuario.ForeColor = Color.Red;
                txtContrasena.ForeColor = Color.Red;
                txtContrasena.UseSystemPasswordChar = false;
                lineShape1.BorderColor = Color.Red;
                lineShape2.BorderColor = Color.Red;
                msgError.Text = "*   Datos Incorrectos";
            }
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            //Cuando el textbox se encuentre seleccioando el texto 'Usuario' desaparecerá
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
                lineShape1.BorderColor = Color.White;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            //Cuando el textbox no se encuentre seleccioando el texto 'Usuario' reaparecerá
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.FromArgb(165, 165, 165);
            }
        }

        private void TxtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.White;
                txtContrasena.UseSystemPasswordChar = true;
                lineShape2.BorderColor = Color.White;
            }
        }

        private void TxtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = Color.FromArgb(165, 165, 165);
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMassage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
