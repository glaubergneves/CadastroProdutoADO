namespace CadastroProduto.Api.Models
{
    public class Produto
    {   
        public long Id { get; set; }
        public string Descricao { get; set; }
        public Produto(long id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
