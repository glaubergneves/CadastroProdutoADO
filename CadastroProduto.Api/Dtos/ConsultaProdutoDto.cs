namespace CadastroProduto.Api.Dtos
{
    public class ConsultaProdutoDto
    {
        public string Descricao { get; set; }
        public string DataCriacao { get; set; } = $"yyyy-MM-dd";
        public string Status { get; set; }
    }
}
