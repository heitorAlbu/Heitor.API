using Heitor.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Heitor.API.Controllers
{
      [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private readonly IProdutoRepository Repositorio;

        public ProdutosController(IProdutoRepository repositorio)
        {
          Repositorio = repositorio;  
        }


        [HttpPost]
        public IActionResult Criar([FromBody]Produto produto)
        {
            Repositorio.Inserir(produto);

                return Ok();
        }
        [HttpGet]
        public IActionResult Obter()
        {
            var lista = Repositorio.Obter();

            return Ok(lista);
        }
        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            var produto = Repositorio.Obter(id);
                if(produto == null)
                {
                    return NotFound();
                }

               return Ok(produto); 
        }
        [HttpPut]
        public IActionResult Atualizar([FromBody]Produto produto)
        {
            var prod = Repositorio.Obter(produto.Id);
            if(prod == null)
            {
                return NotFound();    
            }
            Repositorio.Editar(produto);


            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var produto = Repositorio.Obter(id);

            if(produto == null)
            {
                return NotFound();
            }
            Repositorio.Excluir(produto);

            return Ok();
        }


    }
}