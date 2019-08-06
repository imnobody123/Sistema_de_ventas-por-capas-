using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BLL_Bussines_Logic_Layer_;

namespace UI_User_Interface_
{
    public partial class FormInsertar : Form
    {
        public FormInsertar()
        {
            InitializeComponent();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtFechaV.Text = dateTimePicker1.Text;
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtFechaN.Text = dateTimePicker2.Text;
        }

        private void DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            txtFechaVenta.Text = dateTimePicker3.Text;
        }

        // ****************** ESTOS EVENTOS SON PARA DARLE UN EFECTO PLACEHOLDERr A LOS TEXTBOX. ****************** \\

        private void TxtNombreProducto_Enter(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "Nombre Producto")
            {
                txtNombreProducto.Text = "";
            }
        }

        private void TxtNombreProducto_Leave(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "")
            {
                txtNombreProducto.Text = "Nombre Producto";
            }
        }

        private void TxtStock_Enter(object sender, EventArgs e)
        {
            if (txtStock.Text == "Stock")
            {
                txtStock.Text = "";
            }
        }

        private void TxtStock_Leave(object sender, EventArgs e)
        {
            if (txtStock.Text == "")
            {
                txtStock.Text = "Stock";
            }
        }

        private void TxtPrecioC_Enter(object sender, EventArgs e)
        {
            if (txtPrecioC.Text == "Precio Compra")
            {
                txtPrecioC.Text = "";
            }
        }

        private void TxtPrecioC_Leave(object sender, EventArgs e)
        {
            if (txtPrecioC.Text == "")
            {
                txtPrecioC.Text = "Precio Compra";
            }
        }

        private void TxtPrecioV_Enter(object sender, EventArgs e)
        {
            if (txtPrecioV.Text == "Precio Venta")
            {
                txtPrecioV.Text = "";
            }
        }

        private void TxtPrecioV_Leave(object sender, EventArgs e)
        {
            if (txtPrecioV.Text == "")
            {
                txtPrecioV.Text = "Precio Venta";
            }
        }

        private void TxtNomEm_Enter(object sender, EventArgs e)
        {
            if (txtNomEm.Text == "Nombre")
            {
                txtNomEm.Text = "";
            }
        }

        private void TxtNomEm_Leave(object sender, EventArgs e)
        {
            if (txtNomEm.Text == "")
            {
                txtNomEm.Text = "Nombre";
            }
        }

        private void TxtApeP_Enter(object sender, EventArgs e)
        {
            if (txtApeP.Text == "Apellido Paterno")
            {
                txtApeP.Text = "";
            }
        }

        private void TxtApeP_Leave(object sender, EventArgs e)
        {
            if (txtApeP.Text == "")
            {
                txtApeP.Text = "Apellido Paterno";
            }
        }

        private void TxtApeM_Enter(object sender, EventArgs e)
        {
            if (txtApeM.Text == "Apellido Materno")
            {
                txtApeM.Text = "";
            }
        }

        private void TxtApeM_Leave(object sender, EventArgs e)
        {
            if (txtApeM.Text == "")
            {
                txtApeM.Text = "Apellido Materno";
            }
        }

        private void TxtDireccionEm_Enter(object sender, EventArgs e)
        {
            if (txtDireccionEm.Text == "Dirección")
            {
                txtDireccionEm.Text = "";
            }
        }

        private void TxtDireccionEm_Leave(object sender, EventArgs e)
        {
            if (txtDireccionEm.Text == "")
            {
                txtDireccionEm.Text = "Dirección";
            }
        }

        private void TxtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "Cantidad")
            {
                txtCantidad.Text = "";
            }
        }

        private void TxtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.Text = "Cantidad";
            }

            //  Calculamos el precio del campo 'Total'.
            if(txtCantidad.Text != "" && txtCantidad.Text != "Cantidad" && txtMuestraPre.Text != "Precio Venta")
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int precio = Convert.ToInt32(txtMuestraPre.Text);
                int costoTotal = cantidad * precio;
                txtPrecioT.Text = costoTotal.ToString();
            }
        }

        private void TxtPrecioT_Enter(object sender, EventArgs e)
        {
            if (txtPrecioT.Text == "Precio Total")
            {
                txtPrecioT.Text = "";
            }
        }

        private void TxtPrecioT_Leave(object sender, EventArgs e)
        {
            if (txtPrecioT.Text == "")
            {
                txtPrecioT.Text = "Precio Total";
            }
        }

        private void TxtNumDoc_Enter(object sender, EventArgs e)
        {
            if (txtNumDoc.Text == "Número de documento")
            {
                txtNumDoc.Text = "";
            }
        }

        private void TxtNumDoc_Leave(object sender, EventArgs e)
        {
            if (txtNumDoc.Text == "")
            {
                txtNumDoc.Text = "Número de documento";
            }
            if (txtNumDoc.Text != "Número de documento")
            {
                lblNum00.Text = txtNumDoc.Text;
            }
        }

        private void TxtNombreCliente_Enter(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == "Nombre Cliente")
            {
                txtNombreCliente.Text = "";
            }
        }

        private void TxtNombreCliente_Leave(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == "")
            {
                txtNombreCliente.Text = "Nombre Cliente";
            }
        }

        private void TxtApeCli_Enter(object sender, EventArgs e)
        {
            if (txtApeCli.Text == "Apellidos")
            {
                txtApeCli.Text = "";
            }
        }

        private void TxtApeCli_Leave(object sender, EventArgs e)
        {
            if (txtApeCli.Text == "")
            {
                txtApeCli.Text = "Apellidos";
            }
        }

        private void TxtDirCli_Enter(object sender, EventArgs e)
        {
            if (txtDirCli.Text == "Dirección")
            {
                txtDirCli.Text = "";
            }
        }

        private void TxtDirCli_Leave(object sender, EventArgs e)
        {
            if (txtDirCli.Text == "")
            {
                txtDirCli.Text = "Dirección";
            }
        }

        private void TxtTelCli_Enter(object sender, EventArgs e)
        {
            if (txtTelCli.Text == "Teléfono")
            {
                txtTelCli.Text = "";
            }
        }

        private void TxtTelCli_Leave(object sender, EventArgs e)
        {
            if (txtTelCli.Text == "")
            {
                txtTelCli.Text = "Teléfono";
            }
        }

        private void TxtNomUser_Enter(object sender, EventArgs e)
        {
            if (txtNomUser.Text == "Nombre Usuario")
            {
                txtNomUser.Text = "";
            }
        }

        private void TxtNomUser_Leave(object sender, EventArgs e)
        {
            if (txtNomUser.Text == "")
            {
                txtNomUser.Text = "Nombre Usuario";
            }
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña" || checkBoxMostrarContra.Checked != true)
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.UseSystemPasswordChar = false;
            }

        }

        private void TxtPass2_Enter(object sender, EventArgs e)
        {
            if (txtPass2.Text == "Confirma Contraseña" || checkBoxMostrarContra.Checked != true)
            {
                txtPass2.Text = "";
                txtPass2.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass2.Text = "";
                txtPass2.UseSystemPasswordChar = false;
            }
        }

        private void TxtPass2_Leave(object sender, EventArgs e)
        {
            if (txtPass2.Text == "")
            {
                txtPass2.Text = "Confirma Contraseña";
                txtPass2.UseSystemPasswordChar = false;
            }
        }

        private void CheckBoxMostrarContra_Click(object sender, EventArgs e)
        {
            if (checkBoxMostrarContra.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass2.UseSystemPasswordChar = false;
                Debug.WriteLine("Esta seleccionado");
            }
            else if(checkBoxMostrarContra.Checked == false)
            {
                if (txtPass.Text == "Contraseña")
                {
                    txtPass.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPass.UseSystemPasswordChar = true;
                }
           
                if (txtPass2.Text == "Confirma Contraseña")
                {
                    txtPass2.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPass2.UseSystemPasswordChar = true;
                }
                
                Debug.WriteLine("No Esta seleccionado");
            }
        }

        //  Este método sirve para mostrar el fomrulario insertar de cada categoria.

        public void muestra_panel_form(String Nombre_Panel)
        {
            Random random = new Random();
            int numero_R = random.Next(0,100000);
            lblNumBol.Text = numero_R.ToString();

            if (Nombre_Panel == "Productos")
            {
                panelProductos.Visible = true;
                panelProductos.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(265, 72);

                //  Cambiamos el tamaño del formulario al del mismo
                //  tamaño del panel.
                this.Size = new Size(265, 382);
            }
            else if(Nombre_Panel == "Empleados")
            {
                panelEmpleados.Visible = true;
                panelEmpleados.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(497, 72);
                this.Size = new Size(497, 382);
            }
            else if (Nombre_Panel == "Clientes")
            {
                panelClientes.Visible = true;
                panelClientes.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(265, 72);
                this.Size = new Size(265, 382);
            }
            else if (Nombre_Panel == "Ventas")
            {
                panelVentas.Visible = true;
                panelVentas.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(643, 72);
                this.Size = new Size(643, 446);

                llenarComboBoxFormVenta();
            }
            else if (Nombre_Panel == "Usuarios")
            {
                panelUsuarios.Visible = true;
                panelUsuarios.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(387, 72);
                this.Size = new Size(387, 328);
            }
        }

        //  ****************** Métodos y eventos para el formulario de Ventas. ****************** \\

        DataTable tablaEmpleados = clsProcesaDatos.Recuperatabla("Empleados");
        DataTable tablaProductos = clsProcesaDatos.Recuperatabla("Productos");
        DataTable tablaClientes = clsProcesaDatos.Recuperatabla("Clientes");
        private void llenarComboBoxFormVenta()
        {
            for (int i = 0; i < tablaEmpleados.Rows.Count; i++)
            {
                String IdEmpleado = Convert.ToString(tablaEmpleados.Rows[i].Field<int>("IdEmpleado"));
                comboIDEm.Items.Add(IdEmpleado);
            }

            for (int i = 0; i < tablaProductos.Rows.Count; i++)
            {
                String IdProducto = Convert.ToString(tablaProductos.Rows[i].Field<int>("IdProductos"));
                comboIdPro.Items.Add(IdProducto);
            }

            for (int i = 0; i < tablaClientes.Rows.Count; i++)
            {
                String IdCliente = Convert.ToString(tablaClientes.Rows[i].Field<int>("IdCliente"));
                comboIdCli.Items.Add(IdCliente);
            }
        }

        private void ComboIDEm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMuestraNombreE.Text = tablaEmpleados.Rows[(Convert.ToInt32(comboIDEm.SelectedItem)) - 1].Field<String>("Nombre");
            txtMuestraApeEm.Text = tablaEmpleados.Rows[(Convert.ToInt32(comboIDEm.SelectedItem)) - 1].Field<String>("ApellidoP") + " " +
                                    tablaEmpleados.Rows[(Convert.ToInt32(comboIDEm.SelectedItem)) - 1].Field<String>("ApellidoM");
        }

        private void ComboIdPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMuestraNomPro.Text = tablaProductos.Rows[(Convert.ToInt32(comboIdPro.SelectedItem)) - 1].Field<String>("Nombre");
            txtMuestraDes.Text = tablaProductos.Rows[(Convert.ToInt32(comboIdPro.SelectedItem)) - 1].Field<String>("Descripcion");
            txtMuestraPre.Text = Convert.ToString(tablaProductos.Rows[(Convert.ToInt32(comboIdPro.SelectedItem)) - 1].Field<Decimal>("PrecioVenta"));
        }

        private void ComboIdCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMuestraNomCli.Text = tablaClientes.Rows[(Convert.ToInt32(comboIdCli.SelectedItem)) - 1].Field<String>("Nombre");
            txtMuestraApeCli.Text = tablaClientes.Rows[(Convert.ToInt32(comboIdCli.SelectedItem)) - 1].Field<String>("Apellidos");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (panelProductos.Visible == true)
                {
                    clsProcesaDatos.insertaProductos(txtNombreProducto.Text, comboDescripcion.Text, txtStock.Text, txtPrecioC.Text, txtPrecioV.Text, txtFechaV.Text);
                    MessageBox.Show("Datos Guardados Correctamente");
                }
                else if (panelEmpleados.Visible == true)
                {
                    Debug.WriteLine("Hola Empleados está activo");
                    String sexo = "";
                    if (radioM.Checked == true)
                    {
                        sexo = "Masculino";
                    }
                    else if (radioF.Checked == true)
                    {
                        sexo = "Femenino";
                    }
                    clsProcesaDatos.InsertaEmpleados(txtNomEm.Text, txtApeP.Text, txtApeM.Text, sexo, comboEstadoCivil.Text, txtFechaN.Text, txtDireccionEm.Text);
                    MessageBox.Show("Datos Guardados Correctamente");
                }
                else if (panelClientes.Visible == true)
                {
                    clsProcesaDatos.InsertaClientes(txtNombreCliente.Text, txtApeCli.Text, txtDirCli.Text, txtTelCli.Text);
                    MessageBox.Show("Datos Guardados Correctamente");
                }
                else if (panelVentas.Visible == true)
                {
                    clsProcesaDatos.InsertaVenta(comboIDEm.Text, comboIdPro.Text, comboIdCli.Text, txtCantidad.Text, comboTipoDoc.Text, txtNumDoc.Text, txtFechaVenta.Text, txtPrecioT.Text);
                    MessageBox.Show("Datos Guardados Correctamente");
                }
                else if (panelUsuarios.Visible == true)
                {
                    if(txtPass.Text == txtPass2.Text)
                    {
                        clsProcesaDatos.InsertaUsuario(txtNomUser.Text, txtPass.Text);
                        MessageBox.Show("Datos Guardados Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Datos no insertados: " + er);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            formReporteGenerado formReporte = new formReporteGenerado();
            formReporte.llenarDatosReporte(txtMuestraNombreE.Text, txtMuestraNomCli.Text, txtNumDoc.Text, lblNumBol.Text, txtMuestraNomPro.Text, txtCantidad.Text, txtMuestraPre.Text, txtFechaVenta.Text, txtPrecioT.Text, true);
            formReporte.ShowDialog();
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
    }
}
