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
    public partial class AddUsers : PhoneApplicationPage
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nam = name.Text;
            String eml = email.Text;
            DatabaseAdd add=new DatabaseAdd();
            if (!String.IsNullOrEmpty(nam) && !String.IsNullOrEmpty(eml))
                add.AddUser(nam,eml);
        }
    }
}