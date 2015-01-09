using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Databases
{
    public partial class AllUsers : PhoneApplicationPage
    {
        public AllUsers()
        {
            InitializeComponent();
            FetchDatabase fetch = new FetchDatabase();
            allusers.ItemsSource = fetch.getUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String id = btn.Tag.ToString();
            DatabaseDelete delete = new DatabaseDelete();
            delete.DeleteUser(id);
            FetchDatabase fetch = new FetchDatabase();
            allusers.ItemsSource = fetch.getUsers();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String id = btn.Tag.ToString();
            NavigationService.Navigate(new Uri("/Update.xaml?id="+id,UriKind.Relative));
        }
    }
}