using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioClassi
{
    public class PosizioniFinali
    {
        private List<Carta>[] _pile;

        /// <summary>
        /// Crea le 4 posizioni finali vuote
        /// </summary>
        public PosizioniFinali()
        {
            _pile = new List<Carta>[4];
            for(int i=0; i < 4; i++) _pile[i] = new List<Carta>();
        }
        /// <summary>
        /// Aggiunge la carta data in cima al mazzo scelto (da 1 a 4)
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="mazzoScelto"></param>
        public void AggiungiCarta(Carta carta,int mazzoScelto)
        {
            if (carta == null) throw new ArgumentNullException("Carta è null");
            if (mazzoScelto <= 0 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            Carta? cartaInCima = _pile[mazzoScelto - 1].LastOrDefault();
            if ((cartaInCima == null && carta.Valore == Valore.Asso) || (cartaInCima!=null && cartaInCima.Seme == carta.Seme && (int)cartaInCima.Valore == (int)carta.Valore -1))
            {
                _pile[mazzoScelto - 1].Add(carta);
            }
            else throw new Exception("carta non aggiungibile");
        }
        /// <summary>
        /// Rimuove la carta in cima al mazzo scelto (da 1 a 4) e la restituisce
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta RimuoviCarta(int mazzoScelto)
        {
            if (mazzoScelto <= 0 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            if (_pile[mazzoScelto - 1].Count() == 0) throw new Exception("mazzo scelto non contiene carte");
            Carta ultimaCarta = _pile[mazzoScelto-1].Last();
            _pile[mazzoScelto-1].Remove(ultimaCarta);
            return ultimaCarta;
        }
        /// <summary>
        /// Restituisce true se le 4 posizioni hanno tutte le carte (partita vinta)
        /// </summary>
        public bool VerificaSePiene
        {
            get
            {
                foreach(List<Carta> list in _pile)
                {
                    if(list.Count < 10) return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Guarda la carta in cima al mazzo scelto, return null se non presente
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta? GuardaCartaInCima(int mazzoScelto)
        {
            if (mazzoScelto <= 0 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            return _pile[mazzoScelto-1].LastOrDefault();
        }

    }
}