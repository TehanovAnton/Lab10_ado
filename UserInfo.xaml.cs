using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork10_ado
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        private MainWindow mainWindow { get; set; }

        private RelayCommand click;
        public RelayCommand Click
        {
            get
            {
                return click ?? new RelayCommand(
                        obj =>
                        {
                            OpenFileDialog dialog = new OpenFileDialog();
                            if (dialog.ShowDialog() == true)
                            {
                                var imageBitMap = new BitmapImage();
                                imageBitMap.BeginInit();
                                imageBitMap.UriSource = new Uri(dialog.FileName);
                                imageBitMap.EndInit();
                                image.Source = imageBitMap;
                            }
                        }
                    );
            }
        }

        private RelayCommand save;
        public RelayCommand Save
        {
            get
            {
                return save ?? new RelayCommand(
                        obj =>
                        {
                            Uri uri = (image.Source as BitmapImage).UriSource;
                            byte[] imageBytes = File.ReadAllBytes(uri.OriginalString);
                            User user = new User(nameInput.Text, lastNameInput.Text, mailAdressInput.Text, birthdayInput.SelectedDate.Value, imageBytes, mainWindow.userLogInfo);
                            DB.SaveUser(user);

                            mainWindow.user = user;
                            MessageBox.Show(user.lastName, "");
                            mainWindow.AppFrame = mainWindow.ObservInfo;
                        }
                    );
            }
        }
        public UserInfo(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = this;
        }
    }
}
