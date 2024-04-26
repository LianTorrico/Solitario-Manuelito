using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioClassi
{

    public class PosizioniAusiliarie
    {
        private List<Carta>[] _pile;
        /// <summary>
        /// Crea le 4 posizioni ausiliarie con per ognuna solo la carta data
        /// </summary>
        /// <param name="carta1"></param>
        /// <param name="carta2"></param>
        /// <param name="carta3"></param>
        /// <param name="carta4"></param>
        public PosizioniAusiliarie(Carta carta1,Carta carta2, Carta carta3, Carta carta4)
        {
            if (carta1 == null || carta2 == null || carta3 == null || carta4 == null) throw new ArgumentNullException("Le carte non possono essere null");
            _pile = new List<Carta>[4];
            for (int i = 0; i < 4; i++) _pile[i] = new List<Carta>();
            _pile[0].Add(carta1);
            _pile[1].Add(carta2);
            _pile[2].Add(carta3);
            _pile[3].Add(carta4);
        }
        /// <summary>
        /// Aggiunge la carta data in cima al mazzo scelto (da 1 a 4)
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="mazzoScelto"></param>
        public void AggiungiCarta(Carta carta, int mazzoScelto)
        {
            if (carta == null) throw new ArgumentNullException("Carta è null");
            if (mazzoScelto <= 0 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            Carta? cartaInCima = _pile[mazzoScelto - 1].LastOrDefault();
            if (cartaInCima == null || (cartaInCima.Seme != carta.Seme && (int)cartaInCima.Valore == (int)carta.Valore + 1))
            {
                _pile[mazzoScelto - 1].Add(carta);
            }
            else throw new Exception("carta non aggiungibile");   
        }
        /// <summary>
        /// Rimuove l'ultima carta del mazzo scelto (da 1 a 4) e la restituisce
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta RimuoviCarta(int mazzoScelto)
        {
            if (mazzoScelto <= 0 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            if (_pile[mazzoScelto - 1].Count() == 0) throw new Exception("mazzo scelto non contiene carte");
            Carta cartaPresa = _pile[mazzoScelto-1].Last();
            _pile[mazzoScelto-1].Remove(cartaPresa);
            return cartaPresa;
        }
        /// <summary>
        /// Guarda la carta in cima al mazzo scelto (da 1 a 4), return null se non presente
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta? GuardaCartaInCima(int mazzoScelto)
        {
            if (mazzoScelto <= 0 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            return _pile[mazzoScelto - 1].LastOrDefault();
        }
        
    }
}