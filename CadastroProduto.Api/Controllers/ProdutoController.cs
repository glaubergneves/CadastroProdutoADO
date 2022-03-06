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
        public IEnumerable<Produto> Get()
        {
            return _produtoService.ObterProdutos();
        }

        [HttpGet("id")]
        public Produto? Get(long id)
        {
            return _produtoService.ObterProdutoPorId(id);
        }
    }
}
