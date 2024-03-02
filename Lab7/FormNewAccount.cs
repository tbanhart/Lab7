/* New Account Form
 * Authors: Trevor Banhart
 * Date: 02/26/2024
 * Description:
 *  This allows users to add new data to the song and artist tables in the 233N Database 
 */

using Lab7._233N_Mostafavi_TeamsDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class FormNewAccount : Form
    {
        // Database variables
        _233N_Mostafavi_TeamsDataSet.Swift_ArtistsDataTable _artists = new _233N_Mostafavi_TeamsDataSet.Swift_ArtistsDataTable();
        _233N_Mostafavi_TeamsDataSet.Swift_SongsDataTable _songs = new _233N_Mostafavi_TeamsDataSet.Swift_SongsDataTable();

        // Artist variables
        string InputEmail { get => emailTextBox.Text; set => emailTextBox.Text = value; }
        string Password { get => passwordTextBox.Text; set => passwordTextBox.Text = value; }
        string ArtistName { get => artistTextBox.Text; set => artistTextBox.Text = value; }
        string City { get => cityTextBox.Text; set => cityTextBox.Text = value; }
        string State { get => stateTextBox.Text; set => stateTextBox.Text = value; }

        // Song variables
        string SongName { get => songTextBox.Text; set => songTextBox.Text = value; }
        string Genre { get => genreTextBox.Text; set => genreTextBox.Text = value; }

        public FormNewAccount()
        {
            InitializeComponent();
        }

        // Validate email - shared code could use a class
        bool ValidateEmail()
        {
            bool isValid = false;
            bool hasDomain = false;
            bool hasDomainExtension = false;

            foreach (var c in InputEmail)
            {
                if (c == '@') hasDomain = true;
                else if (hasDomain && c == '.') hasDomainExtension = true;
                else if (hasDomain && hasDomainExtension) { isValid = true; break; }
            }

            return isValid;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Input: Add records to database
        private void createButton_Click(object sender, EventArgs e)
        {
            ValidateEmail();

            // Check if song already exists
            var songAdapter = new Swift_SongsTableAdapter();
            if((int)songAdapter.ValidateSong(SongName) > 0) { MessageBox.Show("Song already exists, check name and try again."); return; }

            // Add the user if needed
            var artistAdapter = new Swift_ArtistsTableAdapter();
            if ((int)artistAdapter.ValidateLogin(InputEmail, Password) == 0)
            {
                artistAdapter.AddArtist(ArtistName, InputEmail, Password, City, State);
                MessageBox.Show("User not found, creating login.");
            }
            else
            {
                // Confirms song has been added if user already exists
                MessageBox.Show("New song has been added to user.");
            }

            // Add the song information
            artistAdapter.FillArtist(_artists, InputEmail);
            songAdapter.AddSong(SongName, Genre, _artists[0].artistID);

            // Reset song info boxes to prepare for the next song
            SongName = string.Empty;
            Genre = string.Empty;
        }

        // Input: Clear boxes
        private void clearButton_Click(object sender, EventArgs e)
        {
            ArtistName = string.Empty;
            SongName = string.Empty;
            Genre = string.Empty;
            City = string.Empty;
            State = string.Empty;
            InputEmail = string.Empty;
            Password = string.Empty;
        }

        private void FormNewAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
