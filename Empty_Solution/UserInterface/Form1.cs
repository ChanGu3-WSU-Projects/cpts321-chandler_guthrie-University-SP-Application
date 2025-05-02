// <copyright file="Form1.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using LogicEngine;

namespace UserInterface
{
    /// <summary>
    /// UserInterface For the Application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// the current panel that the form is on.
        /// </summary>
        private Panel currentPanel;

        /// <summary>
        /// the event manager that controls all actions.
        /// </summary>
        private ControllerManager controllerManager;

#pragma warning disable CS8618
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.UISetup();
            this.controllerManager = new ControllerManager();
            this.controllerManager.UserChanged += this.ChangeOfUser!;
        }
#pragma warning restore CS8618

        /// <summary>
        /// called when the application first starts.
        /// </summary>
        private void UISetup()
        {
            // home panel disable
            WinformObjects.HideDisableControlObject(this.panelHome);
            WinformObjects.HideDisableControlObject(this.dataGridViewHomeProjects);
            WinformObjects.HideDisableControlObject(this.dataGridViewHomeScholarships);

            // loginregister panel disable
            WinformObjects.HideDisableControlObject(this.panelLogin);
            this.labelLoginNotice.Visible = false;

            // PopUp panels disable
            // Under Maintanance Panel
            WinformObjects.HideDisableControlObject(this.panelUnderMaintanance);
            WinformObjects.SetNewParentForControlChild(this, this.panelUnderMaintanance);

            // Project More Info Panel
            WinformObjects.HideDisableControlObject(this.panelProjectMoreInfo);
            WinformObjects.SetNewParentForControlChild(this, this.panelProjectMoreInfo);

            // Scholarship More Info Panel
            WinformObjects.HideDisableControlObject(this.panelScholarshipViewMore);
            WinformObjects.SetNewParentForControlChild(this, this.panelScholarshipViewMore);

            // Student Application Panel
            WinformObjects.HideDisableControlObject(this.panelApplicationStudent);
            WinformObjects.SetNewParentForControlChild(this, this.panelApplicationStudent);

            // Register Panel (IsPopUp)
            WinformObjects.HideDisableControlObject(this.panelRegister);
            WinformObjects.SetNewParentForControlChild(this, this.panelRegister);

            // Register Required Panel
            WinformObjects.HideDisableControlObject(this.panelRegisterRequired);
            WinformObjects.SetNewParentForControlChild(this, this.panelRegisterRequired);

            // Profile Panel
            WinformObjects.HideDisableControlObject(this.panelProfile);
            WinformObjects.SetNewParentForControlChild(this, this.panelProfile);
            WinformObjects.HideDisableControlObject(this.panelProfileStudent);
            WinformObjects.HideDisableControlObject(this.panelProfileDonor);

            // Student Panel
            WinformObjects.HideDisableControlObject(this.panelStudent);
            WinformObjects.SetNewParentForControlChild(this, this.panelStudent);
            this.toolStripButtonUser.Visible = false;
            this.toolStripButtonUser.Enabled = false;

            // StudentNewProject Panel
            WinformObjects.HideDisableControlObject(this.panelStudentNewProject);
            WinformObjects.SetNewParentForControlChild(this, this.panelStudentNewProject);

            // home panel enable for first start of program
            WinformObjects.UnHideEnableControlObject(this.panelHome);
            this.currentPanel = this.panelHome;
        }

        /// <summary>
        /// opens the pop up disabling controls from the current panel and the toolstrip.
        /// </summary>
        private void OpenPopUp(Control panelPopUp)
        {
            // disable background
            this.currentPanel.Enabled = false;
            this.toolStrip.Enabled = false;

            // open pop up
            panelPopUp.BringToFront();
            WinformObjects.UnHideEnableControlObject(panelPopUp);
        }

        /// <summary>
        /// closes the pop up enabling controls from the current panel and the toolstrip.
        /// </summary>
        private void ClosePopUp(Control panelPopUp)
        {
            // close pop pu
            WinformObjects.HideDisableControlObject(panelPopUp);

            // enable background
            this.currentPanel.Enabled = true;
            this.toolStrip.Enabled = true;
        }

        /// <summary>
        /// clicking the button Home.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguemnts. </param>
        private void OnButtonHomeClick(object sender, EventArgs e)
        {
            if (this.currentPanel == this.panelHome)
            {
                return;
            }

            WinformObjects.HideDisableControlObject(this.currentPanel);
            this.currentPanel = this.panelHome;
            this.ResetHomePanel();
            WinformObjects.UnHideEnableControlObject(this.panelHome);
        }

        /// <summary>
        /// clicking the button where it says profile, login/register.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguemnts. </param>
        private void OnButtonLoginRegisterOrProfileClick(object sender, EventArgs e)
        {
            // When changing view to the same view dont do anything.
            if (this.currentPanel == this.panelLogin || this.currentPanel == this.panelProfile)
            {
                return;
            }

            WinformObjects.HideDisableControlObject(this.currentPanel);

            // displays specific profile user info if logged in otherwise user is guest and login is opened.
            if (this.controllerManager.CurrentUserState == UserState.GUEST)
            {
                this.currentPanel = this.panelLogin;
                this.ResetLoginCredentials();
                WinformObjects.UnHideEnableControlObject(this.panelLogin);
            }
            else if (this.controllerManager.CurrentUserState == UserState.STUDENT)
            {
                this.currentPanel = this.panelProfile;
                this.ResetPanelProfileInfo();
                this.PopulateStudentProfileInfo();
                WinformObjects.UnHideEnableControlObject(this.panelProfile);
                WinformObjects.UnHideEnableControlObject(this.panelProfileStudent);
            }
            else if (this.controllerManager.CurrentUserState == UserState.DONOR)
            {
                this.currentPanel = this.panelProfile;
                this.ResetPanelProfileInfo();
                this.PopulateDonorProfileInfo();
                WinformObjects.UnHideEnableControlObject(this.panelProfile);
                WinformObjects.UnHideEnableControlObject(this.panelProfileDonor);
            }
        }

        /// <summary>
        /// clicking the button will bring you to student abilites.
        /// </summary>
        /// <param name="sender"> student button. </param>
        /// <param name="e"> arguments. </param>
        private void OnButtonStudentClick(object sender, EventArgs e)
        {
            if (this.currentPanel == this.panelStudent)
            {
                return;
            }

            WinformObjects.HideDisableControlObject(this.currentPanel);
            this.currentPanel = this.panelStudent;
            this.PopulateStudentProjects();
            WinformObjects.UnHideEnableControlObject(this.panelStudent);
        }

        /// <summary>
        /// closes the panel only if button is the child of it.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguments. </param>
        private void OnCloseClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button is not null)
            {
                if (button.Parent is not null)
                {
                    if (button.Parent.GetType() == typeof(Panel))
                    {
                        this.ClosePopUp(button.Parent);
                    }
                }
            }
        }

        /// <summary>
        /// changes the user based on IUser type.
        /// </summary>
        /// <param name="sender"> user type. </param>
        /// <param name="e"> arguments. </param>
        private void ChangeOfUser(object sender, EventArgs e)
        {
            // means user has logged out.
            if (this.controllerManager.CurrentUserState == UserState.GUEST)
            {
                this.toolStripbuttonLoginRegisterNProfile.Text = "Login/Register";

                // make toolstripbutton user empty and disable it.
                this.toolStripButtonUser.Text = string.Empty;
                this.toolStripButtonUser.Visible = false;
                this.toolStripButtonUser.Enabled = false;
            }

            // User is logged in.
            else
            {
                this.toolStripbuttonLoginRegisterNProfile.Text = "Profile";

                if (this.controllerManager.CurrentUserState == UserState.STUDENT)
                {
                    // set the button to a student button and enable it.
                    this.toolStripButtonUser.Text = "Student";
                    this.toolStripButtonUser.Visible = true;
                    this.toolStripButtonUser.Enabled = true;
                }
                else if (this.controllerManager.CurrentUserState == UserState.DONOR)
                {
                }
            }
        }
    }
}
