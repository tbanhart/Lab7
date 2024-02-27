/* Login Form
 * Authors: Trevor Banhart
 * Date 02/26/2024
 * Description:
 *  This form allows users to enter their credentials to view all previously entered song from
 *  their username.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class FormLogin : Form
    {
        string _username = string.Empty;
        string _password = string.Empty;

        static string _usernameColumn = string.Empty;
        static string _passwordColumn = string.Empty;

        public FormLogin()
        {
            InitializeComponent();
        }
    
        // Get the username and password from textboxes
        void GetLogin()
        {
            // _username = TEXTUSERNAME
            // _password = TEXTPASSWORD
        }

        // Validate email - shared code could use a class
        bool ValidateEmail()
        {
            bool isValid = false;

            // NYI try to find where the instructor buried the it in lectures

            return isValid;
        }

        // Check login with server
        bool VerifyLogin()
        {
            bool isValid = false;
            
            // open connection
            // select where _usernameColumn = _username & _passwordColumn = _password
            
            return isValid;
        }

        // Attempt a login
        void Login()
        {
            // Validate email
            
            // Verify login info
            // If successful display the songs that are related to the artist
        }
    }
}
