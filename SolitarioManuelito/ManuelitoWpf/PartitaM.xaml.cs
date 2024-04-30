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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SolitarioClassi;
using static System.Net.Mime.MediaTypeNames;

namespace ManuelitoWpf
{
    /// <summary>
    /// Logica di interazione per Partita.xaml
    /// </summary>
    public partial class PartitaM : Window
    {
        PartitaManuelito partitaManuelito;
        bool modalitaSelezioneCarta;
        Carta cartaDaSpostare;
        Posizioni posizioneDaSpostare;
        int mazzoDaSpostare;
        Posizioni posizioneArrivo;
        Button btnCartaSelezionata;
        int mazzoArrivo;

        public PartitaM()
        {
            InitializeComponent();
            partitaManuelito = new PartitaManuelito();
            modalitaSelezioneCarta = true;
            AggiornaImmagini();
            BottoniInvisibili();
            this.ResizeMode = ResizeMode.NoResize;
            Height = 760;
            Width = 380;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        private void BottoniInvisibili()
        {
            btn_ausiliare1.Background = Brushes.Transparent;
            btn_ausiliare2.Background = Brushes.Transparent;
            btn_ausiliare3.Background = Brushes.Transparent;
            btn_ausiliare4.Background = Brushes.Transparent;
            btn_finale1.Background = Brushes.Transparent;
            btn_finale2.Background = Brushes.Transparent;
            btn_finale3.Background = Brushes.Transparent;
            btn_finale4.Background = Brushes.Transparent;
            btn_cartaestratta_1.Background = Brushes.Transparent;
            btn_mazzo.Background = Brushes.Transparent;
        }
        private void SelezionaCartaDaBottone(object sender)
        {
            Exception ex = new Exception("Carta non presente");
            if (sender == btn_ausiliare1)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 1) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 1);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 1;
            }
            else if (sender == btn_ausiliare2)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 2) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 2);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 2;
            }
            else if (sender == btn_ausiliare3)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 3) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 3);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 3;
            }
            else if (sender == btn_ausiliare4)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 4) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 4);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 4;
            }
            else if (sender == btn_finale1)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 1) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 1);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 1;
            }
            else if (sender == btn_finale2)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 2) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 2);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 2;
            }
            else if (sender == btn_finale3)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 3) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 3);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 3;
            }
            else if (sender == btn_finale4)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 4) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 4);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 4;
            }
            else if (sender == btn_cartaestratta_1)
            {
                if (partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1) == null) throw ex;
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1);
                posizioneDaSpostare = Posizioni.Centrale;
                mazzoDaSpostare = 1;
            }
        }
        private void SelezionaPosizioniArrivo(object sender)
        {
            if (sender == btn_ausiliare1)
            {
                posizioneArrivo = Posizioni.Ausiliarie;
                mazzoArrivo = 1;
            }
            else if (sender == btn_ausiliare2)
            {
                posizioneArrivo = Posizioni.Ausiliarie;
                mazzoArrivo = 2;
            }
            else if (sender == btn_ausiliare3)
            {
                posizioneArrivo = Posizioni.Ausiliarie;
                mazzoArrivo = 3;
            }
            else if (sender == btn_ausiliare4)
            {
                posizioneArrivo = Posizioni.Ausiliarie;
                mazzoArrivo = 4;
            }
            else if (sender == btn_finale1)
            {
                posizioneArrivo = Posizioni.Finali;
                mazzoArrivo = 1;
            }
            else if (sender == btn_finale2)
            {
                posizioneArrivo = Posizioni.Finali;
                mazzoArrivo = 2;
            }
            else if (sender == btn_finale3)
            {
                posizioneArrivo = Posizioni.Finali;
                mazzoArrivo = 3;
            }
            else if (sender == btn_finale4)
            {
                posizioneArrivo = Posizioni.Finali;
                mazzoArrivo = 4;
            }
            else if (sender == btn_cartaestratta_1)
            {
                posizioneArrivo = Posizioni.Centrale;
                mazzoArrivo = 1;
            }
        }
        private void ClickCarta(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modalitaSelezioneCarta)
                {
                    SelezionaCartaDaBottone(sender);
                    btnCartaSelezionata = (Button)sender;
                    modalitaSelezioneCarta = false;
                    btnCartaSelezionata.Background = Brushes.Cyan;
                }
                else
                {
                    if ((Button)sender == btnCartaSelezionata)
                    {
                        modalitaSelezioneCarta = true;
                        btnCartaSelezionata.Background = Brushes.Transparent;
                    }
                    else
                    {
                        SelezionaPosizioniArrivo(sender);
                        partitaManuelito.MuoviCarta(posizioneDaSpostare, mazzoDaSpostare, posizioneArrivo, mazzoArrivo);
                        modalitaSelezioneCarta = true;
                        AggiornaImmagini();
                        btnCartaSelezionata.Background = Brushes.Transparent;
                    }
                }
                if (partitaManuelito.VerificaVittoria) Vittoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void mazzo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (partitaManuelito.Mazzo.Vuoto)
                {
                    partitaManuelito.RicostruisciMazzo();
                }
                else
                {
                    partitaManuelito.PescaMano();
                }
                AggiornaImmagini();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AggiornaImmagini()
        {
            Carta? carta;
            string nomeImg;
            //ausiliare 1
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 1);
            if (carta == null)
            {
                img_ausiliare1.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_ausiliare1.Visibility = Visibility.Visible;
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_ausiliare1.Source = new BitmapImage(uriSource);
            }
            //ausiliare 2
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 2);
            if (carta == null)
            {
                img_ausiliare2.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_ausiliare2.Visibility = Visibility.Visible;
                img_ausiliare2.Source = new BitmapImage(uriSource);
            }
            //ausiliare 3
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 3);
            if (carta == null)
            {
                img_ausiliare3.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_ausiliare3.Visibility = Visibility.Visible;
                img_ausiliare3.Source = new BitmapImage(uriSource);
            }
            //ausiliare 4
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 4);
            if (carta == null)
            {
                img_ausiliare4.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_ausiliare4.Visibility = Visibility.Visible;
                img_ausiliare4.Source = new BitmapImage(uriSource);
            }
            //finale 1
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 1);
            if (carta == null)
            {
                img_finale1.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_finale1.Visibility = Visibility.Visible;
                img_finale1.Source = new BitmapImage(uriSource);
            }
            //finale 2
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 2);
            if (carta == null)
            {
                img_finale2.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_finale2.Visibility = Visibility.Visible;
                img_finale2.Source = new BitmapImage(uriSource);
            }
            //finale 3
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 3);
            if (carta == null)
            {
                img_finale3.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_finale3.Visibility = Visibility.Visible;
                img_finale3.Source = new BitmapImage(uriSource);
            }
            //finale 4
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 4);
            if (carta == null)
            {
                img_finale4.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_finale4.Visibility = Visibility.Visible;
                img_finale4.Source = new BitmapImage(uriSource);
            }
            //centro 1
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1);
            if (carta == null)
            {
                img_cartaEstratta1.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_cartaEstratta1.Visibility = Visibility.Visible;
                img_cartaEstratta1.Source = new BitmapImage(uriSource);
            }
            //centro 2
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 2);
            if (carta == null)
            {
                img_cartaEstratta2.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_cartaEstratta2.Visibility = Visibility.Visible;
                img_cartaEstratta2.Source = new BitmapImage(uriSource);
            }
            //centro 3
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 3);
            if (carta == null)
            {
                img_cartaEstratta3.Visibility = Visibility.Collapsed;
            }
            else
            {
                nomeImg = "/images/Carte/" + ((int)(carta.Valore)).ToString() + carta.Seme.ToString() + ".jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_cartaEstratta3.Visibility = Visibility.Visible;
                img_cartaEstratta3.Source = new BitmapImage(uriSource);
            }
            //mazzo
            if (partitaManuelito.Mazzo.Vuoto)
            {
                img_mazzo.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_mazzo.Visibility = Visibility.Visible;
                nomeImg = "/images/Carte/RETRO.jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_mazzo.Source = new BitmapImage(uriSource);
            }
        }

        private void btn_Resa_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vuoi giocare ancora?",
                    "Sconfitta",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                PartitaM p = new PartitaM();
                p.Owner = this;
                p.Show();
                p.Owner = null;
            }
            this.Close();
        }   
            
            
        private void Vittoria()
        {
            if (MessageBox.Show("Vuoi giocare ancora?",
                    "Vittoria",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                PartitaM p = new PartitaM();
                p.Owner = this;
                p.Show();
                p.Owner = null;
            }
            this.Close();
        }
    }
}
