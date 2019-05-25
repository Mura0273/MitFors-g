using System;
using System.Windows;

namespace PapasPapbar_3
{
    /// <summary>
    /// Interaction logic for Boardgame.xaml
    /// </summary>
    public partial class Boardgame : Window
    {
        public Boardgame()
        {
            InitializeComponent();
        }

    private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtBrætspil.Text = "";
            txtAntal.Text = "";
            txtAldersgruppe.Text = "";
            txtSpilletid.Text = "";
            txtDistrubutør.Text = "";
            txtGenre.Text = "";
            txtBrætspil.Focus();
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnInsert.IsEnabled = true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Domain.Boardgame p = new Domain.Boardgame
            {
                boardgameName = txtBrætspil.Text,
                playerCount = txtAntal.Text,
                audience = txtAldersgruppe.Text,
                gameTime = txtSpilletid.Text,
                distributor = txtDistrubutør.Text,
                gameTag = txtGenre.Text

            };

            bool success = p.Insert(p);
            if (success == true)
            {
                MessageBox.Show("Nyt brætspil er tilføjet");
            }
            else
            {
                MessageBox.Show("Brætspil blev ikke tilføjet");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void DataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
