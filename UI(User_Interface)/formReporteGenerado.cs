using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Diagnostics;

namespace UI_User_Interface_
{
    public partial class formReporteGenerado : Form
    {
        public formReporteGenerado()
        {
            InitializeComponent();
        }

        private String NombreEmpleado;
        private String NombreCliente;
        private String Numero_de_Documento;
        private String Numero_de_Boleta;
        private String Nombre_Producto;
        private String Cantidad;
        private String Costo_Unidad;
        private String Fecha_Venta;
        private String Total;
        private String Mensaje;

        private Font font = new Font("Arial Rounded MT", 11, FontStyle.Bold);
        private Font font2 = new Font("Arial Rounded MT", 20, FontStyle.Bold);

        public void llenarDatosReporte(String datosEmp, String datosCli, String datosDoc, String NumBol, String NombrePro, String Cant,String CostoUnidad, String FechaV, String PrecioT, Boolean Boton)
        {
            btnGuardar.Visible = Boton;
            lblDatosEmp.Text = datosEmp;
            lblDatosCli.Text = datosCli;
            lblDatosDoc.Text = datosDoc;
            lblNumBol.Text = NumBol;
            lblNombrePro.Text = NombrePro;
            lblCant.Text = Cant;
            lblCosUni.Text = CostoUnidad;
            lblFechaV.Text = FechaV;
            lblTotal.Text = PrecioT;
        }

        public void Imprimir_Reporte()
        {
            PrintDocument reporte = new PrintDocument();
            reporte.PrintPage += new PrintPageEventHandler(Datos_Imprimir);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = reporte;
            DialogResult resulta = printDialog.ShowDialog();

            if (resulta == DialogResult.OK)
            {
                reporte.Print();
            }
        }

        private void Datos_Imprimir(object obj, PrintPageEventArgs ev)
        {
            float pos_X = 10;
            float pos_Y = 20;

            NombreEmpleado = lblDatosEmp.Text;
            NombreCliente = lblDatosCli.Text;
            Numero_de_Documento = lblDatosDoc.Text;
            Numero_de_Boleta = lblNumBol.Text;
            Nombre_Producto = lblNombrePro.Text;
            Cantidad = lblCant.Text;
            Costo_Unidad = lblCosUni.Text;
            Fecha_Venta = lblFechaV.Text;
            Total = lblTotal.Text;
            Mensaje = lblMensaje.Text;

            ev.Graphics.DrawString("Nombre Empleado:", font, Brushes.Black, pos_X, pos_Y, new StringFormat());
            ev.Graphics.DrawString("Nombre Cliente:", font, Brushes.Black, pos_X, pos_Y + 25, new StringFormat());
            ev.Graphics.DrawString("Número de Documento:", font, Brushes.Black, pos_X, pos_Y + 50, new StringFormat());
            ev.Graphics.DrawString("Número de Boleta:", font, Brushes.Black, pos_X, pos_Y + 75, new StringFormat());
            ev.Graphics.DrawString("Nombre Producto", font, Brushes.Black, pos_X, pos_Y + 100, new StringFormat());
            ev.Graphics.DrawString("Cantidad:", font, Brushes.Black, pos_X, pos_Y + 125, new StringFormat());
            ev.Graphics.DrawString("Costo Por Unidad:", font, Brushes.Black, pos_X, pos_Y + 150, new StringFormat());
            ev.Graphics.DrawString("Fecha Venta", font, Brushes.Black, pos_X, pos_Y + 175, new StringFormat());
            ev.Graphics.DrawString("Total:", font, Brushes.Black, pos_X, pos_Y + 230, new StringFormat());

            ev.Graphics.DrawString(NombreEmpleado, font, Brushes.Black, pos_X + 250, pos_Y, new StringFormat());
            ev.Graphics.DrawString(NombreCliente, font, Brushes.Black, pos_X + 250, pos_Y + 25, new StringFormat());
            ev.Graphics.DrawString(Numero_de_Documento, font, Brushes.Black, pos_X + 250, pos_Y + 50, new StringFormat());
            ev.Graphics.DrawString(Numero_de_Boleta, font, Brushes.Black, pos_X + 250, pos_Y + 75, new StringFormat());
            ev.Graphics.DrawString(Nombre_Producto, font, Brushes.Black, pos_X + 250, pos_Y + 100, new StringFormat());
            ev.Graphics.DrawString(Cantidad, font, Brushes.Black, pos_X + 250, pos_Y + 125, new StringFormat());
            ev.Graphics.DrawString(Costo_Unidad, font, Brushes.Black, pos_X + 250, pos_Y + 150, new StringFormat());
            ev.Graphics.DrawString(Fecha_Venta, font, Brushes.Black, pos_X + 250, pos_Y + 175, new StringFormat());
            ev.Graphics.DrawString(Total, font, Brushes.Black, pos_X + 250, pos_Y + 230, new StringFormat());
            ev.Graphics.DrawString(Mensaje, font2, Brushes.Teal, pos_X + 15, pos_Y + 290, new StringFormat());
        }

        private void generar_Reporte()
        {
            String ruta = Application.StartupPath + "\\reportes\\";
            if (Directory.Exists(ruta))
            {
                String[] archivos = Directory.GetFiles(ruta, "*.txt");
                int cantidadArchivos = archivos.Length;
                for (int i = 0; i < cantidadArchivos; i++)
                {
                    if (!File.Exists(ruta + "reportes" + (i+1) + ".txt")){
                        crear_Reporte_TXT(ruta, (i+1));
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(ruta);
                crear_Reporte_TXT(ruta, 0);
            }
        }

        private void crear_Reporte_TXT(String ruta, int numReporte)
        {
            StreamWriter file = File.AppendText(ruta + "Reporte" + numReporte + ".txt");
            file.WriteLine(lblDatosEmp.Text);
            file.WriteLine(lblDatosCli.Text);
            file.WriteLine(lblDatosDoc.Text);
            file.WriteLine(lblNumBol.Text);
            file.WriteLine(lblNombrePro.Text);
            file.WriteLine(lblCosUni.Text);
            file.WriteLine(lblCant.Text);
            file.WriteLine(lblFechaV.Text);
            file.WriteLine(lblTotal.Text);
            file.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir_Reporte();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                generar_Reporte();
                MessageBox.Show("Reporte Guardado");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al guardar");
            }
        }
    }
}
