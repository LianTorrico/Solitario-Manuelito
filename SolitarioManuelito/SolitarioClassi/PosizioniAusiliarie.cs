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
            //forse inizializzare list
            _pile = new List<Carta>[0];
            _pile[0].Add(carta1);
            _pile[1].Add(carta2);
            _pile[2].Add(carta3);
            _pile[3].Add(carta4);
        }
        /// <summary>
        /// Aggiunge la carta data in cima al mazzo scelto
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="mazzoScelto"></param>
        public void AggiungiCarta(Carta carta, int mazzoScelto)
        {

        }
        /// <summary>
        /// Rimuove l'ultima carta del mazzo scelto e la restituisce
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta RimuoviCarta(int mazzoScelto)
        {
            return new Carta(Valore.Asso, Semi.Spade);
        }
        /// <summary>
        /// Guarda la carta in cima al mazzo scelto 
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta GuardaCartaInCima(int mazzoScelto)
        {
            return new Carta(Valore.Asso, Semi.Spade);
        }
        
    }
}