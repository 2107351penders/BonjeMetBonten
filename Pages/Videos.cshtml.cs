using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using BonjeMetBonten.Data;
using BonjeMetBonten.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonjeMetBonten.Pages
{
    public class VideosModel : PageModel
    {
        public ICollection<Video> Videos { get; set; }

        private VideoDbContext DbContext;
        [BindProperty]
        [Required(ErrorMessage = "Zoekterm mag niet leeg zijn!")]
        public string searchString { get; set; }

        public VideosModel(VideoDbContext injectedContext)
        {
            DbContext = injectedContext;
        }
        public void OnGet()
        {
            Videos = DbContext.Videos.ToList();
        }

        public IActionResult OnGetBewerkVideo(int id)
        {
			return RedirectToPage("/BewerkVideo", new { VideoId = id.ToString() });
		}

        public IActionResult OnPost()
        {
			Videos = DbContext.Videos.ToList();
			if (!ModelState.IsValid)
            {
                return Page();
            }
            var regex = new Regex(searchString);

            Videos = (from Video in Videos
                     where regex.IsMatch(Video.Titel)
                     select Video).ToList();
            
            return Page();
        }
    }
}
