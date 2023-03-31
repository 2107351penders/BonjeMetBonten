using System.Collections.Immutable;
using BonjeMetBonten.Data;
using BonjeMetBonten.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BonjeMetBonten.Pages
{
	public class ToonOnderwerpModel : PageModel
    {
		public int OnderwerpId { get; set; }
		public string OnderwerpOmschrijving { get; set; }
		public ICollection<Video> Videos { get; set; }
		private VideoDbContext DbContext;

		public ToonOnderwerpModel(VideoDbContext injectedContext)
		{
			DbContext = injectedContext;
			Videos = new List<Video>();
		}
		public void OnGet()
        {
			if (Request.Query.ContainsKey("OnderwerpId"))
			{
				int ParsedOnderwerpId;
				string OnderwerpIdString = Request.Query["OnderwerpId"];

				if (int.TryParse(OnderwerpIdString, out ParsedOnderwerpId))
				{
					OnderwerpId = ParsedOnderwerpId;
                    OnderwerpOmschrijving = (from Onderwerp in DbContext.Onderwerpen
                                             where Onderwerp.Id == OnderwerpId
                                             select Onderwerp.Omschrijving).Single<String>();
                    foreach (var koppel in DbContext.Koppels)
					{
						if (koppel.OnderwerpId == ParsedOnderwerpId)
						{
                            
                            Videos.Add(DbContext.Videos.Where(id => id.Id == koppel.VideoId).First());
						}
					}

				}
				else
				{
					RedirectToPage("/Error"); // Parameter is geen valide onderwerp ID
				}
			}
			else
			{
				RedirectToPage("/Error"); // Geen onderwerp ID als parameter meegegeven
			}
		}
		public IActionResult OnGetBewerkVideo(int id)
		{
			return RedirectToPage("/BewerkVideo", new { VideoId = id.ToString() });
		}
	}
}
