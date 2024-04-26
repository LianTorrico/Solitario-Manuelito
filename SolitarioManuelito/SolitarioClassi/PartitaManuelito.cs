using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace SolitarioClassi
{
    public enum Posizioni
    {
        Centrale,
        Finali,
        Ausiliarie
    }
    public class PartitaManuelito
    {
        private Mazzo _mazzo;
        private PosizioniFinali _posizioniFinali;
        private PosizioniAusiliarie _posizioniAusiliarie;
        private List<Carta> _carteUscite;
        /// <summary>
        /// Crea la partita con mazzo mescolato e le prime 4 carte estratte dal mazzo nelle posizioni ausiliarie
        /// </summary>
        public PartitaManuelito()
        {
            _mazzo = new Mazzo();
            _mazzo.Mescola();
            _posizioniFinali = new PosizioniFinali();
            _posizioniAusiliarie = new PosizioniAusiliarie(_mazzo.PescaCarta(), _mazzo.PescaCarta(), _mazzo.PescaCarta(), _mazzo.PescaCarta());
            _carteUscite = new List<Carta>();
        }
        /// <summary>
        /// Proprietà di get del mazzo
        /// </summary>
        public Mazzo Mazzo
        {
            get { return _mazzo; } 
        }
        /// <summary>
        /// Proprietà con solo get delle carte uscite
        /// </summary>
        public List<Carta> CarteUscite
        {
            get { return _carteUscite; }
        }
        /// <summary>
        /// Pesca 3 carte dal mazzo se possibile, sennò quelle rimanenti
        /// </summary>
        public void PescaMano()
        {
            if (_mazzo.Vuoto) throw new Exception("il mazzo è vuoto");
            _carteUscite.Add(_mazzo.PescaCarta());
            if(!_mazzo.Vuoto)_carteUscite.Add(_mazzo.PescaCarta());
            if(!_mazzo.Vuoto) _carteUscite.Add(_mazzo.PescaCarta());
        }
        /// <summary>
        /// Muovi carta da posizioni ausiliarie o finali o centrali a posizioni ausiliarie o finali 
        /// </summary>
        /// <param name="posizionePartenza"></param>
        /// <param name="mazzoPartenza"></param>
        /// <param name="posizioneArrivo"></param>
        /// <param name="mazzoArrivo"></param>
        public void MuoviCarta(Posizioni posizionePartenza, int mazzoPartenza, Posizioni posizioneArrivo, int mazzoArrivo)
        {
            if (mazzoPartenza < 0 || mazzoPartenza > 4) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 1 e 4");
            if (mazzoArrivo < 0 || mazzoArrivo > 4) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 1 e 4");
            if ((int)posizioneArrivo < 1 || (int)posizioneArrivo > 2) throw new ArgumentException("posizione di arrivo non valida");
            if ((int)posizionePartenza < 0 || (int)posizionePartenza > 2) throw new ArgumentException("posizione di partenza non valida");
            Carta? cartaDaSpostare;
            cartaDaSpostare = GuardaCartaInCimaAPosizioni(posizionePartenza, mazzoPartenza);
            if (cartaDaSpostare == null) throw new Exception("carta inesistente");
            if (posizioneArrivo == Posizioni.Ausiliarie) _posizioniAusiliarie.AggiungiCarta(cartaDaSpostare, mazzoArrivo);
            else if(posizioneArrivo== Posizioni.Finali) _posizioniFinali.AggiungiCarta(cartaDaSpostare, mazzoArrivo);
            RimuoviCartaInCimaAPoisizioni(posizionePartenza, mazzoPartenza);
            
        }
        /// <summary>
        /// Ricostruisce il mazzo con le carte estratte che vengono svuotate
        /// </summary>
        public void RicostruisciMazzo()
        {
            List<Carta> cartaSpostare = new List<Carta> ();
            foreach(Carta carta in _carteUscite)cartaSpostare.Add(carta);
            _mazzo.Ricostruisci(cartaSpostare);
            _carteUscite.Clear();
        }
        /// <summary>
        /// Verifica se la partita è stata vinta
        /// </summary>
        public bool VerificaVittoria
        {
            get
            {
                return _posizioniFinali.VerificaSePiene;
            }
        }
        /// <summary>
        /// Ti arrendi e perdi la partita
        /// </summary>
        public void Arrenditi()
        {
            //skill issue
        }
        /// <summary>
        /// Restituice la carta in cima al mazzo scelto (da 1 a 4) delle posizioni scelte (o finali o ausiliarie o centrali), null se carta non presente
        /// </summary>
        /// <param name="posizione"></param>
        /// <param name="mazzo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Carta? GuardaCartaInCimaAPosizioni(Posizioni posizione, int mazzo)
        {
            if (mazzo < 0 || mazzo > 4) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 1 e 4");
            if ((int)posizione < 0 || (int)posizione > 2) throw new ArgumentException("posizione non valida");
            Carta? cartaGuardata;
            if (posizione == Posizioni.Finali) cartaGuardata = _posizioniFinali.GuardaCartaInCima(mazzo);
            else if (posizione == Posizioni.Ausiliarie) cartaGuardata = _posizioniAusiliarie.GuardaCartaInCima(mazzo);
            else
            {
                if (_carteUscite.Count() - mazzo < 0) cartaGuardata = null;
                else cartaGuardata = _carteUscite[_carteUscite.Count() - mazzo];
            }
            return cartaGuardata;
        }
        public Carta? RimuoviCartaInCimaAPoisizioni(Posizioni posizione, int mazzo)
        {
            if (mazzo < 0 || mazzo > 4) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 1 e 4");
            if ((int)posizione < 0 || (int)posizione > 2) throw new ArgumentException("posizione non valida");
            Carta? cartaTolta;
            if (posizione == Posizioni.Finali) cartaTolta = _posizioniFinali.RimuoviCarta(mazzo);
            else if (posizione == Posizioni.Ausiliarie) cartaTolta = _posizioniAusiliarie.RimuoviCarta(mazzo);
            else
            {
                if (_carteUscite.Count() - mazzo < 0) cartaTolta = null;
                else
                {
                    cartaTolta = _carteUscite[_carteUscite.Count() - mazzo];
                    _carteUscite.Remove(cartaTolta);
                }
                
            }
            return cartaTolta;
        }


    }
}