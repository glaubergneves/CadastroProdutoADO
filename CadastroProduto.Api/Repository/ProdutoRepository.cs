using CadastroProduto.Api.Models;
using System.Data;
using System.Data.SqlClient;

namespace CadastroProduto.Api.Repository
{
    public class ProdutoRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Dev\ProjetoCadastroProduto\CadastroProduto\Infraestrutura\Datas\ProdutoDB.mdf;Integrated Security=True";

        public IEnumerable<Produto> Listar()
        {
            var produtos = new List<Produto>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var sql = @"select Id,Descricao from Produto";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                SqlDataReader sdr = sqlCommand.ExecuteReader();

                while (sdr.Read())
                {
                    var produto = new Produto(Convert.ToInt64(sdr["Id"]), sdr["Descricao"].ToString());

                    produtos.Add(produto);
                }

                sqlConnection.Close();
            }

            return produtos;
        }

        public Produto? ObterPorId(long id)
        {
            Produto produto = null;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                var sql = @"Select Id, Descricao from produto where id = @id";

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
