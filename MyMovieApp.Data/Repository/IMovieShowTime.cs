using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IMovieShowTime
    {
        string InsertMovieShowTime(MyMovieApp.Entity.MovieShowTime movieShowTime);
        List<MyMovieApp.Entity.MovieShowTime> ShowMovieShowTime();
    }
}

