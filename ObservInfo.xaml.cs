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
    /// Логика взаимодействия для ObservInfo.xaml
    /// </summary>
    public partial class ObservInfo : Page
    {
        enum UserField
        {
            name, lastName, mail, birthDay, imageData, nan
        }

        private UserField field {get; set;}

        private MainWindow mainWindow { get; set; }

        private RelayCommand next;
        public RelayCommand Next
        {
            get
            {
                return next ?? new RelayCommand(
                        obj =>
                        {
                            if (field == UserField.nan) {
                                nameInput.Text = mainWindow.user.name;
                                field = UserField.name;
                            }
                            else if (field == UserField.name) {
                                nameInput.Text = "";
                                lastNameInput.Text = mainWindow.user.lastName;
                                field = UserField.lastName;
                            }
                            else if (field == UserField.lastName) {
                                lastNameInput.Text = "";
                                mailAdressInput.Text = mainWindow.user.mail;
                                field = UserField.mail;
                            }
                            else if (field == UserField.mail) {
                                mailAdressInput.Text = "";
                                birthdayInput.SelectedDate = mainWindow.user.dateDay;
                                field = UserField.birthDay;
                            }
                            else if (field == UserField.birthDay) {

                                using (MemoryStream ms = new MemoryStream(mainWindow.user.imageData))
                                {
                                    BitmapImage imageBMP = new BitmapImage();
                                    imageBMP.BeginInit();
                                    imageBMP.CacheOption = BitmapCacheOption.OnLoad;
                                    imageBMP.StreamSource = ms;
                                    imageBMP.EndInit();
                                    image.Source = imageBMP;
                                }
                                field = UserField.imageData;
                            }
                            else if (field == UserField.imageData) {
                                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\лабораторные\решения\LabWork10_ado\images\Add.png")))
                                {
                                    BitmapImage imageBMP = new BitmapImage();
                                    imageBMP.BeginInit();
                                    imageBMP.StreamSource = ms;
                                    imageBMP.EndInit();
                                    image.Source = imageBMP;
                                }                                

                                field = UserField.nan;
                            }
                        }
                    );
            }
        }

        private RelayCommand privious;
        public RelayCommand Privious
        {
            get
            {
                return privious ?? new RelayCommand(
                        obj =>
                        {
                            if (field == UserField.nan)
                            {
                                using (MemoryStream ms = new MemoryStream(mainWindow.user.imageData))
                                {
                                    BitmapImage imageBMP = new BitmapImage();
                                    imageBMP.BeginInit();
                                    imageBMP.CacheOption = BitmapCacheOption.OnLoad;
                                    imageBMP.StreamSource = ms;
                                    imageBMP.EndInit();
                                    image.Source = imageBMP;
                                }
                                field = UserField.imageData;                                
                            }
                            else if (field == UserField.name)
                            {
                                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\лабораторные\решения\LabWork10_ado\images\Add.png")))
                                {
                                    BitmapImage imageBMP = new BitmapImage();
                                    imageBMP.BeginInit();
                                    imageBMP.CacheOption = BitmapCacheOption.OnLoad;
                                    imageBMP.StreamSource = ms;
                                    imageBMP.EndInit();
                                    image.Source = imageBMP;
                                }
                                field = UserField.nan;
                                nameInput.Text = "";
                            }
                            else if (field == UserField.lastName)
                            {
                                nameInput.Text = mainWindow.user.name;
                                field = UserField.name;

                                lastNameInput.Text = "";
                            }
                            else if (field == UserField.mail)
                            {
                                lastNameInput.Text = mainWindow.user.lastName;
                                field = UserField.lastName;
                                mailAdressInput.Text = "";
                            }
                            else if (field == UserField.birthDay)
                            {
                                lastNameInput.Text = "";
                                mailAdressInput.Text = mainWindow.user.mail;
                                field = UserField.mail;
                            }
                            else if (field == UserField.imageData)
                            {
                                birthdayInput.SelectedDate = mainWindow.user.dateDay;
                                field = UserField.birthDay;

                                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(@"C:\Users\Anton\source\repos\pacei_NV_OOTP\лабораторные\решения\LabWork10_ado\images\Add.png")))
                                {
                                    BitmapImage imageBMP = new BitmapImage();
                                    imageBMP.BeginInit();
                                    imageBMP.CacheOption = BitmapCacheOption.OnLoad;
                                    imageBMP.StreamSource = ms;
                                    imageBMP.EndInit();
                                    image.Source = imageBMP;
                                }
                            }
                        }
                    );
            }
        }

        private RelayCommand edit;
        public RelayCommand Edit
        {
            get
            {
                return edit ?? new RelayCommand(
                        obj =>
                        {
                             
                            if (field == UserField.name)
                            {
                                mainWindow.user.name = nameInput.Text;
                            }
                            else if (field == UserField.lastName)
                            {
                                
                            }
                            else if (field == UserField.mail)
                            {
                               
                            }
                            else if (field == UserField.birthDay)
                            {
                               
                            }
                            else if (field == UserField.imageData)
                            {
                                
                            }

                            DB.EditUser(mainWindow.user);
                        }
                    );
            }
        }

        private RelayCommand delete;
        public RelayCommand Delete
        {
            get
            {
                return edit ?? new RelayCommand(
                        obj =>
                        {
                            DB.DeleteUser(mainWindow.user);
                        }
                    );
            }
        }


        public ObservInfo(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            field = UserField.nan;

            DataContext = this;
        }
    }
}
