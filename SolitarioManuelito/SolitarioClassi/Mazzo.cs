using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioManuelito
{
    public class Mazzo
    {
        private List<Carta> _carte;
        /// <summary>
        /// Crea il mazzo non mescolato
        /// </summary>
        public Mazzo() 
        {
            _carte = new List<Carta>();
            InizializzaMazzo();
        }
        /// <summary>
        /// Crea il mazzo ordinato
        /// </summary>
        private void InizializzaMazzo()
        {
            for(int valore = 1; valore <= 10; valore++)
            {
                for(int seme = 1; seme <= 4; seme++)
                {
                    Carta cartaDaAggiungere = new Carta((Valore)valore, (Semi)seme);
                    _carte.Add(cartaDaAggiungere);
                }
            }
        }
        /// <summary>
        /// Mescola il mazzo
        /// </summary>
        private void Mescola()
        {
            if (Vuoto) throw new Exception("Carte finite");
            Random random = new Random();
            for(int i=0;i<_carte.Count();i++)
            {
                int nuovaPos = random.Next(0, _carte.Count());
                Carta cartaScambio = _carte[i];
                _carte[i] = _carte[nuovaPos];
                _carte[nuovaPos] = cartaScambio;        
            }
        }
        /// <summary>
        /// Pesca carta da in cima al mazzo
        /// </summary>
        /// <returns>Carta pescata</returns>
        public Carta PescaCarta()
        {
            if (Vuoto) throw new Exception("Carte finite");
            Carta cartaPescata = _carte.Last();
            _carte.Remove(cartaPescata);
            return cartaPescata;
        }
        /// <summary>
        /// Ricostruisci mazzo (se è vuoto) con Lista di carte date invertita
        /// </summary>
        /// <param name="carte"></param>
        public void Ricostruisci(List<Carta> carte)
        {
            carte.Reverse();
            _carte = carte; 
        }
        /// <summary>
        /// Restituisce se il mazzo è vuoto o no
        /// </summary>
        public bool Vuoto
        {
            get
            {
                return _carte.Count == 0;
            }
        }



    }
}