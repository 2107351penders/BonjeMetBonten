using System.ComponentModel.DataAnnotations;
using BonjeMetBonten.Data;
using BonjeMetBonten.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonjeMetBonten.Pages
{
	public class OnderwerpenModel : PageModel
	{
		public ICollection<Onderwerp> Onderwerpen { get; set; }
		[BindProperty]
		[Required(ErrorMessage = "Nieuw onderwerp mag niet leeg zijn!")]
		public string? nieuwOnderwerp { get; set; }
		private VideoDbContext DbContext;

		public OnderwerpenModel(VideoDbContext injectedContext)

		{
			DbContext = injectedContext;
		}
		public void OnGet()
		{
			Onderwerpen = DbContext.Onderwerpen.ToList();
		}

		public IActionResult OnGetVerwijderOnderwerp(int id)
		{
			Onderwerp Onderwerp = DbContext.Onderwerpen.First(i => i.Id == id);
			DbContext.Onderwerpen.Remove(Onderwerp);
			DbContext.SaveChanges();
			return RedirectToPage("/Onderwerpen");
		}

		public IActionResult OnGetToonOnderwerp(int id)
		{
			return RedirectToPage("/ToonOnderwerp", new { OnderwerpId = id.ToString() });
		}

		public IActionResult OnPost()
		{
			Onderwerpen = DbContext.Onderwerpen.ToList();
			if (!ModelState.IsValid)
			{
				return Page();
			}
			DbContext.Onderwerpen.Add(new Onderwerp() { Omschrijving = nieuwOnderwerp });
			DbContext.SaveChanges();
			return RedirectToPage("/Onderwerpen");
		}
	}
}
