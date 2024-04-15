using System;
using System.Collections.Generic;
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
        /// Muovi carta da posizioni ausiliarie o finali a posizioni ausiliarie o finali 
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
            if (posizionePartenza == Posizioni.Ausiliarie) cartaDaSpostare = _posizioniAusiliarie.RimuoviCarta(mazzoPartenza);
            else if (posizionePartenza == Posizioni.Finali) cartaDaSpostare = _posizioniFinali.RimuoviCarta(mazzoPartenza);
            else cartaDaSpostare = _carteUscite.LastOrDefault();
            if (cartaDaSpostare == null) throw new Exception("carta inesistente");
            if (posizioneArrivo == Posizioni.Ausiliarie) _posizioniAusiliarie.AggiungiCarta(cartaDaSpostare, mazzoArrivo);
            else if(posizioneArrivo== Posizioni.Finali) _posizioniFinali.AggiungiCarta(cartaDaSpostare, mazzoArrivo);
        }
        /// <summary>
        /// Muovi carta da mazzo centrale a posizioni finali o ausiliarie, per muovere carte che si trovano in altri mazzi usare l'overload
        /// </summary>
        /// <param name="posizioneArrivo"></param>
        /// <param name="mazzoArrivo"></param>
        public void MuoviCarta(Posizioni posizioneArrivo, int mazzoArrivo)
        {
            if ((int)posizioneArrivo < 1 || (int)posizioneArrivo > 2) throw new ArgumentException("posizione di arrivo non valida");
            if (mazzoArrivo < 0 || mazzoArrivo > 4) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 1 e 4");
            Carta? cartaDaSpostare = _carteUscite.LastOrDefault();
            if (cartaDaSpostare == null) throw new Exception("carta inesistente");
            if (posizioneArrivo == Posizioni.Ausiliarie) _posizioniAusiliarie.AggiungiCarta(cartaDaSpostare, mazzoArrivo);
            else if (posizioneArrivo == Posizioni.Finali) _posizioniFinali.AggiungiCarta(cartaDaSpostare, mazzoArrivo);
        }
        /// <summary>
        /// Ricostruisce il mazzo con le carte estratte che vengono svuotate
        /// </summary>
        public void RicostruisciMazzo()
        {
            _mazzo.Ricostruisci(_carteUscite);
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


    }
}