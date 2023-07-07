using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            // conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Catalogo_Articulos; integrated security=true ");
            conexion = new SqlConnection("server=localhost; database=Catalogo_Articulos;User Id=sa; password=fakePassw0rd");
            comando = new SqlCommand();
        }

        public void setQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }



        public void setearSp(string Sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = Sp;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ClearQuery()
        {
            comando.CommandText = "";
        }
        public void ejecutar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SqlDataReader sqlLector
        {
            get { return lector; }
        }
        public void ejecutarConeccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void cerrar()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
