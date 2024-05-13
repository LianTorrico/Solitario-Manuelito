using SolitarioClassi;
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
    /// Logica di interazione per Classifica.xaml
    /// </summary>
    public partial class Classifica : Window
    {
        public Classifica()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.Width = 380;
            this.Height = 760;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AggiornaLista();
        }
        private void AggiornaLista()
        {
            List<string> lista = new List<string>(0);
            GestoreSalvataggi gs = new GestoreSalvataggi();
            List<(int, string)> classifica = gs.LeggiLeaderboard();
            int rank = 1;
            foreach((int,string) punteggio in classifica)
            {
                lista.Add("#"+rank.ToString()+" " +punteggio.Item2 + " - mosse: " + punteggio.Item1.ToString());
                rank++;
            }        
            if(lista.Count == 0) 
            {
                lista.Add("Nesssuna partita fatta");   
            }
            lst_classifica.ItemsSource = null;
            lst_classifica.ItemsSource = lista;
        }
    }
}
