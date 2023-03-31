using BonjeMetBonten.Data;
using BonjeMetBonten.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BonjeMetBonten.Pages
{
    public class BewerkVideoModel : PageModel
    {
        public int VideoId { get; set; }
        public string VideoTitel { get; set; }
        private VideoDbContext DbContext;
        public Video VideoObject { get; set; }
        public List<Onderwerp> Onderwerpen { get; set; }
        [BindProperty]
        public String toegevoegdOnderwerp { get; set; }
        public IList<SelectListItem> onderwerpOmschrijvingen { get; set; }

        public BewerkVideoModel(VideoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IActionResult OnGet()
        {
            onderwerpOmschrijvingen = new List<SelectListItem>();

			if (Request.Query.ContainsKey("VideoId"))
            {
				int ParsedVideoId;
				string VideoIdString = Request.Query["VideoId"];
                
                if (int.TryParse(VideoIdString, out ParsedVideoId))
                {
					VideoId = ParsedVideoId;
                    VideoObject = (from Video in DbContext.Videos
                                  where Video.Id == VideoId
                                  select Video).Single();
                    Onderwerpen = (from Koppel in DbContext.Koppels
                                  where Koppel.VideoId == VideoId
                                  select Koppel.Onderwerp).ToList();
                    VideoTitel = VideoObject.Titel;
					
                    foreach (Onderwerp onderwerp in DbContext.Onderwerpen)
					{
						if (!Onderwerpen.Contains(onderwerp))
							onderwerpOmschrijvingen.Add(new SelectListItem(onderwerp.Omschrijving, onderwerp.Omschrijving));
					}
					return Page();
                }
                else
                {
                    return RedirectToPage("/Error"); // Parameter is geen valide video ID
                }
			}
            else
            {
				return RedirectToPage("/Error"); // Geen video ID als parameter meegegeven
			}
            
        }
        public IActionResult OnGetVerwijderOnderwerpFromVideo(int video, int onderwerp)
        {
            Onderwerp Onderwerp = DbContext.Onderwerpen.First(i => i.Id == onderwerp);
            Koppel Koppel = (from KoppelRegel in DbContext.Koppels
                             where KoppelRegel.VideoId.Equals(video)
                             where KoppelRegel.OnderwerpId.Equals(onderwerp)
                             select KoppelRegel).First();
            DbContext.Koppels.Remove(Koppel);
            DbContext.SaveChanges();
            return Redirect("/BewerkVideo?VideoId=" + video.ToString());
        }

        public IActionResult OnPost()
        {
            if (Request.Query.ContainsKey("VideoId"))
            {
                int ParsedVideoId;
                string VideoIdString = Request.Query["VideoId"];

                if (int.TryParse(VideoIdString, out ParsedVideoId))
                {
                    VideoId = ParsedVideoId;
                    int toegevoegdOnderwerpId = (from Onderwerp in DbContext.Onderwerpen
                                                 where Onderwerp.Omschrijving.Equals(toegevoegdOnderwerp)
                                                 select Onderwerp.Id).First();
                    DbContext.Koppels.Add(new Koppel()
                    {
                        OnderwerpId = toegevoegdOnderwerpId,
                        VideoId = VideoId
                    });
                    DbContext.SaveChanges();
                    return RedirectToPage("/BewerkVideo", new { VideoId = VideoId.ToString() });
                }
                else
                {
                    return RedirectToPage("/Error");
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
		}
	}
}
