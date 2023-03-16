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

        public VideosModel(VideoDbContext injectedContext)
        {
            DbContext = injectedContext;
        }
        public void OnGet()
        {
            Videos = DbContext.Videos.ToList();
        }
    }
}
