using domain.model;
using System.Data.SqlClient;

namespace infraData.DAO
{
    public class ChamadoDAO
    {
        private const string _connectionString = @"server=.\SQLexpress;initial catalog=CONTROLE_DA_LOJA;integrated security=true";

        public bool Cadastrar(Chamado chamado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string insert = @"INSERT INTO CHAMADO 
                    (TITULO, DESCRICAO, DATA_ABERTURA,EQUIPAMENTO)
                    VALUES 
                    (@TITULO, @DESCRICAO, @DATA_ABERTURA, @EQUIPAMENTO)";

                    ConverteObjetoEmSql(chamado, command);

                    command.CommandText = insert;

                    return command.ExecuteNonQuery() != 0;

                }
            }
        }

        public Chamado BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT C.TITULO, C.DESCRICAO, C.DATA_ABERTURA,
                    C.ID AS ID_CHAMADO, E.ID, E.NOME, E.PRECO, E.NR_SERIE, E.DATA_FABRICACAO, E.FABRICANTE
                    FROM CHAMADO C
                    INNER JOIN EQUIPAMENTO E ON (E.ID = C.EQUIPAMENTO)
                    WHERE C.ID = @ID";

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

        public void ExcluirChamadoPorEquipamento(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string delete = @" DELETE FROM CHAMADO WHERE EQUIPAMENTO = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.CommandText = delete;

                    command.ExecuteNonQuery();
                }
            }

        }

        public List<Chamado> BuscarTodos()
        {
            List<Chamado> chamados = new List<Chamado>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT C.TITULO, C.DESCRICAO, C.DATA_ABERTURA,
                    C.ID AS ID_CHAMADO, E.ID, E.NOME, E.PRECO, E.NR_SERIE, E.DATA_FABRICACAO, E.FABRICANTE
                    FROM CHAMADO C
                    INNER JOIN EQUIPAMENTO E ON (E.ID = C.EQUIPAMENTO)";

                    command.CommandText = select;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Chamado c = ConverteSqlEmObjeto(reader);
                        chamados.Add(c);
                    }
                }
            }
            return chamados;
        }



        public bool Editar(Chamado chamado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string upDate = @"UPDATE CHAMADO SET 
                    TITULO = @TITULO, 
                    DESCRICAO = @DESCRICAO, 
                    DATA_ABERTURA = @DATA_ABERTURA, 
                    EQUIPAMENTO = @EQUIPAMENTO
                    WHERE ID = @ID";

                    ConverteObjetoEmSql(chamado, command);

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

                    string insert = @"DELETE FROM CHAMADO WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.CommandText = insert;

                    return command.ExecuteNonQuery() > 0;

                }
            }
        }

        private static void ConverteObjetoEmSql(Chamado chamado, SqlCommand command)
        {
            command.Parameters.AddWithValue("@ID", chamado.Id);
            command.Parameters.AddWithValue("@TITULO", chamado.Titulo);
            command.Parameters.AddWithValue("@DESCRICAO", chamado.Descricao);
            command.Parameters.AddWithValue("@DATA_ABERTURA", chamado.DataAbertura);
            command.Parameters.AddWithValue("@EQUIPAMENTO", chamado.Equipamento.Id);

        }

        private Chamado ConverteSqlEmObjeto(SqlDataReader reader)
        {

            int id = Convert.ToInt32(reader["ID"].ToString());
            string nome = (reader["NOME"]).ToString()!;
            double preco = Convert.ToDouble(reader["PRECO"].ToString());
            string nrSerie = (reader["NR_SERIE"]).ToString()!;
            DateTime dataFabricacao = Convert.ToDateTime(reader["DATA_FABRICACAO"].ToString());
            string fabricante = (reader["FABRICANTE"]).ToString()!;

            var equipamento = new Equipamento(id, nome, preco, nrSerie, dataFabricacao, fabricante);

            int idC = Convert.ToInt32(reader["ID_CHAMADO"].ToString());
            string titulo = (reader["TITULO"]).ToString()!;
            string descricao = (reader["DESCRICAO"]).ToString()!;
            DateTime dataAbertura = Convert.ToDateTime(reader["DATA_ABERTURA"].ToString());


            return new Chamado(idC, titulo, descricao, equipamento, dataAbertura);
        }

    }
}