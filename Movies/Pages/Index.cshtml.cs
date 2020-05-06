using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The movies to display on the index page 
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// The current search terms 
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] Genres { get; set; }

        /// <summary>
        /// The minimum IMDB Rating
        /// </summary>  
        [BindProperty(SupportsGet = true)]
        public double? IMDBMin { get; set; }

        /// <summary>
        /// The maximum IMDB Rating
        /// </summary> 
        [BindProperty(SupportsGet = true)]
        public double? IMDBMax { get; set; }

        /// <summary>
        /// The minimum Rotten Tomatoes Rating
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? RTMin { get; set; }

        /// <summary>
        /// The maximum Rotten Tomatoes Rating
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? RTMax { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;

            if(SearchTerms != null)
                Movies = MovieDatabase.All.Where(movie => movie.Title != null && 
                movie.Title.Contains(SearchTerms, StringComparison.CurrentCultureIgnoreCase));

            if (MPAARatings != null && MPAARatings.Length != 0)
                Movies = Movies.Where(movie => movie.MPAARating != null && 
                MPAARatings.Contains(movie.MPAARating));

            if (Genres != null && Genres.Length != 0)
                Movies = Movies.Where(movie => movie.MajorGenre != null &&
                Genres.Contains(movie.MajorGenre));

            if(IMDBMin != null || IMDBMax != null)
            {
                if (IMDBMin == null)
                    Movies = Movies.Where(movie => movie.IMDBRating <= IMDBMax);
                else if (IMDBMax == null)
                    Movies = Movies.Where(movie => movie.IMDBRating >= IMDBMin);
                else
                    Movies = Movies.Where(movie => movie.IMDBRating >= IMDBMin && movie.IMDBRating <= IMDBMax);
            }

            if (RTMin != null || RTMax != null)
            {
                if (RTMin == null)
                    Movies = Movies.Where(movie => movie.RottenTomatoesRating <= RTMax);
                else if (RTMax == null)
                    Movies = Movies.Where(movie => movie.RottenTomatoesRating >= RTMin);
                else
                    Movies = Movies.Where(movie => movie.RottenTomatoesRating >= RTMin && movie.RottenTomatoesRating <= RTMax);
            }
        }
    }
}
