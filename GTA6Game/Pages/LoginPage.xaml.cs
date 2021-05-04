﻿using GTA6Game.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GTA6Game.PlayerData;
using GTA6Game.UserControls;

namespace GTA6Game.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : PageBase
    {
        public int SelectedUserIndex = -1;
        public string SelectedUserName = "";

        public LoginPage()
        {
            InitializeComponent();
            RefreshUsersList();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Router.ChangeCurrentPage(new AddUser());
        }

        private void RefreshUsersList()
        {
            WpUserIconContainer.Children.Clear();
            foreach (var i in SaveLoader.Save.Profiles)
            {
                UserIcon newUser = new UserIcon();
                newUser.Content = i.Name;
                newUser.Style = this.FindResource("UserIconStyle") as Style;
                newUser.Click += new RoutedEventHandler(UserIcon_Click);
                WpUserIconContainer.Children.Add(newUser);
            }
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUserIndex == 1)
            {
                if (TboxPassword.Text == "admin123")
                {
                    Router.StartGame = true;
                    Router.ChangeCurrentPage(new LoadingPage());
                }
                else
                {
                    MessageBox.Show("Helytelen jelszó!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
            }
        }

        private void UserIcon_Click(object sender, RoutedEventArgs e)
        {
            Button selectedUser = (Button)sender;
            SelectedUserName = (string)selectedUser.Content;
            SelectedUserIndex = WpUserIconContainer.Children.IndexOf(selectedUser);
            for (int i = 0; i < WpUserIconContainer.Children.Count; i++)
            {
                Button navButton = (Button)WpUserIconContainer.Children[i];
                if (i != SelectedUserIndex)
                {
                    navButton.IsEnabled = true;
                }
                else
                {
                    navButton.IsEnabled = false;
                }
            }
        }

        private void BtnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            //SaveLoader.Save.Profiles.RemoveAllProfiles();
            Profile prof = null;
            foreach (var i in SaveLoader.Save.Profiles.Where(x => x.Name == SelectedUserName))
            {
                prof = i;
            }

            SaveLoader.Save.Profiles.RemoveProfile(prof);
            RefreshUsersList();
        }
    }
}
