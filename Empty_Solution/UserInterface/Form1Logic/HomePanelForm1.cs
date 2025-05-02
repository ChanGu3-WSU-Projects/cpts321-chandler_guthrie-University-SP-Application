// <copyright file="HomePanelForm1.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.Text;
using LogicEngine;

namespace UserInterface
{
    /// <summary>
    /// home panel logic of the Form1.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// holds info about the criteria control objects. (To dispose of later).
        /// </summary>
        private List<(Control, Control)> criteriaControlPairs = new List<(Control, Control)>();

        private List<Project> dataGridProjects;

        private List<Scholarship> dataGridScholarships;

        private Scholarship currentScholarshipApplication;

        /// <summary>
        /// resets the home panel for when it is opened for the first time.
        /// </summary>
        private void ResetHomePanel()
        {
            this.comboBoxSearchType.SelectedIndex = -1;
            this.comboBoxSearchType.Text = string.Empty;
            this.dataGridViewHomeProjects.Rows.Clear();
            this.dataGridViewHomeScholarships.Rows.Clear();
            WinformObjects.HideDisableControlObject(this.dataGridViewHomeProjects);
            WinformObjects.HideDisableControlObject(this.dataGridViewHomeScholarships);
        }

        /// <summary>
        /// populates grid with all the projects filtered/unfiltered.
        /// </summary>
        private void PopulateDataGridHomeProjects()
        {
            this.dataGridProjects = this.controllerManager.GetDatabaseFilteredProjects().ToList();
            foreach (Project project in this.dataGridProjects)
            {
                this.dataGridViewHomeProjects.Rows.Add(project.Name, $"Donations: {project.Donations.Count}", $"Goal Amount: {project.TargetAmount}", $"Funded: %{(int)project.PercentRaised()}", $"Days Left: {project.DaysLeft()}", "Donate", "View More");
            }
        }

        /// <summary>
        /// populates grid with all the scholarships filtered/unfiltered.
        /// </summary>
        private void PopulateDataGridHomeScholarships()
        {
            this.dataGridScholarships = this.controllerManager.GetDatabaseFilteredScholarships().ToList();
            foreach (Scholarship scholarship in this.dataGridScholarships)
            {
                string awardedText = string.Empty;
                if (scholarship.Awarded == true)
                {
                    awardedText = $"Awarded";
                }
                else
                {
                    awardedText = $"NotAwarded";
                }

                int numStudents = 0;
                StringBuilder studentList = new StringBuilder(string.Empty);
                foreach (IUser user in scholarship.StudentsToAward)
                {
                    studentList.Append($"- {user.FullName}{Environment.NewLine}");
                    numStudents++;
                }

                int newRowIndex = this.dataGridViewHomeScholarships.Rows.Add(
                    $"{scholarship.Name}",
                    $"{awardedText}",
                    $"{studentList}",
                    "Apply",
                    "View More");

                // When more students increase row height.
                if (numStudents != 0)
                {
                    this.dataGridViewHomeScholarships.Rows[newRowIndex].Height = 20 + ((numStudents - 1) * 12);
                }
            }
        }

        /// <summary>
        /// populates Project View More with all stats from specific project.
        /// </summary>
        private void PopulateProjectViewMore(Project project)
        {
            this.labelViewMoreProjectName.Text = $"{project.Name}";
            this.labelProjectViewMoreDaysLeft.Text = $"Days Left: {project.DaysLeft()}";
            this.labelProjectViewMoreTargetAmount.Text = $"Target Amount: ${(int)project.TargetAmount}";
            this.labelProjectViewMoreFunded.Text = $"Percent Funded: %{(int)project.PercentRaised()}";
            this.richTextBoxProjectViewMoreDescription.Text = $"{project.Description}";
            this.labelProjectViewMoreAmountOfDonations.Text = $"Amount: {project.Donations.Count}";

            foreach (Donation donation in project.Donations)
            {
                this.dataGridViewProjectViewMoreDonations.Rows.Add($"{donation.VisibleDonorName}", $"${donation.VisibleAmount}", $"{donation.DateCreated.ToString("MM/dd/yyyy")}");
            }
        }

        /// <summary>
        /// populates Scholarship View More with all stat from specific scholarship.
        /// </summary>
        private void PopulateScholarshipViewMore(Scholarship scholarship)
        {
            this.labelScholarshipViewMoreName.Text = $"{scholarship.Name}";
            this.labelScholarshipViewMoreDaysLeft.Text = $"Days Left: {scholarship.DaysLeft()}";

            if (scholarship.Awarded == true)
            {
                this.labelScholarshipViewMoreIsAwarded.Text = $"Awarded";
                this.labelScholarshipViewMoreIsAwarded.ForeColor = Color.Green;

                foreach (IUser user in scholarship.StudentsToAward)
                {
                    this.dataGridViewScholarshipViewMoreStudentList.Rows.Add(user.FullName);
                }
            }
            else
            {
                this.labelScholarshipViewMoreIsAwarded.Text = $"NotAwarded";
                this.labelScholarshipViewMoreIsAwarded.ForeColor = Color.Red;
            }

            this.richTextBoxScholarshipViewMoreDescription.Text = $"{scholarship.Description}";
            this.labelScholarshipViewMoreDonorName.Text = $"Donor Name: {scholarship.Donation.VisibleDonorName}";
            this.labelScholarshipViewMoreDonorAmount.Text = $"Donation Amount:{Environment.NewLine} {scholarship.Donation.VisibleAmount}";
        }

        /// <summary>
        /// populates student application of scholarship with all the criteria from specific scholarship.
        /// </summary>
        private void PopulateScholarshipStudentApplication(Scholarship scholarship)
        {
            int criteriaCount = 0;
            for (int i = 0; i < scholarship.Criteria.Count; i++)
            {
                Criteria criteria = scholarship.Criteria[i];

                if (criteria.GetType() == typeof(BoolCriteria))
                {
                    Control labelControl = WinformObjects.CreateLabelLocalToParent(this.panelApplicationStudent, new Point(50, 120 + (i * 40)), new Size(40, 20), $"labelCriteria{criteria.Name}", $"{criteria.Name}");
                    ComboBox answerControl = WinformObjects.CreateComboBoxLocalToParent(this.panelApplicationStudent, new Point(300, 120 + (i * 40)), new Size(125, 25), $"combobox{criteria.Name}");
                    answerControl.Items.Add("True");
                    answerControl.Items.Add("False");
                    this.criteriaControlPairs.Add((labelControl, answerControl));
                }
                else if (criteria.GetType() == typeof(RangeCriteria))
                {
                    Control labelControl = WinformObjects.CreateLabelLocalToParent(this.panelApplicationStudent, new Point(50, 120 + (i * 40)), new Size(40, 20), $"labelCriteria{criteria.Name}", $"{criteria.Name}: ");
                    TextBox answerControl = WinformObjects.CreateTextBoxLocalToParent(this.panelApplicationStudent, new Point(300, 120 + (i * 40)), new Size(125, 25), $"textbox{criteria.Name}");
                    this.criteriaControlPairs.Add((labelControl, answerControl));
                }

                criteriaCount++;
            }

            if (criteriaCount >= 10)
            {
                this.buttonApplicationStudentApply.Location = new Point(20, 500 + (40 * (criteriaCount - 9)));
                this.buttonApplicationStudentCancel.Location = new Point(380, 500 + (40 * (criteriaCount - 9)));
            }
        }

        /// <summary>
        /// Changes the search inside the database.
        /// </summary>
        /// <param name="sender"> ComboBox specifically searchtype. </param>
        /// <param name="e"> arguments. </param>
        private void OnComboBoxSearchTypeChanged(object sender, EventArgs e)
        {
            // clear the datagridviewprojects from panel
            WinformObjects.HideDisableControlObject(this.dataGridViewHomeProjects);
            this.dataGridViewHomeProjects.Rows.Clear();

            // clear the datagridviewprojects from panel
            WinformObjects.HideDisableControlObject(this.dataGridViewHomeScholarships);
            this.dataGridViewHomeScholarships.Rows.Clear();

            if (sender is not null)
            {
                ComboBox comboBoxSearchType = (ComboBox)sender;

                switch (comboBoxSearchType.Text)
                {
                    case "Projects":
                        WinformObjects.UnHideEnableControlObject(this.dataGridViewHomeProjects);
                        this.PopulateDataGridHomeProjects();
                        break;
                    case "Scholarships":
                        WinformObjects.UnHideEnableControlObject(this.dataGridViewHomeScholarships);
                        this.PopulateDataGridHomeScholarships();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// occurs everytime the datagrid cells are clicked.
        ///     when a specific button is clicked a specific function is called.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguments. </param>
        private void OnDataGridViewHomeProjectsCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = this.dataGridViewHomeProjects.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.GetType() == typeof(DataGridViewButtonCell))
            {
                switch (currentCell.ColumnIndex)
                {
                    case 5: // Donate Button.
                        this.OpenPopUp(this.panelUnderMaintanance);
                        break;
                    case 6: // More Info Button
                        this.dataGridViewProjectViewMoreDonations.Rows.Clear();
                        this.PopulateProjectViewMore(this.dataGridProjects[currentCell.RowIndex]);
                        this.OpenPopUp(this.panelProjectMoreInfo);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// occurs everytime the datagrid HomeScolarship cells are clicked.
        ///     when a specific button is clicked a specific function is called.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguments. </param>
        private void OnDataGridViewHomeScolarshipsCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = this.dataGridViewHomeScholarships.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.GetType() == typeof(DataGridViewButtonCell))
            {
                switch (currentCell.ColumnIndex)
                {
                    // Apply Button
                    case 3:
                        // only student is allowed to apply.
                        if (this.controllerManager.CurrentUserState == UserState.STUDENT && this.dataGridScholarships[currentCell.RowIndex].DaysLeft() > 0)
                        {
                            foreach ((Control, Control) criteriaControlPair in this.criteriaControlPairs)
                            {
                                criteriaControlPair.Item1.Dispose();
                                criteriaControlPair.Item2.Dispose();
                            }

                            this.criteriaControlPairs.Clear();
                            this.currentScholarshipApplication = this.dataGridScholarships[currentCell.RowIndex];
                            this.PopulateScholarshipStudentApplication(this.dataGridScholarships[currentCell.RowIndex]);
                            this.OpenPopUp(this.panelApplicationStudent);
                        }

                        // other users
                        else
                        {
                        }

                        break;

                    // Scholarship More Info Button
                    case 4:
                        this.dataGridViewScholarshipViewMoreStudentList.Rows.Clear();
                        this.PopulateScholarshipViewMore(this.dataGridScholarships[currentCell.RowIndex]);
                        this.OpenPopUp(this.panelScholarshipViewMore);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// when user presses the apply button on a student application.
        /// </summary>
        /// <param name="sender"> apply button. </param>
        /// <param name="e"> arguments. </param>
        private void OnStudentApplicationApplyClick(object sender, EventArgs e)
        {
            Dictionary<Criteria, string> criteriaToAnswer = new Dictionary<Criteria, string>();

            int criteriaCount = 0;

            // if some of the info is not filled do not continue.
            foreach ((Control, Control) controlPair in this.criteriaControlPairs)
            {
                criteriaToAnswer.Add(this.currentScholarshipApplication.Criteria[criteriaCount], controlPair.Item2.Text);
                criteriaCount++;
            }

            if (!this.controllerManager.CreateStudentApplication(criteriaToAnswer, this.currentScholarshipApplication))
            {
                return;
            }

            this.OnCloseClick(sender, e);
        }
    }
}
