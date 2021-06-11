using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        // Movies
        [OperationContract]
        List<MovieDTO> GetMovies(string filter);

        [OperationContract]
        MovieDTO GetMovieByID(int id);
        [OperationContract]
        string PutMovie(MovieDTO movieDto);

        [OperationContract]
        string PostMovie(MovieDTO movieDto);

        [OperationContract]
        string DeleteMovie(int id);

        ////////////////////////////////////////
        //Users

        [OperationContract]
        List<UserDTO> GetUsers(string search);
        [OperationContract]
        UserDTO GetUserByID(int id);

        [OperationContract]
        string PutUser(UserDTO userDto);

        [OperationContract]
        string PostUser(UserDTO userDto);

        [OperationContract]
        string DeleteUser(int id);

        ////////////////////////////////////////
        //UserMovies

        [OperationContract]
        List<UserMovieDTO> GetUserMovies(string filter);

        [OperationContract]
        UserMovieDTO GetUserMovieById(int id);

        [OperationContract]
        string PutUserMovie(UserMovieDTO userMovieDto);

        [OperationContract]
        string PostUserMovie(UserMovieDTO userMovieDto);

        [OperationContract]
        string DeleteUserMovie(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
