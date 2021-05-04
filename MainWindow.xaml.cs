using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace LabWork10_ado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public UserLogInfo userLogInfo { get; set; }
        public User user{ get; set; }

        private Page observInfo;
        public Page ObservInfo
        {
            get { return observInfo; }
            set
            {
                observInfo = value;
                OnPropertyChanged("ObservInfo");
            }
        }

        private Page userInfoFrame;
        public Page UserInfoFrame
        {
            get { return userInfoFrame; }
            set
            {
                userInfoFrame = value;
                OnPropertyChanged("userInof");
            }
        }

        private Page appFrame;
        public Page AppFrame
        {
            get { return appFrame; }
            set
            {
                appFrame = value;
                OnPropertyChanged("AppFrame");
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            AppFrame = new LogIn(this);
            UserInfoFrame = new UserInfo(this);
            ObservInfo = new ObservInfo(this);

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
