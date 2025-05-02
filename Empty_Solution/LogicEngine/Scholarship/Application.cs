// <copyright file="Application.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// application from student.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="userStudent"> student that applied.. </param>
        /// <param name="criteriaToAnswer"> criteria for scholarship with its answer. </param>
        public Application(IUser userStudent, Dictionary<Criteria, string> criteriaToAnswer)
        {
            this.Student = userStudent;
            this.CriteriaToAnswers = criteriaToAnswer;
        }

        /// <summary>
        /// Gets the student who applied to the applciation.
        /// </summary>
        public IUser Student
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the dictionary where the criteria is the key and the value is the students answer.
        /// </summary>
        public Dictionary<Criteria, string> CriteriaToAnswers
        {
            get;
            private set;
        }
    }
}
