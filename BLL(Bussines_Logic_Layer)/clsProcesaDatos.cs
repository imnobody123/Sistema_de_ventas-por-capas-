using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using System.Diagnostics;
using DAL_Data_Layer_;

namespace BLL_Bussines_Logic_Layer_
{
    public class clsProcesaDatos
    {
        // **************************** MÉTODOS PARA INSERTAR. **************************** \\

        //  Los siguientes métodos convierten los tipos de dato para luego
        //  invocar al método que los inserta en su respectiva tabla.

        public static void insertaProductos(String campo1, String campo2, String campo3, String campo4, String campo5, String campo6)
        {
            ActualizaId("Productos", "IdProductos");
            classConsultasDML.insertaProductos(campo1, campo2, Convert.ToInt32(campo3), Convert.ToDouble(campo4), Convert.ToDouble(campo5), campo6);
        }

        public static void InsertaEmpleados(String campo1, String campo2, String campo3, String campo4, String campo5, String campo6, String campo7)
        {
            ActualizaId("Empleados", "IdEmpleado");
            classConsultasDML.insertaEmpleados(campo1, campo2, campo3, campo4, campo5, campo6, campo7);
        }

        public static void InsertaClientes(String campo1, String campo2, String campo3, String campo4)
        {
            ActualizaId("Clientes", "IdCliente");
            classConsultasDML.insertaClientes(campo1, campo2, campo3, Convert.ToInt64(campo4));
        }

        public static void InsertaVenta(String campo1, String campo2, String campo3, String campo4, String campo5, String campo6, string campo7, string campo8)
        {
            ActualizaId("Venta", "IdVenta");
            classConsultasDML.insertaVentas(Convert.ToInt32(campo1), Convert.ToInt32(campo2), Convert.ToInt32(campo3), Convert.ToInt32(campo4), campo5, Convert.ToInt32(campo6), campo7, Convert.ToDouble(campo8));
        }

        public static void InsertaUsuario(String campo1, String campo2)
        {
            ActualizaId("Usuarios", "IdUsuario");
            MD5 md5Hash = MD5.Create();
            String campo2Cifrado = GetMd5Hash(md5Hash, campo2);
            classConsultasDML.insertaUsuario(campo1, campo2Cifrado);
        }

        // **************************** MÉTODOS PARA ACTUALIZAR. **************************** \\

        //  Los siguientes métodos convierten los tipos de dato para luego
        //  invocar al método que los actualiza en su respectiva tabla.

        public static void ActualizaProductos(String campo1, String campo2, String campo3, String campo4, String campo5, String campo6, String campo7)
        {
            String[] campo7NuevoFormato = campo7.Split('/');
            campo7 = campo7NuevoFormato[2] + "-" + campo7NuevoFormato[1] + "-" + campo7NuevoFormato[0];
            classConsultasDML.actualizaProductos(campo1, campo2, campo3, Convert.ToInt32(campo4), Convert.ToDouble(campo5), Convert.ToDouble(campo6), campo7);
        }

        public static void ActualizaEmpleados(String campo1, String campo2, String campo3, String campo4, String campo5, String campo6, String campo7, String campo8)
        {
            String[] campo7NuevoFormato = campo7.Split('/');
            campo7 = campo7NuevoFormato[2] + "-" + campo7NuevoFormato[1] + "-" + campo7NuevoFormato[0];
            classConsultasDML.actualizaEmpleados(campo1, campo2, campo3, campo4, campo5, campo6, campo7, campo8);
        }

        public static void ActualizaClientes(String campo1, String campo2, String campo3, String campo4, String campo5)
        {
            classConsultasDML.actualizaClientes(campo1, campo2, campo3, campo4, Convert.ToInt64(campo5));
        }

        public static void ActualizaVenta(String campo1, String campo2, String campo3, String campo4, String campo5, String campo6, String campo7, String campo8, String campo9)
        {
            String[] campo8NuevoFormato = campo8.Split('/');
            campo8 = campo8NuevoFormato[2] + "-" + campo8NuevoFormato[1] + "-" + campo8NuevoFormato[0];
            classConsultasDML.actualizaVenta(campo1, Convert.ToInt32(campo2), Convert.ToInt32(campo3), Convert.ToInt32(campo4), Convert.ToInt32(campo5), campo6, Convert.ToInt32(campo7), campo8, Convert.ToInt32(campo9));
        }

        public static void ActualizaUsuario(String campo1, String campo2, String campo3)
        {
            MD5 md5Hash = MD5.Create();
            String campo3Cifrado = GetMd5Hash(md5Hash, campo3);
            classConsultasDML.actualizaUsuario(campo1, campo2, campo3Cifrado);
        }

        public static void ActualizaId(String tablaCategoria, String IdTablaNombre)
        {
            DataTable tabla = Recuperatabla(tablaCategoria);
            if (tabla.Rows.Count > 0)
            {
                int Siguiente_Registro = tabla.Rows[(tabla.Rows.Count) - 1].Field<Int32>(IdTablaNombre) + 1;
                classConsultasDML.ActualizaId(tablaCategoria, Siguiente_Registro);
            }
            else
            {
                classConsultasDML.ActualizaId(tablaCategoria, 1);
            }
        }

        // **************************** MÉTODO QUE ELIMINA REGISTROS DE TABLAS DE UNA BD. **************************** \\
        public static void eliminaRegistros(String tabla, String NombreCampoId, int IdCampo)
        {
            classConsultasDML.EliminarRegistros(tabla, NombreCampoId, IdCampo);
        }

        // **************************** MÉTODO QUE RECUPERA TABLAS DE UNA BD. **************************** \\
        public static DataTable Recuperatabla(String NombreTabla)
        {
            DataTable tablaObtenida = clsConexionBD.ConsultaTabla(NombreTabla);
            return tablaObtenida;
        }

        // **************************** MÉTODOS PARA VALIDAR INICIO DE SESIÓN. ****************************
        public static Boolean VerificarDatos(String Usuario, String ContraNoCifrada)
        {
            Boolean existData = false;
            DataTable datosTabla = clsConexionBD.ConsultaTabla("Usuarios");

            MD5 md5Hash = MD5.Create();
            String ContraCifrada = GetMd5Hash(md5Hash, ContraNoCifrada);

            //  Recorremos la tabla usuarios buscando el user y el password
            //  Y devolvemos un true si es que los datos existen
            for (int i = 0; i < datosTabla.Rows.Count; i++)
            {
                String CampoUsuario = datosTabla.Rows[i].Field<String>("Usuario");
                String CampoContra = datosTabla.Rows[i].Field<String>("Contrasena");

                if (CampoUsuario.Equals(Usuario) && CampoContra.Equals(ContraCifrada))
                {
                    existData = true;

                    //  Se rompe el ciclo al encontrar los datos
                    i = datosTabla.Rows.Count;
                }
            }
            return existData;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            //  Convierte el string de entrada a un arreglo de byte y computa el hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            //  Crea un nuevo stringbuilder para recolectar los bytes
            //  y crea un string.
            StringBuilder sBuilder = new StringBuilder();

            //  Mediante el ciclo cada byte de los datos son hasheados
            //  Y formatea cada uno como un string hexadecimal.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Retorna el string en hexadecimal.
            return sBuilder.ToString();
        }
    }
}
