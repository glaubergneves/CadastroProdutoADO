using CadastroProduto.Api.Dtos;
using CadastroProduto.Api.Models;
using System.Data;
using System.Data.SqlClient;

namespace CadastroProduto.Api.Repository
{
    public class ProdutoRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Dev\ProjetoCadastroProduto\CadastroProduto\Infraestrutura\Datas\ProdutoDB.mdf;Integrated Security=True";

        public IEnumerable<ConsultaProdutoDto> Listar()
        {
            var produtos = new List<ConsultaProdutoDto>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var sql = @"select Id, Descricao, DataCriacao, case when status = 0 then 'Inativo' else 'Ativo' end status from Produto";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                SqlDataReader sdr = sqlCommand.ExecuteReader();

                while (sdr.Read())
                {
                    var produto = new ConsultaProdutoDto
                    {
                        Descricao = sdr["Descricao"].ToString(),
                        DataCriacao = sdr["DataCriacao"].ToString(),
                        Status = sdr["Status"].ToString()
                    };

                    produtos.Add(produto);
                }

                sqlConnection.Close();
            }

            return produtos;
        }

        public void Desabilitar(long id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                var sql = @"UPDATE PRODUTO SET STATUS = 0 WHERE ID = @Id";

                SqlCommand cmd = new SqlCommand(@sql, sqlCon);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);
                sqlCon.Open();

                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void Deletar(long id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                var sql = @"DELETE FROM PRODUTO WHERE ID = @Id";

                SqlCommand cmd = new SqlCommand(@sql, sqlCon);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);
                sqlCon.Open();

                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void Atualizar(Produto produto)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                var sql = @"UPDATE PRODUTO SET DESCRICAO = @Descricao WHERE ID = @Id";

                SqlCommand cmd = new SqlCommand(@sql, sqlCon);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                sqlCon.Open();

                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void Gravar(Produto produto)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                var sql = @"INSERT INTO PRODUTO (Descricao, DataCriacao, Status) VALUES (@Descricao, @DataCriacao, @Status)";

                SqlCommand cmd = new SqlCommand(@sql, sqlCon);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@DataCriacao", produto.DataCriacao);
                cmd.Parameters.AddWithValue("@Status", produto.Status);
                sqlCon.Open();

                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public Produto? ObterPorId(long id)
        {
            Produto produto = null;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                var sql = @"select Id, Descricao, DataCriacao, case when status = 0 then 'Inativo' else 'Ativo' end status from Produto where id = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                sqlCon.Open();

                var sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    produto = new Produto(Convert.ToInt64(sdr["Id"]), sdr["Descricao"].ToString());
                }
                sqlCon.Close();
            }

            return produto;
        }
    }
}
