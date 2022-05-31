using System;
using MyMovieApp.Data.DataConnection;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class TheaterService
    {
        IThetre theater;

        public TheaterService(IThetre theater)
        {
            this.theater = theater;
        }



        public string AddTheater(ThetreModel theaterModel)
        {
            return theater.AddTheater(theaterModel);
        }

        public object SelectThater()
        {
            return theater.SelectTheater();
        }


        public object SelectTheaterById(int movieId)
        {
            return theater.SelectTheaterById(movieId);
        }

        public string UpdateTheater(ThetreModel theaterModel)
        {
            return theater.UpdateTheater(theaterModel);
        }

        public string DeleteTheater(int movieId)
        {
            return theater.DeleteTheaterById(movieId);
        }
    }
}
