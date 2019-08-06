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
    public partial class FormActualizar : Form
    {
        DataTable tablaUsuarios = clsProcesaDatos.Recuperatabla("Usuarios");
        DataTable tablaEmpleados = clsProcesaDatos.Recuperatabla("Empleados");
        DataTable tablaProductos = clsProcesaDatos.Recuperatabla("Productos");
        DataTable tablaClientes = clsProcesaDatos.Recuperatabla("Clientes");
        DataTable tablaVentas = clsProcesaDatos.Recuperatabla("Venta");

        public FormActualizar()
        {
            InitializeComponent();
        }

        public void muestra_panel_form(String Nombre_Panel)
        {
            lblCategoria.Text = Nombre_Panel;
            if (Nombre_Panel == "Productos")
            {
                llenarComboBox(tablaProductos, "IdProductos");
                panelProductos.Visible = true;
                panelProductos.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);

                //  Cambiamos el tamaño del formulario al del mismo
                //  tamaño del panel.
                this.Size = new Size(265 + 120, 382 + 91);
            }
            else if (Nombre_Panel == "Empleados")
            {
                llenarComboBox(tablaEmpleados, "IdEmpleado");
                panelEmpleados.Visible = true;
                panelEmpleados.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);
                this.Size = new Size(316 + 120, 297 + 160);
            }
            else if (Nombre_Panel == "Clientes")
            {
                llenarComboBox(tablaClientes, "IdCliente");
                panelClientes.Visible = true;
                panelClientes.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);
                this.Size = new Size(316 + 120, 169 + 190);
            }
            else if (Nombre_Panel == "Ventas")
            {
                llenarComboBox(tablaVentas, "IdVenta");
                panelVentas.Visible = true;
                panelVentas.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);
                this.Size = new Size(316 + 120, 297 + 200);
            }
            else if (Nombre_Panel == "Usuarios")
            {
                llenarComboBox(tablaUsuarios, "IdUsuario");
                panelUsuarios.Visible = true;
                panelUsuarios.Dock = DockStyle.Fill;
                this.Size = new Size(387, 328);
            }
        }

        private void llenarComboBox(DataTable tabla, String id)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                String Id = Convert.ToString(tabla.Rows[i].Field<int>(id));
                comboId.Items.Add(Id);
            }

            if(lblCategoria.Text == "Ventas")
            {
                for (int i = 0; i < tablaProductos.Rows.Count; i++)
                {
                    String Id = Convert.ToString(tablaProductos.Rows[i].Field<int>("IdProductos"));
                    comboIdP.Items.Add(Id);
                }

                for (int i = 0; i < tablaClientes.Rows.Count; i++)
                {
                    String Id = Convert.ToString(tablaClientes.Rows[i].Field<int>("IdCliente"));
                    comboIdC.Items.Add(Id);
                }

                for (int i = 0; i < tablaEmpleados.Rows.Count; i++)
                {
                    String Id = Convert.ToString(tablaEmpleados.Rows[i].Field<int>("IdEmpleado"));
                    comboIdE.Items.Add(Id);
                }
            }
        }

        //  Este método llena automáticamente los campos a editar al seleccionar el
        //  el Id por medio del combobox.
        private void ComboId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblCategoria.Text == "Productos")
            {
                txtNomPro.Text = tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre");
                txtDes.Text = tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Descripcion");
                txtStock.Text = "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("Stock");
                txtPC.Text = "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioCompra");
                txtPV.Text = "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioVenta");
                DateTime fecha = tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaVencimiento");
                txtFechaV.Text = fecha.ToShortDateString();
            }
            else if (lblCategoria.Text == "Empleados")
            {
                txtNomEmp.Text = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre");
                txtApeP.Text = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("ApellidoP");
                txtApeM.Text = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("ApellidoM");
                txtSexo.Text = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Sexo");
                comboEstadoCivil.Text = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("EstadoCivil");
                DateTime fechaN = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaN");
                txtFN.Text = fechaN.ToShortDateString();
                txtDireEmp.Text = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Direccion");
            }
            else if (lblCategoria.Text == "Clientes")
            {
                txtNomCli.Text = tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre");
                txtApe.Text = tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Apellidos");
                txtDire.Text = tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Direccion");
                txtTel.Text = "" + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int64>("Telefono");
            }
            else if (lblCategoria.Text == "Ventas")
            {
                comboIdE.Text = "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdEmpleado");
                comboIdP.Text = "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdProductos");
                comboIdC.Text = "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdCliente");
                txtCantComp.Text = "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("CantidadComprada");
                comboDoc.Text = tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("TipoDocumento");
                txtNumDoc.Text = "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("NumeroDocumento");
                DateTime fechaVenta = tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaVenta");
                txtFVen.Text = fechaVenta.ToShortDateString();
                txtPT.Text = "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioTotal");
            }
            else if (lblCategoria.Text == "Usuarios")
            {
                txtUser.Text = tablaUsuarios.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Usuario");
            }
            lblMensaje.Visible = true;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (lblCategoria.Text)
                {
                    case "Productos":
                        if (txtNomPro.Text == tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre") &&
                            txtDes.Text == tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Descripcion") &&
                            txtStock.Text == "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("Stock") &&
                            txtPC.Text == "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioCompra") &&
                            txtPV.Text == "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioVenta") &&
                            txtFechaV.Text == "" + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaVencimiento").ToShortDateString())
                        {
                            MessageBox.Show("¡ Los datos son los mismos !");
                        }
                        else
                        {
                            clsProcesaDatos.ActualizaProductos(comboId.Text, txtNomPro.Text, txtDes.Text, txtStock.Text, txtPC.Text, txtPV.Text, txtFechaV.Text);
                            MessageBox.Show("Datos Actualizados Correctamente");
                        }
                        break;
                    case "Empleados":
                        if (txtNomEmp.Text == tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre") &&
                            txtApeP.Text == tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("APellidoP") &&
                            txtApeM.Text == "" + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("ApellidoM") &&
                            txtSexo.Text == "" + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Sexo") &&
                            comboEstadoCivil.Text == "" + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("EstadoCivil") &&
                            txtFN.Text == "" + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaN").ToShortDateString() &&
                            txtDireEmp.Text == tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Direccion"))
                        {
                            MessageBox.Show("¡ Los datos son los mismos !");
                        }
                        else
                        {
                            clsProcesaDatos.ActualizaEmpleados(comboId.Text, txtNomEmp.Text, txtApeP.Text, txtApeM.Text, txtSexo.Text, comboEstadoCivil.Text, txtFN.Text, txtDireEmp.Text);
                            MessageBox.Show("Datos Actualizados Correctamente");
                        }
                        break;
                    case "Clientes":
                        if (txtNomCli.Text == tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre") &&
                            txtApe.Text == tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Apellidos") &&
                            txtDire.Text == "" + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Direccion") &&
                            txtTel.Text == "" + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int64>("Telefono"))
                        {
                            MessageBox.Show("¡ Los datos son los mismos !");
                        }
                        else
                        {
                            clsProcesaDatos.ActualizaClientes(comboId.Text, txtNomCli.Text, txtApe.Text, txtDire.Text, txtTel.Text);
                            MessageBox.Show("Datos Actualizados Correctamente");
                        }
                        break;
                    case "Ventas":
                        if (
                            txtFVen.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaVenta") &&
                            comboIdP.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdProductos") &&
                            comboIdE.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdEmpleado") &&
                            comboIdC.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdCliente") &&
                            txtCantComp.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("CantidadComprada") &&
                            comboDoc.Text == tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("TipoDocumento") &&
                            txtNumDoc.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("NumeroDocumento") &&
                            txtPT.Text == "" + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("PrecioTotal")
                            )
                        {
                            MessageBox.Show("¡ Los datos son los mismos !");
                        }
                        else
                        {
                            clsProcesaDatos.ActualizaVenta(comboId.Text, comboIdE.Text, comboIdP.Text, comboIdC.Text, txtCantComp.Text, comboDoc.Text, txtNumDoc.Text, txtFVen.Text, txtPT.Text);
                            MessageBox.Show("Datos Actualizados Correctamente");
                        }
                        break;
                    case "Usuarios":
                        if (txtUser.Text == tablaUsuarios.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Usuario") &&
                            txtContrasena.Text == tablaUsuarios.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Contrasena"))
                        {
                            MessageBox.Show("¡ Los datos son los mismos !");
                        }
                        else
                        {
                            clsProcesaDatos.ActualizaUsuario(comboId.Text, txtUser.Text, txtContrasena.Text);
                            MessageBox.Show("Datos Actualizados Correctamente");

                        }
                        break;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error);
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtFN.Text = dateTimePicker1.Text;
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtFechaV.Text = dateTimePicker2.Text;
        }

        private void DatetxtFechaVen_ValueChanged(object sender, EventArgs e)
        {
            txtFVen.Text = datetxtFechaVen.Text;
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
    }
}
