using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        Button[] bottoniFinali;
        Button[] bottoniAusiliari;
        int mosse;
        int? record;

        Carta? cartaDaSpostare;

        Mazzetto mazzettoPartenza;
        Button btnPartenza;
        Mazzetto mazzettoArrivo;
        Button btnArrivo;

        public PartitaM(string nome)
        {
            InitializeComponent();
            partitaManuelito = new PartitaManuelito(nome);
            modalitaSelezioneCarta = true;
            this.ResizeMode = ResizeMode.NoResize;
            Height = 760;
            Width = 380;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            img_animazione.Visibility = Visibility.Collapsed;
            bottoniAusiliari = new Button[4] { btn_ausiliare1, btn_ausiliare2, btn_ausiliare3, btn_ausiliare4 };
            bottoniFinali = new Button[4] { btn_finale1, btn_finale2, btn_finale3, btn_finale4 };
            AggiornaImmagini();
            BottoniInvisibili();
            mosse = 0;
            GestoreSalvataggi gs = new GestoreSalvataggi();
            record = gs.LeggiRecord();
            if (record != null) lbl_record.Content = "Record: " + record.ToString();
            else
            {
                lbl_record.Content = "Nessun record";
                lbl_record.FontSize -= 5;
            }
        }
        
        private void ClickCarta(object sender, RoutedEventArgs e)
        {
            try
            {
                if (modalitaSelezioneCarta)
                {
                    SelezionaMazzettoPartenza(sender);
                    btnPartenza = (Button)sender;
                    modalitaSelezioneCarta = false;
                    btnPartenza.Background = Brushes.Cyan;
                }
                else
                {
                    if ((Button)sender == btnPartenza)
                    {
                        modalitaSelezioneCarta = true;
                        btnPartenza.Background = Brushes.Transparent;
                    }
                    else
                    {
                        SelezionaMazzettoArrivo(sender);
                        btnArrivo = (Button)sender;
                        partitaManuelito.MuoviCarta(mazzettoPartenza.TipoPosizioni, mazzettoPartenza.Numero, mazzettoArrivo.TipoPosizioni, mazzettoArrivo.Numero);
                        AnimazioneEAggiornamentoImmagini();
                        modalitaSelezioneCarta = true;
                        btnPartenza.Background = Brushes.Transparent;
                        mosse++;
                        lbl_mosse.Content = "Mosse: " + mosse.ToString();
                    }
                }
                if (partitaManuelito.VerificaVittoria) Vittoria();
            }
            catch (Exception ex)
            {
                modalitaSelezioneCarta = true;
                if(btnPartenza!=null)btnPartenza.Background = Brushes.Transparent;
                MessageBox.Show(ex.Message);
            }        
        }
        private void Mazzo_Click(object sender, RoutedEventArgs e)
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
                modalitaSelezioneCarta = true;
                if(btnPartenza!=null)btnPartenza.Background = Brushes.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SelezionaMazzettoPartenza(object sender)
        {
            bool trovato = false;
            for (int i = 0; i < 4; i++)
            {
                //bottoni ausiliari
                if (bottoniAusiliari[i] == sender)
                {
                    if (partitaManuelito.GuardaCartaPosizione(Posizioni.Ausiliarie, i) == null) throw new Exception("Carta non presente");
                    cartaDaSpostare = partitaManuelito.GuardaCartaPosizione(Posizioni.Ausiliarie, i);
                    mazzettoPartenza = new Mazzetto(Posizioni.Ausiliarie, i);
                    trovato = true;
                    break;
                }
                //bottoni finali
                if (bottoniFinali[i] == sender)
                {
                    if (partitaManuelito.GuardaCartaPosizione(Posizioni.Finali, i) == null) throw new Exception("Carta non presente");
                    cartaDaSpostare = partitaManuelito.GuardaCartaPosizione(Posizioni.Finali, i);
                    mazzettoPartenza = new Mazzetto(Posizioni.Finali, i);
                    trovato = true;
                    break;
                }
            }
            if (!trovato)
            {
                if (partitaManuelito.GuardaCartaPosizione(Posizioni.Centrale, 0) == null) throw new Exception("Carta non presente");
                cartaDaSpostare = partitaManuelito.GuardaCartaPosizione(Posizioni.Centrale, 0);
                mazzettoPartenza = new Mazzetto(Posizioni.Centrale, 0);
            }

        }
        private void SelezionaMazzettoArrivo(object sender)
        {
            for (int i = 0; i < 4; i++)
            {
                //bottoni ausiliari
                if (bottoniAusiliari[i] == sender)
                {
                    mazzettoArrivo = new Mazzetto(Posizioni.Ausiliarie, i);
                    break;
                }
                //bottoni finali
                if (bottoniFinali[i] == sender)
                {
                    mazzettoArrivo = new Mazzetto(Posizioni.Finali, i);
                    break;
                }
            }
        }      
        private void Vittoria()
        {
            try
            {
                GestoreSalvataggi gs = new GestoreSalvataggi();
                gs.AggiornaLeaderboard(partitaManuelito.Nome, mosse);
                string testo = $"Complimenti!\nHai vinto in {mosse.ToString()} mosse!\nVuoi giocare ancora?";
                if (record == null || mosse < record)
                {
                    string nomeRecord = gs.LeggiNomeRecord();
                    if (record != null) testo = $"Complimenti!\nHai vinto in {mosse.ToString()} mosse, hai battuto il record di {record} mosse di {nomeRecord}!\nVuoi giocare ancora?";
                    else testo = $"Complimenti!\nHai vinto in {mosse.ToString()} mosse, hai fatto il primo record!\nVuoi giocare ancora?";
                }
                if (MessageBox.Show(testo,
                        "Hai vinto!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MenuM p = new MenuM(partitaManuelito.Nome);
                    p.Owner = this;
                    p.Show();
                    p.Owner = null;
                }
                this.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void btn_Resa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Vuoi arrenderti?",
                    "Sconfitta",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (MessageBox.Show("Vuoi Riprovare?",
                        "Sconfitta",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        MenuM p = new MenuM(partitaManuelito.Nome);
                        p.Owner = this;
                        p.Show();
                        p.Owner = null;
                    }
                    this.Close();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
        private void AnimazioneEAggiornamentoImmagini()
        {
            System.Windows.Controls.Image? im = new System.Windows.Controls.Image();
            NameScope.SetNameScope(this, new NameScope());
            img_animazione.Margin = btnPartenza.Margin;
            img_animazione.Source = new BitmapImage(new Uri(cartaDaSpostare.Percorso, UriKind.Relative));
            img_animazione.Visibility = Visibility.Visible;
            //creo matrixTrasform che farà muovere l'immagine e lo metto nell'immagine
            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            img_animazione.RenderTransform = buttonMatrixTransform;
            this.RegisterName("img_animazione", buttonMatrixTransform);
            double x = btnArrivo.Margin.Left - btnPartenza.Margin.Left;
            double y = btnArrivo.Margin.Top - btnPartenza.Margin.Top;
            // Creo il segmento della animazione
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new System.Windows.Point(0,0);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(pFigure.StartPoint);
            pBezierSegment.Points.Add(new System.Windows.Point(x,y));
            pBezierSegment.Points.Add(new System.Windows.Point(x, y));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);
            animationPath.Freeze();
            //lo metto nella animazione
            MatrixAnimationUsingPath matrixAnimation = new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            //calcolo il tempo in modo che la velocità sia sempre la stessa anche se cambia la distanza
            double velocita = 1500.0;
            double spazio = Math.Sqrt(Math.Abs(x*x) + Math.Abs(y*y));
            double tempo = spazio / velocita;
            matrixAnimation.Duration = TimeSpan.FromSeconds(tempo);
            //imposto l'animazione nella storyboard
            Storyboard.SetTargetName(matrixAnimation, "img_animazione");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);
            //mi salvo il percorso dell'immagine di arrivo e ce lo rimetto dopo aver aggiornato le immagini, per poi riaggiornarlo alla fine della animazione
            ImageSource percorsoImmagineArrivo = (btnArrivo.Content as System.Windows.Controls.Image).Source;
            Visibility visibilitaImmagineArrivo = (btnArrivo.Content as System.Windows.Controls.Image).Visibility;
            AggiornaImmagini();
            (btnArrivo.Content as System.Windows.Controls.Image).Source = percorsoImmagineArrivo;
            (btnArrivo.Content as System.Windows.Controls.Image).Visibility = visibilitaImmagineArrivo;
            DisattivaBottoni();
            pathAnimationStoryboard.Completed += (o, s) => {
                img_animazione.Visibility = Visibility.Collapsed;
                im.Visibility = Visibility.Collapsed;
                AggiornaImmagini();
                cartaDaSpostare = null;
                AttivaBottoni();
            };
            pathAnimationStoryboard.Begin(this);
        }
        private void AggiornaImmagini()
        {
            Carta? cartaInCima;
            System.Windows.Controls.Image Immagine=img_ausiliare1;
            for (int i = 0; i < 4; i++)
            {
                //btn ausiliare
                Immagine = ((System.Windows.Controls.Image)(bottoniAusiliari[i].Content));
                cartaInCima = partitaManuelito.GuardaCartaPosizione(Posizioni.Ausiliarie, i);
                if(cartaInCima == null)
                {
                    Immagine.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Immagine.Visibility = Visibility.Visible;
                    Immagine.Source = new BitmapImage(new Uri(cartaInCima.Percorso, UriKind.Relative));
                }
                //btn finale
                Immagine = ((System.Windows.Controls.Image)(bottoniFinali[i].Content));
                cartaInCima = partitaManuelito.GuardaCartaPosizione(Posizioni.Finali, i);
                if (cartaInCima == null)
                {
                    Immagine.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Immagine.Visibility = Visibility.Visible;
                    Immagine.Source = new BitmapImage(new Uri(cartaInCima.Percorso, UriKind.Relative));
                }
            }
            //mazzo
            if (partitaManuelito.Mazzo.Vuoto)
            {
                img_mazzo.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_mazzo.Visibility = Visibility.Visible;
                string nomeImg = "/images/Carte/RETRO.jpg";
                var uriSource = new Uri(nomeImg, UriKind.Relative);
                img_mazzo.Source = new BitmapImage(uriSource);
            }
            //centrali
            for(int i=0;i<3;i++)
            {
                cartaInCima = partitaManuelito.GuardaCartaPosizione(Posizioni.Centrale, i);
                if (i == 0) Immagine = img_cartaEstratta1;
                if (i == 1) Immagine = img_cartaEstratta2;
                if (i == 2) Immagine = img_cartaEstratta3;
                if (cartaInCima == null)
                {
                    Immagine.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Immagine.Visibility = Visibility.Visible;
                    Immagine.Source = new BitmapImage(new Uri(cartaInCima.Percorso, UriKind.Relative));
                }
            }
        }
        private void DisattivaBottoni()
        {
            btn_ausiliare1.IsHitTestVisible = false;
            btn_ausiliare2.IsHitTestVisible = false;
            btn_ausiliare3.IsHitTestVisible = false;
            btn_ausiliare4.IsHitTestVisible = false;
            btn_finale1.IsHitTestVisible = false;
            btn_finale2.IsHitTestVisible = false;
            btn_finale3.IsHitTestVisible = false;
            btn_finale4.IsHitTestVisible = false;
            btn_cartaestratta_1.IsHitTestVisible = false;
            btn_mazzo.IsHitTestVisible = false;
        }
        private void AttivaBottoni()
        {
            btn_ausiliare1.IsHitTestVisible = true;
            btn_ausiliare2.IsHitTestVisible = true;
            btn_ausiliare3.IsHitTestVisible = true;
            btn_ausiliare4.IsHitTestVisible = true;
            btn_finale1.IsHitTestVisible = true;
            btn_finale2.IsHitTestVisible = true;
            btn_finale3.IsHitTestVisible = true;
            btn_finale4.IsHitTestVisible = true;
            btn_cartaestratta_1.IsHitTestVisible = true;
            btn_mazzo.IsHitTestVisible = true;

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


    }

}
