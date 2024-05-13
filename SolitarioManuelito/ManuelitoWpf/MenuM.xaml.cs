using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace ManuelitoWpf
{
    /// <summary>
    /// Logica di interazione per Menu.xaml
    /// </summary>
    public partial class MenuM : Window
    {
        string pathMazzo;
        string endMazzo;
        public MenuM()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.Width = 380;
            this.Height = 760;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            pathMazzo = "images/carte/mazzo1/";
            endMazzo = ".jpg";
        }
        public MenuM(string nome, string oldPathMazzo, string oldEndMazzo):this()
        {
            txb_nome.Text = nome;
            pathMazzo = oldPathMazzo;
            endMazzo = oldEndMazzo;
        }
        public void AggiornaPath(string newPath,string newEndMazzo)
        {
            pathMazzo = newPath;
            endMazzo = newEndMazzo;
        }

        private void btn_Gioca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PartitaM partitaM = new PartitaM(txb_nome.Text,pathMazzo,endMazzo);
                partitaM.Owner = this;
                partitaM.Show();
                partitaM.Owner = null;
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
        private void btn_regole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/LianTorrico/Solitario-Manuelito/blob/main/README.md",
                    UseShellExecute = true
                });
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Classifica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classifica classifica = new Classifica();
                classifica.Show();
                classifica.Owner = this;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SvuotaTextBox(object sender, RoutedEventArgs e)
        {
            txb_nome.Text = String.Empty;
        }
        private void btn_Impostazioni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Impostazioni impostazioni = new Impostazioni(pathMazzo);
                impostazioni.Show();
                impostazioni.Owner = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
