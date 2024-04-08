using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioManuelito
{

    public class PosizioniAusiliarie
    {
        private List<Carta> _pila1;
        private List<Carta> _pila2;
        private List<Carta> _pila3;
        private List<Carta> _pila4;
        /// <summary>
        /// Crea le 4 posizioni ausiliarie con per ognuna solo la carta data
        /// </summary>
        /// <param name="carta1"></param>
        /// <param name="carta2"></param>
        /// <param name="carta3"></param>
        /// <param name="carta4"></param>
        public PosizioniAusiliarie(Carta carta1,Carta carta2, Carta carta3, Carta carta4)
        {
            
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
        /// <returns></returns>
        public Carta RimuoviCarta(int mazzoScelto)
        {
            return new Carta(Valore.Asso, Semi.Spade);
        }
        /// <summary>
        /// Guarda la carta in cima al mazzo scelto 
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns></returns>
        public Carta GuardaCartaInCima(int mazzoScelto)
        {
            return new Carta(Valore.Asso, Semi.Spade);
        }
        
    }
}