using MyMovieApp.Data.DataConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MovieApp.Data.Repositories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDbContext _movieDbContext;
        public MovieShowTime(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string InsertMovieShowTime(MyMovieApp.Entity.MovieShowTime movieShowTime)
        {
            _movieDbContext.movieShowTimes.Add(movieShowTime);
            _movieDbContext.SaveChanges();
            return "Inserted";
        }

        public List<MyMovieApp.Entity.MovieShowTime> ShowMovieShowTime()
        {
            return _movieDbContext.movieShowTimes.ToList();
        }
    }
}

