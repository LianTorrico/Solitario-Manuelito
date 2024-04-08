using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioManuelito
{
    public class PosizioniFinali
    {
        private List<Carta> _pila1;
        private List<Carta> _pila2;
        private List<Carta> _pila3;
        private List<Carta> _pila4;
        /// <summary>
        /// Crea le 4 posizioni finali vuote
        /// </summary>
        public PosizioniFinali()
        {
            _pila1 = new List<Carta>();
            _pila2 = new List<Carta>();
            _pila3 = new List<Carta>();
            _pila4 = new List<Carta>();
        }
        /// <summary>
        /// Aggiunge la carta data in cima al mazzo scelto
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="mazzoScelto"></param>
        public void AggiungiCarta(Carta carta,int mazzoScelto)
        {

        }
        /// <summary>
        /// Rimuove la carta in cima al mazzo scelto e la restituisce
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns></returns>
        public Carta RimuoviCarta(int mazzoScelto)
        {
            return new Carta(Valore.Asso, Semi.Spade);
        }
        /// <summary>
        /// Restituisce true se le 4 posizioni hanno tutte le carte (partita vinta)
        /// </summary>
        public bool VerificaSePiene
        {
            get
            {
                return true;
            }
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