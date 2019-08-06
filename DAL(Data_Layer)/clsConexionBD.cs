using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace DAL_Data_Layer_
{
    public class clsConexionBD
    {
        private static String Servidor = "localhost";
        private static String BaseDatos = "Sistema_de_Ventas";
        private static String User = "root";
        private static String Password = "toor";
        private static String CadConexion = "server =" + Servidor + ";database =" + BaseDatos + ";Uid =" + User + ";pwd=" + Password + ";";

        public static MySqlConnection ConexionBD()
        {
            //Creando un nuevo objeto para la conexión
            MySqlConnection conexion = new MySqlConnection(CadConexion);
            conexion.Open();
            return conexion;
        }

        public static DataTable ConsultaTabla(String tabla)
        {
            String consultaSQL = "SELECT * FROM " + tabla;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(consultaSQL, CadConexion);
            DataTable datosRecibidos = new DataTable();
            mySqlDataAdapter.Fill(datosRecibidos);
            return datosRecibidos;
        } 
    }
}
