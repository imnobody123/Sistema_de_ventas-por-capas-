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
using System.IO;
using System.Diagnostics;
using BLL_Bussines_Logic_Layer_;

namespace UI_User_Interface_
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            //  Recibimos la hora y fecha del inicio  de sesión.
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'd'e MMMM 'd'el yyyy");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMassage(System.IntPtr hand, int wmsg, int wparam, int lparam);

        // ******************** MÉTODOS PARA LOS EVENTOS GRÁFICOS Y LÓGICOS DE LOS BOTONES ******************** \\

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            //  Escondemos el ListView de los reportes.
            listViewReportes.Visible = false;

            //  Llenamos el DataGridView Con los datos de la base de datos
            //  y le damos nombre al titulo con el mismo nombre del botón.
            llenarDataGridView("Productos");
            lblCategoria.Text = btnProductos.Text;
        }

        private void BtnEmpleaados_Click(object sender, EventArgs e)
        {
            listViewReportes.Visible = false;
            llenarDataGridView("Empleados");
            lblCategoria.Text = btnEmpleaados.Text;
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            listViewReportes.Visible = false;
            llenarDataGridView("Clientes");
            lblCategoria.Text = btnClientes.Text;
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            listViewReportes.Visible = false;
            llenarDataGridView("Venta");
            lblCategoria.Text = btnVentas.Text;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            listViewReportes.Visible = false;
            llenarDataGridView("Usuarios");
            lblCategoria.Text = btnUsuarios.Text;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form msgCerrarSesion = new FormCerrarSesion();
            Form1 form1 = new Form1();

            resultado = msgCerrarSesion.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.Close();
                form1.Show();
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.Image = Properties.Resources.cancel_white_;
            btnCerrar.BackColor = Color.Red;
        }

        private void BtnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.Image = Properties.Resources.cancel_black_;
            btnCerrar.BackColor = Color.Transparent;
        }

        //  Estas variables guardan la posición X e Y de la ventana del form principal.
        int posicionX, posicionY;
        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            //  Se les asigna la posicion que tenga la ventana del form en ese momento.
            posicionX = this.Location.X;
            posicionY = this.Location.Y;

            //  Se toma el tamaño del monitor para ajustar el form a el tamañno del mismo.
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            //  El boton que restaura la ventana a su tamaño original se muestra.
            btnRestaurar.Visible = true;

            //  El boton que maximiza la pantalla se esconde.
            btnMaximizar.Visible = false;
        }

        private void BtnMaximizar_MouseHover(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.FromArgb(202, 202, 202);
        }

        private void BtnMaximizar_MouseLeave(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.Transparent;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            //  Se le asigna al form la posición y tamaño iniciales.
            this.Size = new Size(974, 561);
            this.Location = new Point(posicionX, posicionY);

            //  El botón restaurar se oculta.
            btnRestaurar.Visible = false;

            //  El botón Maximizar se muestra.
            btnMaximizar.Visible = true;
        }

        private void BtnRestaurar_MouseHover(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.FromArgb(202, 202, 202);
        }

        private void BtnRestaurar_MouseLeave(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.Transparent;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMinimizar_MouseHover(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(202, 202, 202);
        }

        private void BtnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Transparent;
        }

        //  Este método muestra los reportes almacendaos.
        private void BtnReportes_Click(object sender, EventArgs e)
        {
            //  Hacemos visible nuestro ListView, lo limpiamos
            //  y reajustamos el tamaño al mismo escondemos el panel principal. 
            listViewReportes.Visible = true;
            listViewReportes.Items.Clear();
            panelPrincipal.Visible = false;
            listViewReportes.Dock = DockStyle.Fill;

            //  Variable que guarda la ruta donde están guardados
            //  nuestros reportes.
            String ruta = Application.StartupPath + "\\reportes\\";

            //  Verificamos que exista el directorio.
            if (Directory.Exists(ruta))
            {
                //  Almacenamos la ruta de los documentos en una matriz.
                String[] archivos = Directory.GetFiles(ruta, "*.txt");
                for (int i = 0; i < archivos.Length; i++)
                {
                    //  Añadimos los nommres de documentos encontrados al ListView
                    listViewReportes.Items.Add("Reporte" + i);
                }
            }
            else
            {
                MessageBox.Show("No hay reportes guardados");
            }
        }

        private void BtnInsertar_Click_1(object sender, EventArgs e)
        {
            FormInsertar formInsertar = new FormInsertar();
            formInsertar.muestra_panel_form(lblCategoria.Text);
            formInsertar.Show();
        }

        private void BtnActualizar_Click_1(object sender, EventArgs e)
        {
            FormActualizar formActualizar = new FormActualizar();
            formActualizar.muestra_panel_form(lblCategoria.Text);
            formActualizar.ShowDialog();
        }

        private void BtnEliminarRegistros_Click_1(object sender, EventArgs e)
        {
            FormEliminar formEliminar = new FormEliminar();
            formEliminar.muestra_panel_form(lblCategoria.Text);
            formEliminar.ShowDialog();
        }

        private void ListViewReportes_MouseClick_1(object sender, MouseEventArgs e)
        {
            //  Capturamos el elemenot seleccionado
            String NombreReporte = listViewReportes.SelectedItems[0].Text;
            String[] linea = new string[9];
            String ruta = Application.StartupPath + "\\reportes\\" + NombreReporte + ".txt";
            int NumeroLinea = 0;

            //  Aquí leemos el texto del documento seleccionado y los guardamos
            //  en la matriz
            using (StreamReader file = new StreamReader(ruta))
            {
                while (NumeroLinea < 9)
                {
                    linea[NumeroLinea] = file.ReadLine();
                    NumeroLinea++;
                }
            }
            formReporteGenerado formReporte = new formReporteGenerado();
            formReporte.llenarDatosReporte(linea[0], linea[1], linea[2], linea[3], linea[4], linea[5], linea[6], linea[7], linea[8], false);
            formReporte.ShowDialog();
        }

        // ******************** MÉTODOS A USAR DE LA CLASE ******************** \\


        //  Recibe el nombre de usuario del form anterior para mostrarlo
        //  en la ventana de bienvenida.
        public void recibeNomUsuario(String strrecibido)
        {
            lblNomUser.Text = strrecibido;
            lblUsuario.Text = strrecibido;
            lblUsuario.Visible = true;
        }

        public void llenarDataGridView(String nombre_tabla)
        {
            try
            {
                //  Hacemos visible el panel donde está contenido nuestro
                //  DataGridView.
                panelPrincipal.Visible = true;

                //  Recuperamos la tabla de nuestra clase BLL(Bussines, Logic Layer):
                DataTable tablaRecuperada = clsProcesaDatos.Recuperatabla(nombre_tabla);

                //  Cargamos nuestra tabla en el DataGridView y lo actualizamos  
                //  para ver los cambios.
                dataGridView1.DataSource = tablaRecuperada;
                dataGridView1.Update();
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error);
            }
        }

        //  Captura la posición del mouse para poder arrastrar nuestro form.
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMassage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
