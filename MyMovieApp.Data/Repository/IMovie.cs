using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IMovie
    {
        string AddMovie(MovieModel movieModel);

        object SelectMovie();

        string UpdateMovie(MovieModel movieModel);

        string DeleteMovieById(int movieId);


        object SelectMovieById(int movieId);
    }
}
