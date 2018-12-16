using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverter
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface INCService
    {
        //Registers new user with given name and password. Returns user id.
        [OperationContract]
        Task<int> RegisterUser(string name, string pass);
        
        //Returns user id if given name and password pair exists in db.
        [OperationContract]
        Task<int> GetUser(string name, string pass);

        //Returns user id if given access token exists in db. Generates new token.
        [OperationContract]
        Task<int> GetUserByToken(string token);

        //Returns user data from id
        [OperationContract]
        Task<Models.User> GetUserData(int id);

        //Converts number and returns conversion id
        [OperationContract]
        Task<int> ConvertNumber(int value, int userId);

        //Returns users conversion history
        [OperationContract]
        Task<List<Models.Conversion>> GetHistory(int userId);

        //Returns a single conversion
        [OperationContract]
        Task<Models.Conversion> GetConversion(int convId);
    }
}
