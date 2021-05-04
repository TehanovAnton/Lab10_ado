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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork10_ado
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        private MainWindow mainWindow { get; set; }

        private RelayCommand logInUser;
        public RelayCommand LogInUser
        {
            get
            {
                return logInUser ?? new RelayCommand(
                        obj =>
                        {
                            //поиск в бд и перехож на userInfo
                            if (DB.LogIn(nickNameInput.Text, int.Parse(passwordInput.Text)))
                            {
                                UserLogInfo userLogInfo = new UserLogInfo(nickNameInput.Text, int.Parse(passwordInput.Text));
                                mainWindow.userLogInfo = userLogInfo;
                                mainWindow.AppFrame = mainWindow.UserInfoFrame;
                            }
                        }
                    );
            }
        }

        public LogIn(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = this;
        }
    }
}
