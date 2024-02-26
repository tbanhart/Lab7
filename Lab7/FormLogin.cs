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
        string _username { get; set; }
        string _password { get; set; }

        static string _usernameColumn = string.Empty;
        static string _passwordColumn = string.Empty;

        public FormLogin()
        {
            InitializeComponent();
            _username = string.Empty;
            _password = string.Empty;
        }
    
        // Get the username and password from textboxes
        void GetLogin()
        {
            // _username = TEXTUSERNAME
            // _password = TEXTPASSWORD
        }

        // Validate email
        void ValidateEmail()
        {
            // NYI try to find where the instructor buried the it in lectures
        }

        // Check login with server
        bool VerifyLogin()
        {
            bool isValid = false;
            
            // open connection
            // select where _usernameColumn = _username & _passwordColumn = _password
            
            return isValid;
        }
    }
}
