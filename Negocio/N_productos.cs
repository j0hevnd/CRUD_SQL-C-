using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Data;
using System.Security.Cryptography;

namespace Negocio
{
    public class N_productos
    {
        private Consultas objeto = new Consultas();

        // Mostrar
        public DataTable MostarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.Mostrar();
            return tabla;
        }
        // Insertar
        public void InsetarProducto(string nombre, string descripcion, string marca, string precio, string stock)
        {

            objeto.Insertar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }
        // Editar
        public void EditarProducto(string nombre, string descripcion, string marca, string precio, string stock, string id)
        {
            objeto.Editar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }
        //Eliminar
        public void EliminarProducto(string id)
        {
            objeto.Eliminar(Convert.ToInt32(id));
        }
    }
}
