using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GTA6Game.Helpers;

namespace GTA6Game.PlayerData
{
    [Serializable]
    public class Profile : PropertyChangeNotifier, IDisposable
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private int money;

        public int Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                money = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private int avatarId;

        public int AvatarId
        {
            get { return avatarId; }
            set 
            { 
                avatarId = value;
                OnPropertyChanged();
            }
        }

        private string dateOfBirth;

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set 
            { 
                dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public Profile(string name, string password, string dateOfBirth/* ,int avatarId*/)
        {
            Name = name;
            Password = password;
            DateOfBirth = dateOfBirth;/*
            AvatarId = avatarId;*/
        }

        public void Dispose()
        {
            DisposePropertyChangedEvent();
        }
    }
}
