using CadastroProduto.Api.Dtos;
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

        public IEnumerable<ConsultaProdutoDto> ObterProdutos()
        {
            return _produtoRepository.Listar();
        }

        public Produto? ObterProdutoPorId(long id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public void GravarProduto(Produto produto)
        {
            _produtoRepository.Gravar(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            _produtoRepository.Atualizar(produto);
        }

        internal void DeletarProduto(long id)
        {
            _produtoRepository.Deletar(id);
        }

        internal void DesabilitarProduto(long id)
        {
            _produtoRepository.Desabilitar(id);
        }
    }
}
