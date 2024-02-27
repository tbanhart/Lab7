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
    public partial class FormNewAccount : Form
    {
        // Artist variables
        string _artistName = string.Empty;
        string _date = string.Empty;
        string _genre = string.Empty;  

        // Song variables
        string _album = string.Empty;
        string _length = string.Empty;
        string _bpm = string.Empty;

        // Column names
        static string _artistNameColumn = string.Empty;
        static string _dateColumn = string.Empty;
        static string _genreColumn = string.Empty;
        static string _albumColumn = string.Empty;
        static string _lengthColumn = string.Empty;
        static string _bpmColumn = string.Empty;

        public FormNewAccount()
        {
            InitializeComponent();
        }

        // Validate email - shared code could use a class
        bool ValidateEmail()
        {
            bool isValid = false;
            
            // NYI try to find where the instructor buried the it in lectures

            return isValid;
        }

        // Submit the input data to the required tables
        void SubmitData()
        {
            // Convert bpm to an int
            // Convert date to a datetime (if necessary)
            // Convert length (if necessary)

            // Validate Email

            // Open connection
            // Fill in column names
            // Push data to table
            // Display results
        }
    }
}
