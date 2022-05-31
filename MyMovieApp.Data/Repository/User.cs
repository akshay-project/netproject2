using MyMovieApp.Data.DataConnection;
using Microsoft.EntityFrameworkCore;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public class User : IUser
    {
        MovieDbContext _moviedbContext;

        public User(MovieDbContext moviedbContext)
        {
            _moviedbContext = moviedbContext;
        }

        public string Delete(int userId)
        {
            var user = _moviedbContext.userModel.Find(userId);
            if (user == null)
                return "";
            //_moviedbContext.userModel.Remove(user);
            _moviedbContext.Entry(user).State = EntityState.Deleted;
            _moviedbContext.SaveChanges();
            return "Deleted";
        }

        public object Login(UserModel userModel)
        {
            UserModel userData = null;
            var user = _moviedbContext.userModel.Where(u=>u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count>0)
                userData = user[0];
            return userData;
           
        }

        public string Register(UserModel userModel)
        {
            string message = "";
            _moviedbContext.userModel.Add(userModel);
            _moviedbContext.SaveChanges();
            message = "Record inserted Successfully!!";
            return message;
        }

        public object SelectUser()
        {
            List<UserModel> list = _moviedbContext.userModel.ToList();
            return list;
        }

        public object SelectUserById(int userId)
        {
            var user = _moviedbContext.userModel.Find(userId);
            if (user == null)
                return "";
            return user;
        }

        public string Update(UserModel userModel)
        {
            _moviedbContext.Entry(userModel).State = EntityState.Modified;
            _moviedbContext.SaveChanges();
            return "Updated";
        }
    }
}
