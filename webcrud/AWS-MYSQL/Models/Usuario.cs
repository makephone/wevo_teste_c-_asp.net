using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AWS_MYSQL.Models
{
    public class Usuario
    {

        private const string CONN_STRING = @"server=localhost;userid=root;password=;database=wevo";

        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }

        public string telefone { get; set; }
        public string sexo { get; set; }
        public DateTime dataNascimento { get; set; }

        public bool Novo
        {
            get { return id <= 0; }
        }


        public Usuario()
        {
            dataNascimento = DateTime.Now.Date;

        }

        public bool Salvar()
        {
            if (Novo)
                return Inserir();
            else
                return Editar();

        }

        private bool Inserir()
        {
            MySqlConnection conn = null;

            conn = new MySqlConnection(CONN_STRING);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO clientes (nome, email, dataNascimento,cpf,telefone,sexo) values (@nome, @email, @dataNascimento,@cpf,@telefone,@sexo)";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@nome", this.nome);
            cmd.Parameters.AddWithValue("@email", this.email);
            cmd.Parameters.AddWithValue("@cpf", this.cpf);
            cmd.Parameters.AddWithValue("@telefone", this.telefone);
            cmd.Parameters.AddWithValue("@sexo", this.sexo);
            cmd.Parameters.AddWithValue("@dataNascimento", this.dataNascimento);

            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }

        private bool Editar()
        {
            MySqlConnection conn = null;

            conn = new MySqlConnection(CONN_STRING);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE clientes SET nome=@nome,cpf=@cpf,telefone=@telefone,sexo=@sexo ,email=@email, dataNascimento=@dataNascimento WHERE id=@id";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@nome", this.nome);
            cmd.Parameters.AddWithValue("@email", this.email);
            cmd.Parameters.AddWithValue("@cpf", this.cpf);
            cmd.Parameters.AddWithValue("@telefone", this.telefone);
            cmd.Parameters.AddWithValue("@sexo", this.sexo);
            cmd.Parameters.AddWithValue("@dataNascimento", this.dataNascimento);
            cmd.Parameters.AddWithValue("@id", this.id);


            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }

        public static bool Deletar(int id)
        {
            MySqlConnection conn = null;

            conn = new MySqlConnection(CONN_STRING);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"DELETE FROM usuario where id=@id";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();

            return true;
        }

        public static List<Usuario> Listar()
        {

            MySqlConnection conn = null;

            conn = new MySqlConnection(CONN_STRING);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM clientes";
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Usuario> registros = new List<Usuario>();
            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.id = (int)reader["Id"];
                usuario.nome = (string)reader["Nome"];
                usuario.email = (string)reader["Email"];
                usuario.dataNascimento = (DateTime)reader["DataNascimento"];

                registros.Add(usuario);
            }

            reader.Close();
            conn.Close();

            return registros;


        }


        public static Usuario RecuperarUsuario(int id)
        {

            MySqlConnection conn = null;

            conn = new MySqlConnection(CONN_STRING);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM clientes WHERE id=@id";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            Usuario usuario = new Usuario();
            while (reader.Read())
            {
                usuario.id = (int)reader["Id"];
                usuario.nome = (string)reader["Nome"];
                usuario.email = (string)reader["Email"];
                usuario.dataNascimento = (DateTime)reader["DataNascimento"];
                usuario.telefone = (string)reader["Telefone"];
                usuario.cpf = (string)reader["Cpf"];
                usuario.sexo = (string)reader["Sexo"];

            }

            reader.Close();
            conn.Close();

            return usuario;

        }
    }
}