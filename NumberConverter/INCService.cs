using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberConverter
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface INCService
    {
        //Registers new user with given name and password. Returns user id.
        [OperationContract]
        int RegisterUser(string name, string pass);
        
        //Returns user id if given name and password pair exists in db.
        [OperationContract]
        int GetUser(string name, string pass);

        //Returns user id if given access token exists in db. Generates new token.
        [OperationContract]
        int GetUserByToken(string token);

        //Returns user data from id
        [OperationContract]
        Models.User GetUserData(int id);

        //Converts number and returns conversion id
        [OperationContract]
        int ConvertNumber(int value, int userId);

        //Returns users conversion history
        [OperationContract]
        List<Models.Conversion> GetHistory(int userId);

        //Returns a single conversion
        [OperationContract]
        Models.Conversion GetConversion(int convId);

        //Helper method to generate access tokens
        string GenerateToken(Models.User user);
    }
}
