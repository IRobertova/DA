using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class UserMovieManagementService
    {
        private MyDBContext ctx = new MyDBContext();

        public List<UserMovieDTO> Get(string search)
        {

            List<UserMovieDTO> usermoviesDTOs = new List<UserMovieDTO>();
            // foreach (var item in ctx.User_Movies.ToList())
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserMovieRepository.Get(x => x.User_Id.ToString().Contains(search)))
                    usermoviesDTOs.Add(new UserMovieDTO
                    {                   

                        UserMovie_Id = item.Id,
                        Rent_Day = item.Rent_Day,
                        Return_Day = item.Return_Day,
                        Price = item.Price,
                        Comment = item.Comment,
                        Movie_Id = item.Movie_Id,
                        
                        /*Movie = new MovieDTO
                        {
                            Movie_Id = item.Movie_Id,
                            Title=item.Movie.Title,
                        },*/
                        User_Id = item.User_Id,
                        /*User = new UserDTO
                        {
                            User_Id=item.User_Id,
                            FName=item.User.FName,
                           // LName=item.User.LName
                        }*/
                    
                });
            }
            return usermoviesDTOs;
        }
        public UserMovieDTO GetUserMovieById(int id)
        {
            UserMovieDTO userMovieDTO = new UserMovieDTO();

            //User_Movie item = ctx.User_Movies.Find(id);
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User_Movie item = unitOfWork.UserMovieRepository.GetByID(id);
                if (item != null)
                {
                    userMovieDTO.UserMovie_Id = item.Id;
                    userMovieDTO.Rent_Day = item.Rent_Day;
                    userMovieDTO.Return_Day = item.Return_Day;
                    userMovieDTO.Price = item.Price;
                    userMovieDTO.Comment = item.Comment;
                    userMovieDTO.Movie_Id = item.Movie_Id;
                    userMovieDTO.Movie = new MovieDTO
                    {
                        Movie_Id = item.Movie_Id
                        // Title = item.Movie.Title,
                    };
                    userMovieDTO.User_Id = item.User_Id;
                    userMovieDTO.User = new UserDTO
                    {
                        User_Id = item.User_Id
                        //FName = item.User.FName,
                        // LName = item.User.LName
                    };

                }
                return userMovieDTO;
            }
        }
        public bool Save(UserMovieDTO usermovieDTO)
        {
            if ((usermovieDTO.Movie_Id <= 0 || usermovieDTO.Movie == null)||(usermovieDTO.User_Id<=0 || usermovieDTO.User==null))
            {
                return false;
            }

            User_Movie UserMovie = new User_Movie
            {
                Id = usermovieDTO.UserMovie_Id,
                Rent_Day = usermovieDTO.Rent_Day,
                Return_Day = usermovieDTO.Return_Day,
                Price = usermovieDTO.Price,
                Comment = usermovieDTO.Comment,
                Movie_Id = usermovieDTO.Movie_Id,
                User_Id = usermovieDTO.User_Id,

            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if(usermovieDTO.UserMovie_Id==0)
                        unitOfWork.UserMovieRepository.Insert(UserMovie);
                    else
                        unitOfWork.UserMovieRepository.Update(UserMovie);

                    unitOfWork.Save();
                    // ctx.User_Movies.Add(UserMovie);
                    //ctx.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    User_Movie userMovie = unitOfWork.UserMovieRepository.GetByID(id);
                    unitOfWork.UserMovieRepository.Delete(userMovie);
                    unitOfWork.Save();
                    //User_Movie userMovie = ctx.User_Movies.Find(id);
                    //ctx.User_Movies.Remove(userMovie);
                    //ctx.SaveChanges();
                }
                    return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
