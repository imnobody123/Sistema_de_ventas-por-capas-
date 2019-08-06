using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace DAL_Data_Layer_
{
    public class classConsultasDML : clsConexionBD
    {
        public static void insertaProductos(String Nombre, String Descripcion, int Stock, double PrecioC, double PrecioV, String FechaV)
        {
            // **************************** MÉTODOS PARA INSERTAR. **************************** \\

            try
            {
                String consulta = "INSERT INTO Productos (Nombre, Descripcion, Stock, PrecioCompra, PrecioVenta, FechaVencimiento) " +
                        "VALUES (?Nombre, ?Descripcion, ?Stock, ?PrecioC, ?PrecioV, ?FechaV);";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?Nombre", Nombre);
                comando.Parameters.AddWithValue("?Descripcion", Descripcion);
                comando.Parameters.AddWithValue("?Stock", Stock);
                comando.Parameters.AddWithValue("?PrecioC", PrecioC);
                comando.Parameters.AddWithValue("?PrecioV", PrecioV);
                comando.Parameters.AddWithValue("?FechaV", FechaV);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void insertaEmpleados(String Nombre, String ApelldioP, String ApelldioM, String sexo, String EstadoCivil, String FechaN, String Direccion)
        {
            try
            {
                String consulta = "INSERT INTO Empleados (Nombre, ApellidoP, ApellidoM, Sexo, EstadoCivil, FechaN, Direccion) " +
                        "VALUES (?Nombre, ?ApellidoP, ?ApellidoM, ?Sexo, ?EstadoCivil, ?FechaN, ?Direccion);";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?Nombre", Nombre);
                comando.Parameters.AddWithValue("?ApellidoP", ApelldioP);
                comando.Parameters.AddWithValue("?ApellidoM", ApelldioM);
                comando.Parameters.AddWithValue("?Sexo", sexo);
                comando.Parameters.AddWithValue("?EstadoCivil", EstadoCivil);
                comando.Parameters.AddWithValue("?FechaN", FechaN);
                comando.Parameters.AddWithValue("?Direccion", Direccion);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void insertaClientes(String Nombre, String Apelldios, String Direccion, Int64 telefono)
        {
            try
            {
                String consulta = "INSERT INTO Clientes (Nombre, Apellidos, Direccion, Telefono) " +
                        "VALUES (?Nombre, ?Apellidos, ?Direccion, ?Telefono);";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?Nombre", Nombre);
                comando.Parameters.AddWithValue("?Apellidos", Apelldios);
                comando.Parameters.AddWithValue("?Direccion", Direccion);
                comando.Parameters.AddWithValue("?Telefono", telefono);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void insertaVentas(int IdEmpleado, int IdProductos, int IdCliente, int CantComprada, String TipoDoc, int NumDoc, String FechaVenta, double total)
        {
            try
            {
                String consulta = "INSERT INTO Venta (IdEmpleado, IdProductos, IdCliente, CantidadComprada, TipoDocumento, NumeroDocumento, FechaVenta, PrecioTotal) " +
                        "VALUES (?IdEmpleado, ?IdProductos, ?IdCliente, ?CantComprada, ?TipoDoc, ?NumDoc, ?FechaVenta, ?total);";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?IdEmpleado", IdEmpleado);
                comando.Parameters.AddWithValue("?IdProductos", IdProductos);
                comando.Parameters.AddWithValue("?IdCliente", IdCliente);
                comando.Parameters.AddWithValue("?CantComprada", CantComprada);
                comando.Parameters.AddWithValue("?TipoDoc", TipoDoc);
                comando.Parameters.AddWithValue("?NumDoc", NumDoc);
                comando.Parameters.AddWithValue("?FechaVenta", FechaVenta);
                comando.Parameters.AddWithValue("total", total);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void insertaUsuario(String Usuario, String ContrasenaCifrada)
        {
            try
            {
                String consulta = "INSERT INTO Usuarios (Usuario, Contrasena) " +
                        "VALUES (?Usuario, ?Contrasena);";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?Usuario", Usuario);
                comando.Parameters.AddWithValue("?Contrasena", ContrasenaCifrada);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        // **************************** MÉTODOS PARA ACTUALIZAR. **************************** \\

        public static void actualizaProductos(String id, String Nombre, String Descripcion, int Stock, double PrecioC, double PrecioV, String FechaV)
        {
            try
            {
                String consulta = "UPDATE Productos SET Nombre = ?Nombre, Descripcion = ?Descripcion, Stock = ?Stock, PrecioCompra = ?PrecioC," +
                    " PrecioVenta = ?PrecioV, FechaVencimiento = ?FechaV WHERE IdProductos = ?IdP;";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?IdP", id);
                comando.Parameters.AddWithValue("?Nombre", Nombre);
                comando.Parameters.AddWithValue("?Descripcion", Descripcion);
                comando.Parameters.AddWithValue("?Stock", Stock);
                comando.Parameters.AddWithValue("?PrecioC", PrecioC);
                comando.Parameters.AddWithValue("?PrecioV", PrecioV);
                comando.Parameters.AddWithValue("?FechaV", FechaV);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void actualizaEmpleados(String id, String Nombre, String ApeP, String ApeM, String Sexo, String EstadoCivil, String FechaN, String Dire)
        {
            try
            {
                String consulta = "UPDATE Empleados SET Nombre = ?Nombre, ApellidoP = ?ApeP, ApellidoM = ?ApeM, Sexo = ?Sexo, EstadoCivil = ?EstadoCivil" +
                    ", FechaN = ?FechaN, Direccion = ?Direccion WHERE IdEmpleado = ?IdE;";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?IdE", id);
                comando.Parameters.AddWithValue("?Nombre", Nombre);
                comando.Parameters.AddWithValue("?ApeP", ApeP);
                comando.Parameters.AddWithValue("?ApeM", ApeM);
                comando.Parameters.AddWithValue("?Sexo", Sexo);
                comando.Parameters.AddWithValue("?EstadoCivil", EstadoCivil);
                comando.Parameters.AddWithValue("?FechaN", FechaN);
                comando.Parameters.AddWithValue("?Direccion", Dire);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void actualizaClientes(String id, String Nombre, String Apellidos, String Direccion, Int64 Telefono)
        {
            try
            {
                String consulta = "UPDATE Clientes SET Nombre = ?Nombre, Apellidos = ?Apellidos, Direccion = ?Direccion, Telefono = ?Telefono" +
                    " WHERE IdCliente = ?IdE;";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?IdE", id);
                comando.Parameters.AddWithValue("?Nombre", Nombre);
                comando.Parameters.AddWithValue("?Apellidos", Apellidos);
                comando.Parameters.AddWithValue("?Direccion", Direccion);
                comando.Parameters.AddWithValue("?Telefono", Telefono);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void actualizaVenta(String id, int IdE, int IdP, int IdC, int CantComp, String Doc, int NumDoc, String FechaV, int PrecioT)
        {
            try
            {
                String consulta = "UPDATE Venta SET IdEmpleado = ?IdEmpleado, IdProductos = ?IdProductos, IdCliente = ?IdCliente, CantidadComprada = ?CantidadComprada" +
                    ", TipoDocumento = ?TipoDocumento, NumeroDocumento = ?NumeroDocumento, FechaVenta = ?FechaVenta, PrecioTotal = ?PrecioTotal" +
                    " WHERE IdVenta = ?IdV;";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?IdV", id);
                comando.Parameters.AddWithValue("?IdEmpleado", IdE);
                comando.Parameters.AddWithValue("?IdProductos", IdP);
                comando.Parameters.AddWithValue("?IdCliente", IdC);
                comando.Parameters.AddWithValue("?CantidadComprada", CantComp);
                comando.Parameters.AddWithValue("?TipoDocumento", Doc);
                comando.Parameters.AddWithValue("?NumeroDocumento", NumDoc);
                comando.Parameters.AddWithValue("?FechaVenta", FechaV);
                comando.Parameters.AddWithValue("?PrecioTotal", PrecioT);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void actualizaUsuario(String id, String Usuario, String Contrasena)
        {
            try
            {
                String consulta = "UPDATE Usuarios SET Usuario = ?Usuario, Contrasena = ?Contrasena" +
                    " WHERE IdUsuario = ?IdU;";
                MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
                comando.Parameters.AddWithValue("?IdU", id);
                comando.Parameters.AddWithValue("?Usuario", Usuario);
                comando.Parameters.AddWithValue("?Contrasena", Contrasena);

                comando.ExecuteNonQuery();
                ConexionBD().Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("" + error);
            }
        }

        public static void ActualizaId(String tabla, int PenultimoRegistro)
        {
            String consulta = "ALTER TABLE " + tabla + " AUTO_INCREMENT = ?PenultimoRegistro";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
            comando.Parameters.AddWithValue("?PenultimoRegistro", PenultimoRegistro);

            comando.ExecuteNonQuery();
            ConexionBD().Close();
        }

        // **************************** MÉTODOS PARA ELIMINAR. **************************** \\

        public static void EliminarRegistros(String tabla, String idCampoNombre, int Id)
        {
            String consulta = "DELETE FROM " + tabla + " WHERE " + idCampoNombre + " = ?id;" +
                "UPDATE " + tabla + " SET " + idCampoNombre + " = " + idCampoNombre + "-1 WHERE " + idCampoNombre + " > ?id;";
            MySqlCommand comando = new MySqlCommand(consulta, ConexionBD());
            comando.Parameters.AddWithValue("?id", Id);

            comando.ExecuteNonQuery();
            ConexionBD().Close();
        }
    }
}
