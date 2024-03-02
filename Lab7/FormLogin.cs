/* Login Form
 * Authors: Trevor Banhart
 * Date 02/26/2024
 * Description:
 *  This form allows users to enter their credentials to view all previously entered song from
 *  their username.
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
    public partial class FormLogin : Form
    {
        // Connection variables
        _233N_Mostafavi_TeamsDataSet.Swift_SongsDataTable _songs = new _233N_Mostafavi_TeamsDataSet.Swift_SongsDataTable();
        _233N_Mostafavi_TeamsDataSet.Swift_ArtistsDataTable _users = new _233N_Mostafavi_TeamsDataSet.Swift_ArtistsDataTable();

        // Input variables
        string InputEmail { get => loginEmailTextBox.Text; set => loginEmailTextBox.Text = value; }
        string InputPassword { get => loginPasswordTextBox.Text; set => loginPasswordTextBox.Text = value; }

        // Artist variables
        string Email { get => accEmailTextBox.Text; set => accEmailTextBox.Text = value; }
        string Password { get => accPasswordTextBox.Text; set => accPasswordTextBox.Text = value; }
        string ArtistName { get => artistTextBox.Text; set => artistTextBox.Text = value; }
        string City { get => cityTextBox.Text; set => cityTextBox.Text = value; }
        string State { get => stateTextBox.Text; set => stateTextBox.Text = value; }


        // Song variables
        int _selectedSong = 0;
        string SongName { get => songTextBox.Text; set => songTextBox.Text = value; }
        string Genre { get => genreTextBox.Text; set => genreTextBox.Text = value; }

        public FormLogin()
        {
            InitializeComponent();            
        }

        // Validate email - shared code could use a class
        bool ValidateEmail()
        {
            bool isValid = false;
            bool hasDomain = false;
            bool hasDomainExtension = false;

            foreach(var c in InputEmail)
            {
                if (c == '@') hasDomain = true;
                else if (hasDomain && c == '.') hasDomainExtension = true;
                else if (hasDomain && hasDomainExtension) { isValid = true; break; }
            }

            return isValid;
        }

        // Change all account info boxes readonly status
        void SetReadOnly(bool readOnly)
        {
            artistTextBox.ReadOnly = readOnly;
            songTextBox.ReadOnly = readOnly;
            genreTextBox.ReadOnly = readOnly;
            cityTextBox.ReadOnly = readOnly;
            stateTextBox.ReadOnly = readOnly;
            accEmailTextBox.ReadOnly = readOnly;
            accPasswordTextBox.ReadOnly = readOnly;
        }

        // Update song list
        void UpdateSongs(int artist)
        {
            var songAdapter = new Swift_SongsTableAdapter();
            songAdapter.FillSongs(_songs, artist);
            _selectedSong = 0;
        }

        // Input: Login
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Validate email
            if (!ValidateEmail()) { MessageBox.Show("Invalid email format."); return; }

            // Verify login info
            var adapter = new Swift_ArtistsTableAdapter();
            if ((int)adapter.ValidateLogin(InputEmail, InputPassword) == 0) { MessageBox.Show("Incorrect login credentials."); return; }
            adapter.FillArtist(_users, InputEmail);

            // Get the artist's songs
            var user = _users[0];
            UpdateSongs(user.artistID);
            var song = _songs[0];

            // If successful display the songs that are related to the artist
            accInfoGroupBox.Visible = true;
            opGroupBox.Visible = true;

            ArtistName = user.name;
            City = user.city;
            State = user.state;
            Email = user.email;
            Password = user.password;

            SongName = song.song;
            Genre = song.genre;
        }

        // Input: Account Creation
        private void newUserButton_Click(object sender, EventArgs e)
        {
            var form = new FormNewAccount();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        // Input: Exit Program
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Input: Delete Record
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Clear out artist songs to avoid null references
            var songAdapter = new Swift_SongsTableAdapter();
            foreach(var song in _songs)
            {
                songAdapter.DeleteSong(song.songID);
            }

            // Delete artist record
            var artistAdapter = new Swift_ArtistsTableAdapter();
            artistAdapter.DeleteArtist(_users[0].artistID);

            exitButton_Click(sender, e);
        }

        // Input: Enable editing
        private void reviseButton_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
            updateButton.Enabled = true;
        }

        // Input: Update Record 
        private void updateButton_Click(object sender, EventArgs e)
        {
            var songAdapter = new Swift_SongsTableAdapter();
            songAdapter.UpdateSong(SongName, Genre, _songs[_selectedSong].songID);
            UpdateSongs(_users[0].artistID);
            SetReadOnly(true);
            updateButton.Enabled = false;
        }

        // Input: Back to Login
        private void exitButton_Click(object sender, EventArgs e)
        {
            _songs.Clear();
            _users.Clear();
            loginEmailTextBox.Text = string.Empty;
            loginPasswordTextBox.Text = string.Empty;
            opGroupBox.Visible = false;
            accInfoGroupBox.Visible = false;
            SetReadOnly(true);
            updateButton.Enabled = false;
        }
    }
}
