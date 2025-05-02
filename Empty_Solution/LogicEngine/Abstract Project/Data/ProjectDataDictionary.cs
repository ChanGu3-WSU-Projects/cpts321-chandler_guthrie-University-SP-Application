// <copyright file="ProjectDataDictionary.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.Data;
using System.Reflection;

namespace LogicEngine
{
    /// <summary>
    /// all project data types.
    /// </summary>
    internal class ProjectDataDictionary
    {
        /// <summary>
        /// Initializes static members of the <see cref="ProjectDataDictionary"/> class.
        ///     Called once when any static member is accessed.
        /// </summary>
        static ProjectDataDictionary()
        {
            // add each op and type retreived from method into dictionary
            List<Assembly> currentContexAndDomaintAssemblyList = AppDomain.CurrentDomain.GetAssemblies().ToList();
            TraverseAvailableProjects(currentContexAndDomaintAssemblyList);
        }

        /// <summary>
        /// Gets characters matching to a Operator Node type.
        /// </summary>
        public static Dictionary<string, Type> Data
        {
            get;
        }

        = new Dictionary<string, Type>();

        /// <summary>
        /// Traverses assembly files looking for specific classes that inherit from
        ///     Project then using retreived project type name and project type class
        ///     and use them as arguments for the OnOperator delegate.
        /// </summary>
        /// <param name="assemblies"> assemblies in use in current context. </param>
        /// <exception cref="ArgumentException"> When project already exist in dictionary. </exception>
        private static void TraverseAvailableProjects(List<Assembly> assemblies)
        {
            Type projectType = typeof(Project);

            IEnumerable<Type> projectTypes;

            // sift through each assembly checking for inherited types of OperatorNode
            foreach (var assembly in assemblies)
            {
                projectTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(projectType));

                // for every operator type found in specific assembly add to dictionary of operatortypes connected with operator
                foreach (Type specificProjectType in projectTypes)
                {
                    // call method by using op field and type of operator retrieved as arguments.
                    if (ProjectDataDictionary.Data.TryAdd(specificProjectType.Name, specificProjectType) == false)
                    {
                        throw new ArgumentException("the project already exists in the project dictionary");
                    }
                }
            }
        }
    }
}
