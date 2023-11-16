namespace ProjetoEmprestimo.Models
{
	public class EmprestimosModel
	{

		private EmprestimosModel() { }

		public EmprestimosModel(string recebedor, string fornecedor, string livro)
		{
			Recebedor = recebedor;
			Fornecedor = fornecedor;
			Livro = livro;
		}
		public int Id { get; set; }
		public string? Recebedor { get; set; }
		public string? Fornecedor { get; set; }
		public string? Livro { get; set; }
		public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
	}
}
