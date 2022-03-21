using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Obabox_test.Models
{
    public class EstudanteTesteEduardo
    {
        public int Identificador { get; set; } 
        public string Nome { get; set; }
        public string Curso { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }

        public class Filtro 
        {
            public string Identificador { get; set; }
            public string Nome { get; set; }
            public string Curso { get; set; }
            public int Status { get; set; }

        }

        public static List<EstudanteTesteEduardo> SelecionarFiltro(Filtro Filtro)
        {
            SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);

            EstudanteTesteEduardo Estudante = new EstudanteTesteEduardo();
            List<EstudanteTesteEduardo> ListaEstudantes = new List<EstudanteTesteEduardo>();
            try
            {
                using (SqlCommand sql = new SqlCommand("[dbo].[spo_EstudanteTesteEduardo_SelecionarFiltro]", conexao))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(Filtro.Identificador))
                        sql.Parameters.AddWithValue("@Identificador", Filtro.Identificador);
                    else
                        sql.Parameters.AddWithValue("@Identificador", DBNull.Value);

                    if (!string.IsNullOrEmpty(Filtro.Nome))
                        sql.Parameters.AddWithValue("@Nome", Filtro.Nome);
                    else
                        sql.Parameters.AddWithValue("@Nome", DBNull.Value);

                    if (!string.IsNullOrEmpty(Filtro.Curso))
                        sql.Parameters.AddWithValue("@Curso", Filtro.Curso);
                    else
                        sql.Parameters.AddWithValue("@Curso", DBNull.Value);
               
                        sql.Parameters.AddWithValue("@Status", Filtro.Status);
                    
                 
                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    SqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {
                        Estudante = new EstudanteTesteEduardo();

                        if (dr["Identificador"] != DBNull.Value)
                            Estudante.Identificador = Convert.ToInt32(dr["Identificador"]);

                        if (dr["Nome"] != DBNull.Value)
                            Estudante.Nome = Convert.ToString(dr["Nome"]);

                        if (dr["Curso"] != DBNull.Value)
                            Estudante.Curso = Convert.ToString(dr["Curso"]);

                        if (dr["DataNascimento"] != DBNull.Value)
                            Estudante.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);

                        if (dr["Status"] != DBNull.Value)
                            Estudante.Status = Convert.ToBoolean(dr["Status"]);

                        ListaEstudantes.Add(Estudante);
                    }
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }

            return ListaEstudantes;
        }

        public static EstudanteTesteEduardo Selecionar(int Identificador)
        {
            SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);

            EstudanteTesteEduardo Estudante = new EstudanteTesteEduardo();
            try
            {
                using (SqlCommand sql = new SqlCommand("[dbo].[spo_EstudanteTesteEduardo_Selecionar]", conexao))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                        sql.Parameters.AddWithValue("@Identificador", Identificador);
                   

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();

                    SqlDataReader dr = sql.ExecuteReader();

                    while (dr.Read())
                    {

                        if (dr["Identificador"] != DBNull.Value)
                            Estudante.Identificador = Convert.ToInt32(dr["Identificador"]);

                        if (dr["Nome"] != DBNull.Value)
                            Estudante.Nome = Convert.ToString(dr["Nome"]);

                        if (dr["Curso"] != DBNull.Value)
                            Estudante.Curso = Convert.ToString(dr["Curso"]);

                        if (dr["DataNascimento"] != DBNull.Value)
                            Estudante.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);

                        if (dr["Status"] != DBNull.Value)
                            Estudante.Status = Convert.ToBoolean(dr["Status"]);

                    }
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }

            return Estudante;
        }

        public static string Inserir(EstudanteTesteEduardo Estudante)
        {
            SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            string Identificador= string.Empty;
            try
            {
                using (SqlCommand sql = new SqlCommand("[dbo].[spo_EstudanteTesteEduardo_Inserir]", conexao))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                  

                    if (!string.IsNullOrEmpty(Estudante.Nome))
                        sql.Parameters.AddWithValue("@Nome", Estudante.Nome);
                    else
                        sql.Parameters.AddWithValue("@Nome", DBNull.Value);

                    if (!string.IsNullOrEmpty(Estudante.Curso))
                        sql.Parameters.AddWithValue("@Curso", Estudante.Curso);
                    else
                        sql.Parameters.AddWithValue("@Curso", DBNull.Value);

                    if (Estudante.DataNascimento != default(DateTime))
                        sql.Parameters.AddWithValue("@DataNascimento", Estudante.DataNascimento);
                    else
                        sql.Parameters.AddWithValue("@DataNascimento", DBNull.Value);

                    sql.Parameters.AddWithValue("@Status", Estudante.Status);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open();
                    Identificador = sql.ExecuteScalar().ToString();
                 
                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }

            return Identificador;
        }

        public static void Alterar(EstudanteTesteEduardo Estudante)
        {
            SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
            try
            {
                using (SqlCommand sql = new SqlCommand("[dbo].[spo_EstudanteTesteEduardo_Alterar]", conexao))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    if (Estudante.Identificador != default(int))
                        sql.Parameters.AddWithValue("@Identificador", Estudante.Identificador);
                    else
                        sql.Parameters.AddWithValue("@Identificador", DBNull.Value);
                    if (!string.IsNullOrEmpty(Estudante.Nome))
                        sql.Parameters.AddWithValue("@Nome", Estudante.Nome);
                    else
                        sql.Parameters.AddWithValue("@Nome", DBNull.Value);

                    if (!string.IsNullOrEmpty(Estudante.Curso))
                        sql.Parameters.AddWithValue("@Curso", Estudante.Curso);
                    else
                        sql.Parameters.AddWithValue("@Curso", DBNull.Value);

                    if (Estudante.DataNascimento != default(DateTime))
                        sql.Parameters.AddWithValue("@DataNascimento", Estudante.DataNascimento);
                    else
                        sql.Parameters.AddWithValue("@DataNascimento", DBNull.Value);

                    sql.Parameters.AddWithValue("@Status", Estudante.Status);

                    if (conexao.State == System.Data.ConnectionState.Closed)
                        conexao.Open(); 
                    
                    sql.ExecuteNonQuery();

                }
            }
            catch (Exception err)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();

                //throw err;
            }
            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
            
        }

    }
}