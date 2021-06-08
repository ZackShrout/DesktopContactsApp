using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWIndow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        // STATE
        Contact contact;
        
        // PUBLIC
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneNumberTextBox.Text = contact.PhoneNumber;
        }

        // PRIVATE
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.PhoneNumber = phoneNumberTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // make sure database exists
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // make sure database exists
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();
        }
    }
}
