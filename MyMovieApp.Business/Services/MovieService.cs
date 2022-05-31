using MyMovieApp.Data.DataConnection;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class MovieService
    {
        IMovie movie;

        public MovieService(IMovie movie)
        {
            this.movie = movie;
        }

        public string AddMovie(MovieModel movieModel)
        {
            return movie.AddMovie(movieModel);
        }

        public object SelectMovie()
        {
            return movie.SelectMovie();
        }


        public object SelectMovieById(int movieId)
        {
            return movie.SelectMovieById(movieId);
        }

        public string UpdateMovie(MovieModel movieModel)
        {
            return movie.UpdateMovie(movieModel);
        }

        public string DeleteMovie(int movieId)
        {
            return movie.DeleteMovieById(movieId);
        }
    }
}
