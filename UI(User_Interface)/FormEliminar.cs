using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_Bussines_Logic_Layer_;

namespace UI_User_Interface_
{
    public partial class FormEliminar : Form
    {
        DataTable tablaUsuarios = clsProcesaDatos.Recuperatabla("Usuarios");
        DataTable tablaEmpleados = clsProcesaDatos.Recuperatabla("Empleados");
        DataTable tablaProductos = clsProcesaDatos.Recuperatabla("Productos");
        DataTable tablaClientes = clsProcesaDatos.Recuperatabla("Clientes");
        DataTable tablaVentas = clsProcesaDatos.Recuperatabla("Venta");

        public FormEliminar()
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
                this.Size = new Size(265+120, 382+91);
            }
            else if (Nombre_Panel == "Empleados")
            {
                llenarComboBox(tablaEmpleados, "IdEmpleado");
                panelEmpleados.Visible = true;
                panelEmpleados.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);
                this.Size = new Size(316+120, 297+91);
            }
            else if (Nombre_Panel == "Clientes")
            {
                llenarComboBox(tablaClientes, "IdCliente");
                panelClientes.Visible = true;
                panelClientes.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);
                this.Size = new Size(316+120, 169+190);
            }
            else if (Nombre_Panel == "Ventas")
            {
                llenarComboBox(tablaVentas, "IdVenta");
                paanelVentas.Visible = true;
                paanelVentas.Dock = DockStyle.Fill;
                panelInferior.Size = new Size(653, 91);
                this.Size = new Size(316+120, 297+200);
            }
            else if (Nombre_Panel == "Usuarios")
            {
                llenarComboBox(tablaUsuarios, "IdUsuario");
                panelUsuarios.Visible = true;
                panelUsuarios.Dock = DockStyle.Fill;
                this.Size = new Size(387, 328);
            }
        }

        private void llenarComboBox(DataTable tabla, String id )
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                String IdEmpleado = Convert.ToString(tabla.Rows[i].Field<int>(id));
                comboId.Items.Add(IdEmpleado);
            }
        }

        private void ComboId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblCategoria.Text == "Productos")
            {
                lblNomPro.Text = "Nombre Producto:   " + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre");
                lblDes.Text = "Descripción:   " + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Descripcion");
                lblStock.Text = "Stock:   " + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("Stock");
                lblPC.Text = "Precio de Compra:   " + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioCompra");
                lblPV.Text = "Precio de Venta:   " + tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioVenta");
                DateTime fecha = tablaProductos.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaVencimiento");
                lblFechaV.Text = "Fecha de Vencimiento:   " + fecha.ToShortDateString();
            }
            else if (lblCategoria.Text == "Empleados")
            {
                lblNomEmp.Text = "Nombre Producto:   " + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre");
                lblApeP.Text = "Apelldio Paterno:   " + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("ApellidoP");
                lblApeM.Text = "Apelldio Materno:   " + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("ApellidoM");
                lblSexo.Text = "Sexo:   " + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Sexo");
                lblEC.Text = "Estado Civil:   " + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("EstadoCivil");
                DateTime fechaN = tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaN");
                lblFN.Text = "Fecha de Nacimiento:   " + fechaN.ToShortDateString();
                lblDireEmp.Text = "Dirección:   " + tablaEmpleados.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Direccion");
            }
            else if (lblCategoria.Text == "Clientes")
            {
                lblNomCli.Text = "Nombre Cliente:   " + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Nombre");
                lblApe.Text = "Apellidos:   " + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Apellidos");
                lblDire.Text = "Dirección:   " + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Direccion");
                lblTel.Text = "Teléfono:   " + tablaClientes.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int64>("Telefono");
            }
            else if (lblCategoria.Text == "Ventas")
            {
                lblIdC.Text = "Id Cliente:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdCliente");
                lblIdE.Text = "Id Empleado:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdEmpleado");
                lblIdP.Text = "Id Producto:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("IdProductos"); 
                lblCantComp.Text = "Cantidad Comprada:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("CantidadComprada");
                lblSerie.Text = "Serie: " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Serie");
                lblDoc.Text = "Apellidos:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("TipoDocumento");
                lblNumDoc.Text = "Número de Documento:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Int32>("NumeroDocumento");
                DateTime fechaVenta = tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<DateTime>("FechaVenta");
                lblFVen.Text = "Fecha de Venta:   " + fechaVenta.ToShortDateString();
                lblPT.Text = "Precio Total:   " + tablaVentas.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<Decimal>("PrecioTotal");
            }
            else if (lblCategoria.Text == "Usuarios")
            {
                lblUser.Text = "Usuario:    " + tablaUsuarios.Rows[Convert.ToInt32(comboId.SelectedItem) - 1].Field<String>("Usuario");
            }
            lblMensaje.Visible = true;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (lblCategoria.Text)
                {
                    case "Productos":
                        clsProcesaDatos.eliminaRegistros("Productos", "IdProductos", Convert.ToInt32(comboId.SelectedItem));
                        break;
                    case "Empleados":
                        clsProcesaDatos.eliminaRegistros("Empleados", "IdEmpleado", Convert.ToInt32(comboId.SelectedItem));
                        break;
                    case "Clientes":
                        clsProcesaDatos.eliminaRegistros("Clientes", "IdCliente", Convert.ToInt32(comboId.SelectedItem));
                        break;
                    case "Ventas":
                        clsProcesaDatos.eliminaRegistros("Venta", "IdVenta", Convert.ToInt32(comboId.SelectedItem));
                        break;
                    case "Usuarios":
                        clsProcesaDatos.eliminaRegistros("Usuarios", "IdUsuario", Convert.ToInt32(comboId.SelectedItem));
                        break;
                }
                MessageBox.Show("¡ Registro borrado correctamente !");
                this.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
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
