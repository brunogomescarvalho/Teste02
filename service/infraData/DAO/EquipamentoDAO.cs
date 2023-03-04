using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.model;
using System.Data.SqlClient;

namespace infraData.DAO
{
    public class EquipamentoDAO
    {
        private const string _connectionString = @"server=.\SQLexpress;initial catalog=CONTROLE_DA_LOJA;integrated security=true";

        public bool Cadastrar(Equipamento equipamento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string insert = @"INSERT INTO EQUIPAMENTO 
                    (NOME, PRECO, NR_SERIE, DATA_FABRICACAO,FABRICANTE)
                    VALUES 
                    (@NOME, @PRECO, @NR_SERIE, @DATA_FABRICACAO, @FABRICANTE)";

                    ConverteObjetoEmSql(equipamento, command);

                    command.CommandText = insert;

                    return command.ExecuteNonQuery() != 0;

                }
            }
        }

        public Equipamento BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT ID, NOME, PRECO, NR_SERIE, DATA_FABRICACAO,FABRICANTE
                    FROM EQUIPAMENTO WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.CommandText = select;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        return ConverteSqlEmObjeto(reader);
                    }
                }
                return null!;
            }

        }



        public List<Equipamento> BuscarTodos()
        {
            List<Equipamento> equipamentos = new List<Equipamento>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT ID, NOME, PRECO, NR_SERIE, DATA_FABRICACAO,FABRICANTE
                    FROM EQUIPAMENTO";

                    command.CommandText = select;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Equipamento e = ConverteSqlEmObjeto(reader);
                        equipamentos.Add(e);
                    }
                }
            }
            return equipamentos;
        }

        public bool Editar(Equipamento equipamento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string upDate = @"UPDATE EQUIPAMENTO SET 
                    NOME = @NOME, 
                    PRECO = @PRECO, 
                    NR_SERIE = @NR_SERIE, 
                    DATA_FABRICACAO = @DATA_FABRICACAO,
                    FABRICANTE = @FABRICANTE
                    WHERE ID = @ID";

                    ConverteObjetoEmSql(equipamento, command);

                    command.CommandText = upDate;

                    return command.ExecuteNonQuery() != 0;

                }
            }
        }
        public bool Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string delete = @"DELETE FROM EQUIPAMENTO WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.CommandText = delete;

                    return command.ExecuteNonQuery() > 0;

                }
            }
        }

        private static void ConverteObjetoEmSql(Equipamento equipamento, SqlCommand command)
        {
            command.Parameters.AddWithValue("@ID", equipamento.Id);
            command.Parameters.AddWithValue("@NOME", equipamento.Nome);
            command.Parameters.AddWithValue("@PRECO", equipamento.Preco);
            command.Parameters.AddWithValue("@NR_SERIE", equipamento.NrSerie);
            command.Parameters.AddWithValue("@DATA_FABRICACAO", equipamento.DataFabricacao);
            command.Parameters.AddWithValue("@FABRICANTE", equipamento.Fabricante);
        }

        private Equipamento ConverteSqlEmObjeto(SqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"].ToString());
            string nome = (reader["NOME"]).ToString()!;
            double preco = Convert.ToDouble(reader["PRECO"].ToString());
            string nrSerie = (reader["NR_SERIE"]).ToString()!;
            DateTime dataFabricacao = Convert.ToDateTime(reader["DATA_FABRICACAO"].ToString());
            string fabricante = (reader["FABRICANTE"]).ToString()!;

            return new Equipamento(id, nome, preco, nrSerie, dataFabricacao, fabricante);
        }

    }
}