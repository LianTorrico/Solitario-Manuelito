using System;
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
using System.Windows.Shapes;

namespace ManuelitoWpf
{
    /// <summary>
    /// Logica di interazione per Impostazioni.xaml
    /// </summary>
    public partial class Impostazioni : Window
    {
        private string _path;
        private string _endMazzo;
        public string Path
        {
            get
            {
                return _path;
            }
        }
        public Impostazioni(string defaultPath)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.Width = 380;
            this.Height = 760;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _path = defaultPath;
            DisattivaBottoni();
            if (defaultPath == "images/carte/mazzo1/") btn_mazzo1.Background = Brushes.Cyan;
            if (defaultPath == "images/carte/mazzo2/") btn_mazzo2.Background = Brushes.Cyan;
            if (defaultPath == "images/carte/mazzo3/") btn_mazzo3.Background = Brushes.Cyan;
            if (defaultPath == "images/carte/mazzo4/") btn_mazzo4.Background = Brushes.Cyan;
            img_mazzo1.Source = new BitmapImage(new Uri("images/carte/mazzo1/1A.jpg",UriKind.Relative));
            img_mazzo2.Source = new BitmapImage(new Uri("images/carte/mazzo2/1A.png", UriKind.Relative));
            img_mazzo3.Source = new BitmapImage(new Uri("images/carte/mazzo3/1A.jpg", UriKind.Relative));
            img_mazzo4.Source = new BitmapImage(new Uri("images/carte/mazzo4/1A.png", UriKind.Relative));
            img_mazzo1.Visibility = Visibility.Visible;
            img_mazzo2.Visibility = Visibility.Visible;
            img_mazzo3.Visibility = Visibility.Visible;
            img_mazzo4.Visibility = Visibility.Visible;             
        }

        private void ClickCarta(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == btn_mazzo1)
                {
                    _path = "images/carte/mazzo1/";
                    _endMazzo = ".jpg";
                }
                else if (sender == btn_mazzo2)
                {
                    _path = "images/carte/mazzo2/";
                    _endMazzo = ".png";
                }
                else if (sender == btn_mazzo3)
                {
                    _path = "images/carte/mazzo3/";
                    _endMazzo = ".jpg";
                }
                else if (sender == btn_mazzo4)
                {
                    _path = "images/carte/mazzo4/";
                    _endMazzo = ".png";
                }
                DisattivaBottoni();
                ((Button)sender).Background = Brushes.Cyan;
                ((MenuM)Owner).AggiornaPath(_path, _endMazzo);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
        private void DisattivaBottoni()
        {
            btn_mazzo1.Background = Brushes.Transparent;
            btn_mazzo2.Background = Brushes.Transparent;
            btn_mazzo3.Background = Brushes.Transparent;
            btn_mazzo4.Background = Brushes.Transparent;
        }
    }
}
