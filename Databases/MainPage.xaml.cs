using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Databases.Resources;
using System.IO.IsolatedStorage;
using System.IO;

namespace Databases
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                if (!context.DatabaseExists())
                    MoveReferenceDatabase();
                    // context.CreateDatabase();
            }
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        public static void MoveReferenceDatabase()
        {
            // Obtain the virtual store for the application.
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();

            // Create a stream for the file in the installation folder.
            using (Stream input = Application.GetResourceStream(new Uri("Databases.sdf", UriKind.Relative)).Stream)
            {
                // Create a stream for the new file in the local folder.
                using (IsolatedStorageFileStream output = iso.CreateFile("Databases.sdf"))
                {
                    // Initialize the buffer.
                    byte[] readBuffer = new byte[4096];
                    int bytesRead = -1;

                    // Copy the file from the installation folder to the local folder. 
                    while ((bytesRead = input.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        output.Write(readBuffer, 0, bytesRead);
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddUsers.xaml",UriKind.Relative));
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AllUsers.xaml", UriKind.Relative));
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            DatabaseDelete delete = new DatabaseDelete();
            delete.DeleteAllUsers();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            DatabaseUpdate update = new DatabaseUpdate();
            update.UpdateUserToLower();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}