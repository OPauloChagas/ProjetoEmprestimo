using ProjetoEmprestimo.Data.DataAccess;
using ProjetoEmprestimo.Data.Models.Domain;

namespace ProjetoEmprestimo.Data.Repository
{
	public class EmprestimosRepository : IEmprestimosRepository
	{
		private readonly ISqlDataAccess _db;
		public EmprestimosRepository(ISqlDataAccess db)
		{
			_db = db;
		}
		public async Task<bool> AddAsync(Emprestimos emprestimos)
		{
			try
			{
				await _db.SaveData("sp_create_emprestimo", new { emprestimos.Recebedor, emprestimos.Fornecedor, emprestimos.Livro });
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}


		public async Task<bool> UpdateAsync(Emprestimos emprestimos)
		{
			try
			{
				await _db.SaveData("sp_update_emprestimo", new { emprestimos.Id, emprestimos.Recebedor, emprestimos.Fornecedor, emprestimos.Livro });
				return true;
			}
			catch (Exception ex) { return false; }

		}

		public async Task<bool> DeleteAsync(int id)
		{
			try
			{
				await _db.SaveData("sp_delete_emprestimo", new { Id = id });
				return true;
			}
			catch (Exception ex) { return false; }

		}

		public async Task<Emprestimos?> GetByIdAsync(int Id)
		{
			IEnumerable<Emprestimos> result = await _db.GetData<Emprestimos, dynamic>
			("sp_get_emprestimo", new { Id = Id });
			return result.FirstOrDefault();
		}

		public async Task<IEnumerable<Emprestimos?>> GetAllAsync()
		{
			string query = "sp_get_emprestimos";
			return await _db.GetData<Emprestimos, dynamic>(query, new { });
		}
	}
}
