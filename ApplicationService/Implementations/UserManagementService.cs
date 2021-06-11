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
    public class UserManagementService
    {
        private MyDBContext ctx = new MyDBContext();

        public List<UserDTO> Get(string search)
        {
            List<UserDTO> usersDTOs = new List<UserDTO>();
            //foreach (var item in ctx.Users.ToList())
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get(x => x.FName.Contains(search) || x.LName.Contains(search)))
                {
                    
                        usersDTOs.Add(new UserDTO
                    {
                        User_Id = item.Id,
                        FName = item.FName,
                        LName = item.LName,
                        Bday = item.Bday,
                        Address = item.Address,
                        Phone = item.Phone

                    });
                }
            }
            return usersDTOs;
        }

        public UserDTO GetUserById(int id)
        {
            UserDTO userDTO = new UserDTO();

            //User user = ctx.Users.Find(id);
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                if (user != null)
                {
                userDTO.User_Id = user.Id;
                userDTO.FName = user.FName;
                userDTO.LName = user.LName;
                userDTO.Phone = user.LName;
                userDTO.Bday = user.Bday;
                userDTO.Address = user.Address;

            };
                return userDTO;
            }
        }
        public bool Save(UserDTO userDTO)
        {
            User User = new User
            {
                Id=userDTO.User_Id,
                FName=userDTO.FName,
                LName=userDTO.LName,
                Bday=userDTO.Bday,
                Address=userDTO.Address,
                Phone=userDTO.Phone
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if(userDTO.User_Id==0)
                        unitOfWork.UserRepository.Insert(User);
                    else
                        unitOfWork.UserRepository.Update(User);

                    unitOfWork.Save();
                    //ctx.Users.Add(User);
                    //ctx.SaveChanges
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
                //User user = ctx.Users.Find(id);
                //ctx.Users.Remove(user);
                //ctx.SaveChanges();
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    User user = unitOfWork.UserRepository.GetByID(id);
                    unitOfWork.UserRepository.Delete(user);
                    unitOfWork.Save();
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
