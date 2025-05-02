// <copyright file="IUser.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// general required info about a user.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username
        {
            get;
        }

        /// <summary>
        /// Gets or Sets the password of the user.
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the fullname of the user.
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address of the user.
        /// </summary>
        public string Address
        {
            get;
            set;
        }
    }
}
