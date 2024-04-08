using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioManuelito
{
    public class Mazzo
    {
        private Carta[] _carte;
        /// <summary>
        /// Crea il mazzo non mescolato
        /// </summary>
        public Mazzo() 
        {
            InizializzaMazzo();
        }
        /// <summary>
        /// Crea il mazzo ordinato
        /// </summary>
        private void InizializzaMazzo()
        {

        }
        /// <summary>
        /// Mescola il mazzo
        /// </summary>
        private void MescolaMazzo()
        {

        }
        /// <summary>
        /// Pesca carta da in cima al mazzo
        /// </summary>
        /// <returns></returns>
        private Carta PescaCarta()
        {
            return new Carta(Valore.Asso,Semi.Denara);
        }
        /// <summary>
        /// Ricostruisci mazzo con Lista di carte date
        /// </summary>
        /// <param name="carte"></param>
        private void Ricostruisci(List<Carta> carte)
        {

        }



    }
}