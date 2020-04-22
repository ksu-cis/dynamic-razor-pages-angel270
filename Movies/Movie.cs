using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies
{
    /// <summary>
    /// A class representing a movie
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets and sets the title of the movie
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets and sets the Motion Picture Association of America Rating
        /// </summary>
        public string MPAARating { get; set; }

        /// <summary>
        /// Gets and sets the primary genre of the movie
        /// </summary>
        public string MajorGenre { get; set; }

        /// <summary>
        /// Gets and sets the Internet Movie Database rating of the movie
        /// </summary>
        public float? IMDBRating { get; set; }

        /// <summary>
        /// Gets and sets the Rotten Tomatoes rating of the movie
        /// </summary>
        public float? RottenTomatoesRating { get; set; }
    }
}
