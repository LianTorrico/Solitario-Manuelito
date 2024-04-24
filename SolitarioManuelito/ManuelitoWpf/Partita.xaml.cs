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

namespace ManuelitoWpf
{
    /// <summary>
    /// Logica di interazione per Partita.xaml
    /// </summary>
    public partial class Partita : Page
    {
        PartitaManuelito partitaManuelito;
        bool modalitaSelezioneCarta;
        Carta cartaDaSpostare;
        Posizioni posizioneDaSpostare;
        int mazzoDaSpostare;
        Posizioni posizioneArrivo;
        int mazzoArrivo;

        public Partita()
        {
            InitializeComponent();
            partitaManuelito = new PartitaManuelito();
            modalitaSelezioneCarta = true;
        }
        private void SelezionaCartaDaBottone(object sender)
        {
            if (sender == btn_ausiliare1)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 1);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 1;
            }
            else if (sender == btn_ausiliare2)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 2);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 2;
            }
            else if (sender == btn_ausiliare3)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 3);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 3;
            }
            else if (sender == btn_ausiliare4)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Ausiliarie, 4);
                posizioneDaSpostare = Posizioni.Ausiliarie;
                mazzoDaSpostare = 4;
            }
            else if (sender == btn_finale1)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 1);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 1;
            }
            else if (sender == btn_finale2)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 2);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 2;
            }
            else if (sender == btn_finale3)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 3);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 3;
            }
            else if (sender == btn_finale4)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Finali, 4);
                posizioneDaSpostare = Posizioni.Finali;
                mazzoDaSpostare = 4;
            }
            else if (sender == btn_cartaestratta_1)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1);
                posizioneDaSpostare = Posizioni.Centrale;
                mazzoDaSpostare = 1;
            }
            else if (sender == btn_cartaestratta_2)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1);
                posizioneDaSpostare = Posizioni.Centrale;
                mazzoDaSpostare = 1;
            }
            else if (sender == btn_cartaestratta_3)
            {
                cartaDaSpostare = partitaManuelito.GuardaCartaInCimaAPosizioni(Posizioni.Centrale, 1);
                posizioneDaSpostare = Posizioni.Centrale;
                mazzoDaSpostare = 1;
            }
        }
        private void SelezionaPosizioniArrivo(object sender)
        {
            if(sender == btn_ausiliare1)
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
            else if (sender == btn_cartaestratta_2)
            {
                posizioneArrivo = Posizioni.Centrale;
                mazzoArrivo = 1;
            }
            else if (sender == btn_cartaestratta_3)
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
                    modalitaSelezioneCarta = false;
                }
                else
                {
                    SelezionaPosizioniArrivo(sender);
                    partitaManuelito.MuoviCarta(posizioneDaSpostare, mazzoDaSpostare, posizioneArrivo, mazzoArrivo);
                    modalitaSelezioneCarta = true;
                }
            } catch (Exception ex)
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        }

    }
}
