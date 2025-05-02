// <copyright file="LoginPanelForm1.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using LogicEngine;

namespace UserInterface
{
    /// <summary>
    /// Login panel logic for Form1.
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// set the textboxes in login to empty.
        /// </summary>
        private void ResetLoginCredentials()
        {
            this.textBoxLoginUsername.Text = string.Empty;
            this.textBoxLoginPassword.Text = string.Empty;
            this.labelLoginNotice.Visible = false;
        }

        /// <summary>
        /// opens register panel.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguments. </param>
        private void OnRegisterClick(object sender, EventArgs e)
        {
            this.ResetLoginCredentials();
            this.OpenPopUp(this.panelRegister);
        }

        /// <summary>
        /// attemps a login when the button is clicked.
        /// </summary>
        /// <param name="sender"> button. </param>
        /// <param name="e"> arguments. </param>
        private void OnCompleteLoginClick(object sender, EventArgs e)
        {
            if (this.controllerManager.TryLoginUser(this.textBoxLoginUsername.Text, this.textBoxLoginPassword.Text))
            {
                this.ResetLoginCredentials();

                WinformObjects.HideDisableControlObject(this.currentPanel);
                this.currentPanel = this.panelHome;
                this.ResetHomePanel();
                WinformObjects.UnHideEnableControlObject(this.panelHome);
            }
            else
            {
                this.labelLoginNotice.Visible = true;
            }
        }
    }
}
