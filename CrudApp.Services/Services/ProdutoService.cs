using CrudApp.Data.Repositories;
using CrudApp.Domain.Entities;

namespace CrudApp.Services.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<IEnumerable<Produto>> GetAllAsync() => _produtoRepository.GetAllAsync();

        public Task<Produto?> GetByIdAsync(int id) => _produtoRepository.GetByIdAsync(id);

        public async Task AddAsync(Produto produto)
        {
            if (produto.Preco <= 0) throw new ArgumentException("Preço deve ser maior que zero.");
            await _produtoRepository.AddAsync(produto);
        }

        public Task UpdateAsync(Produto produto) => _produtoRepository.UpdateAsync(produto);

        public Task DeleteAsync(int id) => _produtoRepository.DeleteAsync(id);
    }
}
