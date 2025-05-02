// <copyright file="GeneralLogic.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// logic when user is not logged in.
    /// </summary>
    internal static class GeneralLogic
    {
        /// <summary>
        /// logs in a user based on username and password.
        /// </summary>
        /// <param name="username"> username of user. </param>
        /// <param name="password"> password of user. </param>
        /// <param name="database"> database for application. </param>
        /// <param name="oldUser"> previous user. </param>
        /// <param name="currentUserState"> current user state. </param>
        /// <returns> true when username and password match a user in database. </returns>
        public static bool TryLoginUser(string username, string password, ref Database database, ref IUser oldUser, ref UserState currentUserState)
        {
            IUser? newUser = database.GetUserByUsername(username);
            if (newUser == null)
            {
                return false;
            }

            if (newUser.Password == password)
            {
                GeneralLogic.ChangeUser(ref oldUser, newUser, ref currentUserState);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// logging out user.
        /// </summary>
        /// <param name="oldUser"> previous user. </param>
        /// <param name="currentUserState"> current user state. </param>
        public static void Logout(ref IUser oldUser, ref UserState currentUserState)
        {
            GeneralLogic.ChangeUser(ref oldUser, new UserGuest(), ref currentUserState);
        }

        /// <summary>
        ///  saves general info about user.
        /// </summary>
        /// <param name="user"> user to save values to. </param>
        /// <param name="password"> possible new password. </param>
        /// <param name="name"> possible new name. </param>
        /// <param name="email"> possible new email. </param>
        /// <param name="address"> possible new address. </param>
        public static void SaveGeneralUserInfo(ref IUser user, string password, string name, string email, string address)
        {
            user.Password = password;
            user.Password = password;
            user.FullName = name;
            user.Email = email;
            user.Address = address;
        }

        /// <summary>
        /// all project type names.
        /// </summary>
        /// <returns> all existing projects type names. </returns>
        public static IEnumerable<string> GetLoadedProjectTypeNames()
        {
            return ProjectDataDictionary.Data.Keys.ToList();
        }

        /// <summary>
        /// gets a filtered list of projects. !!!!!!!(currently not able to filter just returns list from created list)!!!!!!!.
        /// </summary>
        /// <param name="database"> the database to look for scolarships. </param>
        /// <returns> projects that are filtered. </returns>
        public static IEnumerable<Project> GetDatabaseFilteredProjects(Database database)
        {
            return database.Projects;
        }

        /// <summary>
        /// Gets the club names that exists or the student does not have.
        /// </summary>
        /// <param name="database"> database to look for all club names. </param>
        /// <returns> gets the current existing clubs names. </returns>
        public static IEnumerable<string> GetAllDatabaseClubNames(Database database)
        {
            return database.GetAllClubNames();
        }

        /// <summary>
        /// gets a filtered list of scholarships. !!!!!!!(currently not able to filter just returns list from created list)!!!!!!!.
        /// </summary>
        /// <param name="database"> the database to look for projects. </param>
        /// <returns> scholarships that are filtered. </returns>
        public static IEnumerable<Scholarship> GetDatabaseFilteredScholarships(Database database)
        {
            return database.Scholarships;
        }

        /// <summary>
        /// gets the current users username of the application.
        /// </summary>
        /// <param name="user"> user retrieving data from. </param>
        /// <returns> username of user. </returns>
        public static string GetUsersUsername(IUser user)
        {
            return user.Username;
        }

        /// <summary>
        /// gets the current users name of the application.
        /// </summary>
        /// <param name="user"> user retrieving data from. </param>
        /// <returns> name of user. </returns>
        public static string GetUsersFullName(IUser user)
        {
            return user.FullName;
        }

        /// <summary>
        /// gets the current users email of the application.
        /// </summary>
        /// <param name="user"> user retrieving data from. </param>
        /// <returns> email of user. </returns>
        public static string GetUsersEmail(IUser user)
        {
            return user.Email;
        }

        /// <summary>
        /// gets the current users address of the application.
        /// </summary>
        /// <param name="user"> user retrieving data from. </param>
        /// <returns> address of user. </returns>
        public static string GetUsersAddress(IUser user)
        {
            return user.Address;
        }

        /// <summary>
        /// gets the current users password.
        /// </summary>
        /// <param name="user"> user retrieving data from. </param>
        /// <returns> password of user. </returns>
        public static string GetUsersPassword(IUser user)
        {
            return user.Password;
        }

        /// <summary>
        /// change the current user of the application.
        /// </summary>
        /// <param name="oldUser"> previous user. </param>
        /// <param name="newUser"> new current user. </param>
        /// <param name="currentUserState"> current user state. </param>
        private static void ChangeUser(ref IUser oldUser, IUser newUser, ref UserState currentUserState)
        {
            oldUser = newUser;
            if (oldUser.GetType() == typeof(UserGuest))
            {
                currentUserState = UserState.GUEST;
            }
            else if (oldUser.GetType() == typeof(UserStudent))
            {
                currentUserState = UserState.STUDENT;
            }
            else if (oldUser.GetType() == typeof(UserDonor))
            {
                currentUserState = UserState.DONOR;
            }
        }
    }
}
