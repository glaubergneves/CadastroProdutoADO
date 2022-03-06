using CadastroProduto.Api.Models;
using CadastroProduto.Api.Repository;

namespace CadastroProduto.Api.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;
        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            return _produtoRepository.Listar();
        }

        public Produto? ObterProdutoPorId(long id)
        {
            return _produtoRepository.ObterPorId(id);
        }
    }
}
