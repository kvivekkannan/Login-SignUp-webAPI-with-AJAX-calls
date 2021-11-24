using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project01.Models;

namespace Project01.DAL
{
    public interface IUserDetailsRepository : IDisposable
    {
        /// <summary>
        /// Gets all the user details available in the database
        /// </summary>
        /// <returns>Details of all users in DB</returns>
        IEnumerable<UserDetails> GetUserDetails();

        /// <summary>
        /// Get details of a specific user
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Details of the user matching with the entered parameter</returns>
        UserDetails GetUserDetailsById(int id);

        /// <summary>
        /// Sends the login process values to controller
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserDetails GetUserLoginDetails(UserDetails user);

        /// <summary>
        /// Add the specific user to the database
        /// </summary>
        /// <param name="user"></param>
        void AddUserDetail(UserDetails user);

        /// <summary>
        /// Removes the details of specific user
        /// </summary>
        /// <param name="user"></param>
        void RemoveUserDetail(UserDetails user);

        void RemoveUserDetailById(int id);

        /// <summary>
        /// Updates all the user details in the Database
        /// </summary>
        /// <param name="allUserDetails"></param>
        void UpdateUserDetails(UserDetails allUserDetails);

        UserDetails EditUserDetails(int id, UserDetails userDetails);

        UserDetails InsertUserDetails(UserDetails details);

        /// <summary>
        /// Saves the details inside the database
        /// </summary>
       // void SaveUserDetails();

    }
}
