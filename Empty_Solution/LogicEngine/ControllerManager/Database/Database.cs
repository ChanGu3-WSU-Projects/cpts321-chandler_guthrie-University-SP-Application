// <copyright file="Database.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// database of the application holding info in memory (for purpose of assignment in memory better if not).
    /// </summary>
    internal class Database
    {
        /// <summary>
        /// contains all users created in a dictionary for (O(1) access to each student using username).
        /// </summary>
        private Dictionary<string, IUser> users = new Dictionary<string, IUser>();

        /// <summary>
        /// containts all clubs created in a dictionary for (O(1) access to each student using project name).
        /// </summary>
        private Dictionary<string, Club> clubs = new Dictionary<string, Club>();

        /// <summary>
        /// Gets all existing projects.
        /// </summary>
        public List<Project> Projects
        {
            get;
        }

        = new List<Project>();

        /// <summary>
        /// Gets all existing scholarships.
        /// </summary>
        public List<Scholarship> Scholarships
        {
            get;
        }

        = new List<Scholarship>();

        /// <summary>
        /// adds a user by their username to the database.
        /// </summary>
        /// <param name="newUser"> the newuser. </param>
        /// <exception cref="NotSupportedException"> when username already exists. </exception>
        public void AddUser(IUser newUser)
        {
            if (!this.users.TryAdd(newUser.Username, newUser))
            {
                throw new NotSupportedException("Users cannot have the same username");
            }
        }

        /// <summary>
        /// gets the user by username.
        /// </summary>
        /// <param name="username"> username of the user. </param>
        /// <returns> Iuser with the username. </returns>
        public IUser? GetUserByUsername(string username)
        {
            IUser? user = null;
            if (this.users.TryGetValue(username, out user))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// adds a user by their username to the database.
        /// </summary>
        /// <param name="club"> a new club. </param>
        /// <exception cref="NotSupportedException"> when username already exists. </exception>
        public void AddClub(Club club)
        {
            if (!this.clubs.TryAdd(club.Name, club))
            {
                throw new NotSupportedException("club cannot have the same club name");
            }
        }

        /// <summary>
        /// gets the user by username.
        /// </summary>
        /// <param name="clubName"> username of the user. </param>
        /// <returns> Iuser with the username. </returns>
        public Club? GetClubByName(string clubName)
        {
            Club? club = null;
            if (this.clubs.TryGetValue(clubName, out club))
            {
                return club;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// gets the list of clubnames from the database.
        /// </summary>
        /// <returns> all vlub names. </returns>
        public List<string> GetAllClubNames()
        {
            return this.clubs.Keys.ToList();
        }
    }
}
