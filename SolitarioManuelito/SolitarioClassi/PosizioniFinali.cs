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
            //forse da dichiarare le liste dentro
        }
        /// <summary>
        /// Aggiunge la carta data in cima al mazzo scelto
        /// </summary>
        /// <param name="carta"></param>
        /// <param name="mazzoScelto"></param>
        public void AggiungiCarta(Carta carta,int mazzoScelto)
        {
            if(carta == null) throw new ArgumentNullException("Carta è null");
            if (mazzoScelto < 1 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            mazzoScelto--;
            _pile[mazzoScelto].Add(carta);

        }
        /// <summary>
        /// Rimuove la carta in cima al mazzo scelto e la restituisce
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta RimuoviCarta(int mazzoScelto)
        {
            if (mazzoScelto < 1 || mazzoScelto > 4) throw new ArgumentOutOfRangeException("mazzo scelto deve essere tra 1 e 4");
            mazzoScelto--;
            Carta ultimaCarta = _pile[mazzoScelto].Last();
            _pile[mazzoScelto].Remove(ultimaCarta);
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
        /// Guarda la carta in cima al mazzo scelto 
        /// </summary>
        /// <param name="mazzoScelto"></param>
        /// <returns>Carta rimossa</returns>
        public Carta GuardaCartaInCima(int mazzoScelto)
        {
            return _pile[mazzoScelto].Last();
        }

    }
}