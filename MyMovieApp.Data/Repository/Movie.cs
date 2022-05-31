using MyMovieApp.Data.DataConnection;
using Microsoft.EntityFrameworkCore;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string AddMovie(MovieModel movieModel)
        {
            string massage = "";
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            massage = "Movie Inserted Successfully..!!";
            return massage;
        }

        public object SelectMovie()
        {
            List<MovieModel> movieList = _movieDbContext.movieModel.ToList();
            return movieList;
        }

        public string UpdateMovie(MovieModel movieModel)
        {
            _movieDbContext.Entry(movieModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Updated Movie!";
        }

        public string DeleteMovieById(int movieId)
        {
            var user = _movieDbContext.movieModel.Find(movieId);
            if (user == null)
                return "";
            //_moviedbContext.userModel.Remove(user);
            _movieDbContext.Entry(user).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            return "Deleted Movie !";
        }


        public object SelectMovieById(int movieId)
        {
            var movie = _movieDbContext.movieModel.Find(movieId);
            if (movie == null)
                return "";
            return movie;

        }
    }
}
