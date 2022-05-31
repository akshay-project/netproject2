using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IThetre
    {
        string AddTheater(ThetreModel theatreModel);

        object SelectTheater();

        string UpdateTheater(ThetreModel theatreModel);

        string DeleteTheaterById(int theatreId);


        object SelectTheaterById(int theatreId);
    }
}
