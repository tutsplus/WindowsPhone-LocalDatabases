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
    public partial class Update : PhoneApplicationPage
    {
        String id, nam, email_id;
        public Update()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(email.Text) )
            { 
                DatabaseUpdate update = new DatabaseUpdate();
                update.UpdateUser(Convert.ToInt32(id),name.Text,email.Text);
            }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            id=NavigationContext.QueryString["id"];
        }
    }
}