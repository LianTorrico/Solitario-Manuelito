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
        private Mazzetto[] _posizioniFinali;
        private Mazzetto[] _posizioniAusiliarie;
        private Mazzetto _carteUscite;
        private string _nome;
        /// <summary>
        /// Crea la partita con mazzo mescolato e le prime 4 carte estratte dal mazzo nelle posizioni ausiliarie
        /// </summary>
        public PartitaManuelito(string nome)
        {
            Nome = nome;
            _mazzo = new Mazzo();
            _mazzo.Mescola();
            _posizioniFinali = new Mazzetto[4];
            for (int i = 0; i < 4; i++)
            {
                _posizioniFinali[i] = new Mazzetto(Posizioni.Finali, i);
            }
            _posizioniAusiliarie = new Mazzetto[4];
            for (int i = 0; i < 4; i++)
            {
                _posizioniAusiliarie[i] = new Mazzetto(Posizioni.Ausiliarie, i);
                _posizioniAusiliarie[i].AggiungiCarta(_mazzo.PescaCarta());
            }
            _carteUscite = new Mazzetto(Posizioni.Centrale, 0);
            _nome = nome;
        }
        public string Nome
        {
            get { return _nome; }
            private set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentException("Il nome è obbligatorio");
                if (value.Length > 12) throw new ArgumentException("nome lungo massimo 12 caratteri");
                _nome = value;
            }
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
        public Mazzetto CarteUscite
        {
            get { return _carteUscite; }
        }
        /// <summary>
        /// Pesca 3 carte dal mazzo se possibile, sennò quelle rimanenti
        /// </summary>
        public void PescaMano()
        {
            if (_mazzo.Vuoto) throw new Exception("il mazzo è vuoto");
            _carteUscite.AggiungiCarta(_mazzo.PescaCarta());
            if(!_mazzo.Vuoto)_carteUscite.AggiungiCarta(_mazzo.PescaCarta());
            if(!_mazzo.Vuoto) _carteUscite.AggiungiCarta(_mazzo.PescaCarta());
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
            if (mazzoPartenza < 0 || mazzoPartenza > 3) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 0 e 3");
            if (mazzoArrivo < 0 || mazzoArrivo > 3) throw new ArgumentOutOfRangeException("mazzo di partenza scelto deve essere tra 0 e 3");
            if ((int)posizioneArrivo < 1 || (int)posizioneArrivo > 2) throw new ArgumentException("posizione di arrivo non valida");
            if ((int)posizionePartenza < 0 || (int)posizionePartenza > 2) throw new ArgumentException("posizione di partenza non valida");
            Carta? cartaDaSpostare;
            cartaDaSpostare = GuardaCartaPosizione(posizionePartenza, mazzoPartenza);
            if (cartaDaSpostare == null) throw new Exception("carta inesistente");
            AggiungiCartaPosizione(posizioneArrivo, mazzoArrivo, cartaDaSpostare);
            RimuoviCartaPosizione(posizionePartenza, mazzoPartenza);
        }
        public Carta? GuardaCartaPosizione(Posizioni posizione, int mazzo)
        {
            if ((int)posizione < 0 || (int)posizione > 2) throw new ArgumentException("posizione non valida");
            if (mazzo < 0 || mazzo > 3) throw new ArgumentException("mazzo deve essere tra 0 e 3");
            Carta? cartaGuardata;
            if (posizione == Posizioni.Ausiliarie)
            {
                cartaGuardata = _posizioniAusiliarie[mazzo].GuardaCarta();
            }
            else if (posizione == Posizioni.Finali)
            {
                cartaGuardata = _posizioniFinali[mazzo].GuardaCarta();
            }
            else
            {
                if (_carteUscite.Carte.Count -1- mazzo >= 0) cartaGuardata = _carteUscite.Carte[_carteUscite.Carte.Count -1 - mazzo];
                else cartaGuardata = null;
            }
            return cartaGuardata;
        }
        private Carta? RimuoviCartaPosizione(Posizioni posizione, int mazzo)
        {
            if ((int)posizione < 0 || (int)posizione > 2) throw new ArgumentException("posizione non valida");
            if (mazzo < 0 || mazzo > 3) throw new ArgumentException("mazzo deve essere tra 0 e 3");
            Carta? cartaRimossa;
            if (posizione == Posizioni.Ausiliarie)
            {
                cartaRimossa = _posizioniAusiliarie[mazzo].RimuoviCarta();
            }
            else if (posizione == Posizioni.Finali)
            {
                cartaRimossa = _posizioniFinali[mazzo].RimuoviCarta();
            }
            else 
            {
                cartaRimossa = _carteUscite.RimuoviCarta();
            }
            return cartaRimossa;
        }
        private void AggiungiCartaPosizione(Posizioni posizione, int mazzo, Carta carta)
        {
            if ((int)posizione < 0 || (int)posizione > 2) throw new ArgumentException("posizione non valida");
            if (mazzo < 0 || mazzo > 3) throw new ArgumentException("mazzo deve essere tra 0 e 3");
            if (carta == null) throw new ArgumentException("carta null");
            if (posizione == Posizioni.Ausiliarie)
            {
                _posizioniAusiliarie[mazzo].AggiungiCarta(carta);
            }
            else if (posizione == Posizioni.Finali)
            {
                _posizioniFinali[mazzo].AggiungiCarta(carta);
            }
            else throw new Exception("posizione non valida");
        }
        /// <summary>
        /// Ricostruisce il mazzo con le carte estratte che vengono svuotate
        /// </summary>
        public void RicostruisciMazzo()
        {
            List<Carta> cartaSpostare = new List<Carta> ();
            foreach(Carta carta in _carteUscite.Carte)cartaSpostare.Add(carta);
            _mazzo.Ricostruisci(cartaSpostare);
            _carteUscite.Svuota();
        }
        /// <summary>
        /// Verifica se la partita è stata vinta
        /// </summary>
        public bool VerificaVittoria
        {
            get
            {                
                bool vittoria = true;
                foreach(Mazzetto m in _posizioniFinali)
                {
                    if(m.Carte.Count != 10)
                    {
                        vittoria = false;
                        break;
                    }
                }
                return vittoria;
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