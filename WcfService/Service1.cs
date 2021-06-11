using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
      
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }




        private MovieManagementService movieService = new MovieManagementService();

        public List<MovieDTO> GetMovies(string search)
        {
            return movieService.Get(search);
        }
        public MovieDTO GetMovieByID(int id)
        {
            return movieService.GetMovieById(id);
        }

        public string PutMovie(MovieDTO movieDto)
        {
            if (!movieService.Save(movieDto))
                return "Movie is not updated";

            return "Movie is updated";
        }
        public string PostMovie(MovieDTO movieDto)
        {
            if (!movieService.Save(movieDto))
            {
                return "Movie is not saved!";
            }
            else
            {
                return "Movie is saved!";
            }
        }
        public string DeleteMovie(int id)
        {
            if (!movieService.Delete(id))
            {
                return "Movie is not deleted!";
            }
            else
            {
                return "Movie is deleted!";
            }
        }


        private UserMovieManagementService userMovieService = new UserMovieManagementService();
        public List<UserMovieDTO> GetUserMovies(string search)
        {
            return userMovieService.Get(search);
        } 
        public UserMovieDTO GetUserMovieById(int id)
        {
            return userMovieService.GetUserMovieById(id);
        }
        public string PutUserMovie(UserMovieDTO userMovieDto)
        {
            if (!userMovieService.Save(userMovieDto))
                return "Movie for user is not updated";

            return "Movie for user is updated";
        }
        public string PostUserMovie(UserMovieDTO userMovieDto)
        {
            if (!userMovieService.Save(userMovieDto))
            {
                return "Movie for user is not saved!";
            }
            else
            {
                return "Movie for user is saved!";
            }
        }
        public string DeleteUserMovie(int id)
        {
            if (!userMovieService.Delete(id))
            {
                return "Movie of user is not deleted!";
            }
            else
            {
                return "Movie of user is deleted!";
            }
        }



        private UserManagementService userService = new UserManagementService();
        public List<UserDTO> GetUsers(string search)
        {
            return userService.Get(search);
        }
        public UserDTO GetUserByID(int id)
        {
            return userService.GetUserById(id);
        }
        public string PutUser(UserDTO userDto)
        {
            if (!userService.Save(userDto))
                return "User is not updated";

            return "User is updated";
        }
        public string DeleteUser(int id)
        {
            if (!userService.Delete(id))
            {
                return "User is not deleted!";
            }
            else
            {
                return "User is deleted!";
            }
        }
        public string PostUser(UserDTO userDto)
        {
            if (!userService.Save(userDto))
            {
                return "User is not saved!";
            }
            else
            {
                return "User is saved!";
            }
        }


    }
}
