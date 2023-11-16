using ProjetoEmprestimo.Data.Models.Domain;

namespace ProjetoEmprestimo.Data.Repository
{
	public interface IEmprestimosRepository
	{
		Task<bool> AddAsync(Emprestimos emprestimos);
		Task<bool> UpdateAsync(Emprestimos emprestimos);
		Task<bool> DeleteAsync(int id);
		Task<Emprestimos?> GetByIdAsync(int id);
		Task<IEnumerable<Emprestimos?>> GetAllAsync();
	}
}