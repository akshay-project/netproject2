using MyMovieApp.Data.DataConnection;
using Microsoft.EntityFrameworkCore;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class Theater : IThetre
    {
        MovieDbContext _movieDbContext;

        public Theater(MovieDbContext movieDbContext)
        {
            _movieDbContext= movieDbContext;
        }
        public string AddTheater(ThetreModel theatreModel)
        {
            string massage = "";
            _movieDbContext.theaterModel.Add(theatreModel);
            _movieDbContext.SaveChanges();
            massage = "Movie Inserted Successfully..!!";
            return massage;
        }

        public string DeleteTheaterById(int theatreId)
        {
            var user = _movieDbContext.theaterModel.Find(theatreId);
            if (user == null)
                return "";
            //_moviedbContext.userModel.Remove(user);
            _movieDbContext.Entry(user).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            return "Deleted Movie !";
        }

        public object SelectTheater()
        {
            List<ThetreModel> theaterList = _movieDbContext.theaterModel.ToList();
            return theaterList;
        }

        public object SelectTheaterById(int theatreId)
        {
            var user = _movieDbContext.theaterModel.Find(theatreId);
            if (user == null)
                return "";
            return user;
        }

        public string UpdateTheater(ThetreModel theatreModel)
        {
            _movieDbContext.Entry(theatreModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Updated Theater!";
        }
    }
}
