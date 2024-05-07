using System;
using System.Collections.Generic;
using System.Linq;
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

        Carta? cartaDaSpostare;
        Posizioni posizioneDaSpostare;
        int mazzoDaSpostare;
        Button btnCartaSelezionata;

        Posizioni posizioneArrivo;
        Button btnArrivo;
        System.Windows.Controls.Image? immagineArrivo;
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
            img_animazione.Visibility = Visibility.Collapsed;
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
        private void SelezionaPosizioniArrivo(object sender)
        {
            btnArrivo = (Button)sender;
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
                    SelezionaPosizioneBottone(sender);
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
                        immagineArrivo = (System.Windows.Controls.Image)btnArrivo.Content;
                        partitaManuelito.MuoviCarta(posizioneDaSpostare, mazzoDaSpostare, posizioneArrivo, mazzoArrivo);
                        Animazione();
                        modalitaSelezioneCarta = true;
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
                modalitaSelezioneCarta = true;
                if(btnCartaSelezionata!=null)btnCartaSelezionata.Background = Brushes.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void Animazione()
        {
            System.Windows.Controls.Image? im = new System.Windows.Controls.Image();
            NameScope.SetNameScope(this, new NameScope());
            img_animazione.Margin = btnCartaSelezionata.Margin;
            img_animazione.Source = new BitmapImage(new Uri(cartaDaSpostare.Percorso, UriKind.Relative));
            img_animazione.Visibility = Visibility.Visible;

            // Create a MatrixTransform. This transform
            // will be used to move the button.
            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            img_animazione.RenderTransform = buttonMatrixTransform;
            // Register the transform's name with the page
            // so that it can be targeted by a Storyboard.
            this.RegisterName("img_animazione", buttonMatrixTransform);

            double x = btnArrivo.Margin.Left - btnCartaSelezionata.Margin.Left;
            double y = btnArrivo.Margin.Top - btnCartaSelezionata.Margin.Top;
            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0,0);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(pFigure.StartPoint);
            pBezierSegment.Points.Add(new Point(x,y));
            pBezierSegment.Points.Add(new Point(x, y));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the
            // button along the path by animating
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation = new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            double velocita = 655.0;
            double spazio = Math.Sqrt(Math.Abs(x*x) + Math.Abs(y*y));
            double tempo = spazio / velocita;
            matrixAnimation.Duration = TimeSpan.FromSeconds(tempo);

            // Set the animation to target the Matrix property
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "img_animazione");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            
            ImageSource percorsoImmagineArrivo = (btnArrivo.Content as System.Windows.Controls.Image).Source;
            Visibility visibilitaImmagineArrivo = (btnArrivo.Content as System.Windows.Controls.Image).Visibility;
            AggiornaImmagini();
            (btnArrivo.Content as System.Windows.Controls.Image).Source = percorsoImmagineArrivo;
            (btnArrivo.Content as System.Windows.Controls.Image).Visibility = visibilitaImmagineArrivo;
            pathAnimationStoryboard.Completed += (o, s) => {
                img_animazione.Visibility = Visibility.Collapsed;
                im.Visibility = Visibility.Collapsed;
                AggiornaImmagini();
                cartaDaSpostare = null;
            };
            pathAnimationStoryboard.Begin(this);
           

        }
        private void SelezionaPosizioneBottone(object sender)
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
                img_ausiliare1.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //ausiliare 2
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 2);
            if (carta == null)
            {
                img_ausiliare2.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_ausiliare2.Visibility = Visibility.Visible;
                img_ausiliare2.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //ausiliare 3
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 3);
            if (carta == null)
            {
                img_ausiliare3.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_ausiliare3.Visibility = Visibility.Visible;
                img_ausiliare3.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //ausiliare 4
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 4);
            if (carta == null)
            {
                img_ausiliare4.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_ausiliare4.Visibility = Visibility.Visible;
                img_ausiliare4.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //finale 1
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 1);
            if (carta == null)
            {
                img_finale1.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_finale1.Visibility = Visibility.Visible;
                img_finale1.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //finale 2
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 2);
            if (carta == null)
            {
                img_finale2.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_finale2.Visibility = Visibility.Visible;
                img_finale2.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //finale 3
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 3);
            if (carta == null)
            {
                img_finale3.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_finale3.Visibility = Visibility.Visible;
                img_finale3.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //finale 4
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 4);
            if (carta == null)
            {
                img_finale4.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_finale4.Visibility = Visibility.Visible;
                img_finale4.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //centro 1
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1);
            if (carta == null)
            {
                img_cartaEstratta1.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_cartaEstratta1.Visibility = Visibility.Visible;
                img_cartaEstratta1.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //centro 2
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 2);
            if (carta == null)
            {
                img_cartaEstratta2.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_cartaEstratta2.Visibility = Visibility.Visible;
                img_cartaEstratta2.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
            }
            //centro 3
            carta = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 3);
            if (carta == null)
            {
                img_cartaEstratta3.Visibility = Visibility.Collapsed;
            }
            else
            {
                img_cartaEstratta3.Visibility = Visibility.Visible;
                img_cartaEstratta3.Source = new BitmapImage(new Uri(carta.Percorso, UriKind.Relative));
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
       // public void 

    }

}
