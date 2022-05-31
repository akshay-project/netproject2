using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iuser;

        public UserService(IUser iuser)
        {
            _iuser = iuser;
        }

        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel); 
        }

        public object selectUser()
        {
            return _iuser.SelectUser();
        }

        public object SelectUserById(int userId)
        {
            return _iuser.SelectUserById(userId);
        }

        public string Updateuser(UserModel userModel)
        {
            return _iuser.Update(userModel);
        }

        public string DeleteUser(int userId)
        {
            return _iuser.Delete(userId);
        }


    }
}
