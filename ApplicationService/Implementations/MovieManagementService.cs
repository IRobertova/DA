using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Implementations;

namespace ApplicationService.Implementations
{
    public class MovieManagementService
    {
        private MyDBContext ctx = new MyDBContext();

        public List<MovieDTO> Get(string search)
        {
            List<MovieDTO> moviesDTOs = new List<MovieDTO>();
            //foreach(var item in ctx.Movies.ToList())
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.MovieRepository.Get(x => x.Title.Contains(search)))
                {
                    moviesDTOs.Add(new MovieDTO
                    {
                        Movie_Id = item.Id,
                        Title = item.Title,
                        Year = item.Year,
                        Genre = item.Genre,
                        Duration = item.Duration,
                        Resume = item.Resume,
                        Price = item.Price

                    });
                }
            }
            return moviesDTOs;
        }

        public MovieDTO GetMovieById(int id)
        {
            MovieDTO movieDTO = new MovieDTO();

            //Movie movie = ctx.Movies.Find(id);
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Movie movie = unitOfWork.MovieRepository.GetByID(id);
                if (movie != null)
                {
                    movieDTO.Movie_Id = movie.Id;
                    movieDTO.Title = movie.Title;
                    movieDTO.Year = movie.Year;
                    movieDTO.Genre = movie.Genre;
                    movieDTO.Duration = movie.Duration;
                    movieDTO.Resume = movie.Resume;
                    movieDTO.Price = movie.Price;
                }
            }
            return movieDTO;
        }
        public bool Save(MovieDTO movieDTO)
        {
            Movie Movie = new Movie
            {
                Id=movieDTO.Movie_Id,
                Title = movieDTO.Title,
                Year = movieDTO.Year,
                Genre = movieDTO.Genre,
                Duration = movieDTO.Duration,
                Resume = movieDTO.Resume,
                Price=movieDTO.Price

            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if(movieDTO.Movie_Id==0)
                        unitOfWork.MovieRepository.Insert(Movie);
                    else
                        unitOfWork.MovieRepository.Update(Movie);

                    unitOfWork.Save();
                    //ctx.Movies.Add(Movie);
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
                    Movie movie = unitOfWork.MovieRepository.GetByID(id);
                    unitOfWork.MovieRepository.Delete(movie);
                    unitOfWork.Save();
                    //ctx.Movies.Remove(movie);
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
