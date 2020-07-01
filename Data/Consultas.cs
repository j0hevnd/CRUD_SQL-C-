using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class Consultas
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        // MÉTODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable Mostrar()
        {
            // TRANSAC SQL
            /*comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM productos";
            leer = comando.ExecuteReader(); // ExecuteReader Devuelve filas 
            tabla.Load(leer); // Llenamos nuestra tabla con lo que encuentre
            conexion.CerrarConexion();

            return tabla;*/

            // PROCEDIMIENTO
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure; // para especificar que estamos ejecutando un proceso de almacenado
            leer = comando.ExecuteReader(); // ExecuteReader Devuelve filas 
            tabla.Load(leer); // Llenamos nuestra tabla con lo que encuentre
            conexion.CerrarConexion();
            return tabla;

        }

        // AGREGAR PRODUCTOS
        public void Insertar(string nombre, string descripcion, string marca, double precio, int stock)
        {

            comando.Connection = conexion.AbrirConexion();
            // comando.CommandText = "INSERT INTO productos VALUES ('" + nombre + "', '" + descripcion + "', '" + marca + "', " + precio + ", " + stock + " )";
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.ExecuteNonQuery(); // Ejecuta insert, Update, Delete
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // EDITAR PRODUCTOS
        public void Editar(string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery(); // Ejecuta insert, Update, Delete
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // ELIMINAR DE LA TABLA
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery(); 
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
