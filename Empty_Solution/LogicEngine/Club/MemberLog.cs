// <copyright file="MemberLog.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicEngine
{
    /// <summary>
    /// log of a member including start and end date.
    /// </summary>
    internal class MemberLog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLog"/> class.
        /// creates a log for using a user.
        /// </summary>
        /// <param name="member"> user that is being logged as a member. </param>
        public MemberLog(IUser member)
        {
            this.Member = member;
            this.DateJoined = DateTime.Now;
            this.DateLeft = null;
        }

        /// <summary>
        /// Gets the user that is being logged.
        /// </summary>
        public IUser Member
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the time the user joined as a member.
        /// </summary>
        public DateTime DateJoined
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the time when the user left. (null when user has not left).
        /// </summary>
        public DateTime? DateLeft
        {
            get;
            private set;
        }

        /// <summary>
        /// when user leaves the club it updates the time user left only if its the user that left.
        /// </summary>
        /// <param name="sender"> user that left. </param>
        /// <param name="args"> empty arg. </param>
        public void MemberLeft(object sender, EventArgs args)
        {
            if (sender is not null)
            {
                if (sender is IUser)
                {
                    IUser user = (IUser)sender;
                    if ((object)user == (object)this.Member)
                    {
                        this.DateLeft = DateTime.Now;
                    }
                }
            }
        }
    }
}
