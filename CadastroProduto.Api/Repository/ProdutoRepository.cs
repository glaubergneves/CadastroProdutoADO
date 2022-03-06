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
            }

            return produtos;
        }

        public Produto? ObterPorId(long id)
        {
            var produtos = new List<Produto>
            {
                new Produto(0, "farinha"),
                new Produto(1, "Açucar"),
                new Produto(id:2, descricao:"Sal")
            };
            Produto? produto = produtos.FirstOrDefault(x => x.Id == id);

            return produto;
        }
    }
}
