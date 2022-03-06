using CadastroProduto.Api.Dtos;
using CadastroProduto.Api.Models;
using CadastroProduto.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet(Name = "GetProdutos")]
        public IEnumerable<ConsultaProdutoDto> Get()
        {
            return _produtoService.ObterProdutos();
        }

        [HttpGet("id")]
        public Produto? Get(long id)
        {
            return _produtoService.ObterProdutoPorId(id);
        }

        [HttpPost()]
        public bool Post(ProdutoDto produtoDto)
        {
            Produto produto = new Produto(produtoDto.Descricao);

            _produtoService.GravarProduto(produto);
            return true;
        }

        [HttpPut()]
        public bool Put(long id, ProdutoDto produtoDto)
        {
            Produto produto = new Produto(id, produtoDto.Descricao);

            _produtoService.AtualizarProduto(produto);
            return true;
        }

        [HttpDelete()]
        public bool Delete(long id)
        {
            _produtoService.DeletarProduto(id);
            return true;
        }

        [HttpPut("Desabilitar")]
        public bool Desabilitar(long id)
        {
            _produtoService.DesabilitarProduto(id);
            return true;
        }
    }
}
