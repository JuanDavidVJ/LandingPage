using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Sql;

namespace Landing_Page.Models
{
    public class mantenimientousuario
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into formulario (nombre, celular, email, ciudad ) values(@nombre, @celular, @email, @ciudad)", con);



            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);


            comando.Parameters["@nombre"].Value = usu.Nombre;
            comando.Parameters["@celular"].Value = usu.Celular;
            comando.Parameters["@email"].Value = usu.Email;
            comando.Parameters["@ciudad"].Value = usu.Ciudad;



            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public List<usuario> RecuperarTodos()
        {
            Conectar();
            List<usuario> usuario = new List<usuario>();

            SqlCommand com = new SqlCommand("select id, nombre, celular, email, ciudad from formulario", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {


                usuario usu = new usuario
                {
                    Id = Convert.ToInt32(registros["id"]),
                    Nombre = registros["nombre"].ToString(),
                    Celular = registros["celular"].ToString(),
                    Email = registros["email"].ToString(),
                    Ciudad = registros["ciudad"].ToString(),


                };

                usuario.Add(usu);

            }
            con.Close();
            return usuario;
        }



        public usuario Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, nombre, celular, email, ciudad  from formulario where id = @id", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            usuario usuario = new usuario();

            if (registros.Read())
            {
                usuario.Id = Convert.ToInt32(registros["id"]);
                usuario.Nombre = registros["nombre"].ToString();
                usuario.Celular = registros["celular"].ToString();
                usuario.Email = registros["email"].ToString();
                usuario.Ciudad = registros["ciudad"].ToString();


            }
            con.Close();
            return usuario;
        }

        public int Modificar(usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update formulario set nombre=@nombre, celular=@celular, email=@email, ciudad=@ciudad, edad=@edad  where id=@id", con);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = usu.Id;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.Nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.Celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.Email;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.Ciudad;






            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from formulario where id=@id", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}