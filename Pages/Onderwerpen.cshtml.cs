using BonjeMetBonten.Data;
using BonjeMetBonten.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonjeMetBonten.Pages
{
	public class OnderwerpenModel : PageModel
	{
		public ICollection<Onderwerp> Onderwerpen { get; set; }

		private VideoDbContext DbContext;

		public OnderwerpenModel(VideoDbContext injectedContext)
		{
			DbContext = injectedContext;
		}
		public void OnGet()
		{
			Onderwerpen = DbContext.Onderwerpen.ToList();
		}
	}
}
