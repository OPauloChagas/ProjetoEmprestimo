using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimo.Data.Models.Domain;
using ProjetoEmprestimo.Data.Repository;

namespace ProjetoEmprestimo.Controllers
{
	public class EmprestimoController : Controller
	{
		private readonly IEmprestimosRepository _emprestimosRepository;

		public EmprestimoController(IEmprestimosRepository emprestimosRepository)
		{
			_emprestimosRepository = emprestimosRepository;
		}

		public async Task<IActionResult> Index()
		{
			var emprestimos = await _emprestimosRepository.GetAllAsync();
			return View(emprestimos);
		}

		public IActionResult Cadastrar()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Cadastrar(Emprestimos emprestimos)
		{
			try
			{
				if (ModelState.IsValid)
				{
					bool addEmprestimo = await _emprestimosRepository.AddAsync(emprestimos);
					if (addEmprestimo)
					{
						return RedirectToAction("Index");
					}
				}
				return View();
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Editar(Emprestimos emprestimo)
		{
			try
			{
				if (ModelState.IsValid)
				{
					bool addEmprestimo = await _emprestimosRepository.UpdateAsync(emprestimo);
					if (addEmprestimo)
					{
						return RedirectToAction("Index");
					}
				}
				return View();
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpGet]
		public async Task<IActionResult> Editar(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}

			var emprestimo = await _emprestimosRepository.GetByIdAsync(id);
			return View(emprestimo);
		}

		[HttpGet]
		public async Task<IActionResult> Excluir(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}

			var emprestimo = await _emprestimosRepository.GetByIdAsync(id);
			return View(emprestimo);


		}
		[HttpPost]
		public async Task<IActionResult> Excluir(Emprestimos emp)
		{
			
			var emprestimo = await _emprestimosRepository.DeleteAsync(emp.Id);
			return RedirectToAction("Index");


		}
		public IActionResult Deletar()
		{
			return View();
		}
	}
}
