using System.Collections.Generic;

namespace Heitor.API.Data
{
    public interface IProdutoRepository
    {
         void Inserir(Produto produto);

         void Editar(Produto produto);

         void Excluir(Produto produto);

         Produto Obter(int Id);

         IEnumerable<Produto> Obter();
    }
}