using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioManuelito
{
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

        }
        /// <summary>
        /// Pesca 3 carte dal mazzo se possibile, sennò quelle rimanenti
        /// </summary>
        public void PescaMano()
        {
            
        }
        /// <summary>
        /// Muovi la carta in cima a quelle estratte nel mazzo scelto di quelli finali
        /// </summary>
        /// <param name="mazzoScelto"></param>
        public void MuoviInPosizioniFinali(int mazzoScelto)
        {

        }
        /// <summary>
        /// Muovi la carta in cima a quelle estratte nel mazzo scelto di quelli ausiliari
        /// </summary>
        /// <param name="mazzoScelto"></param>
        public void MuoviInPosizioniAusiliarie(int mazzoScelto)
        {

        }
        /// <summary>
        /// Ricostruisce il mazzo con le carte estratte che vengono svuotate
        /// </summary>
        public void RicostruisciMazzo()
        {

        }
        /// <summary>
        /// Verifica se la partita è stata vinta
        /// </summary>
        public bool VerificaVittoria
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Ti arrendi e perdi la partita
        /// </summary>
        public void Arrenditi()
        {

        }


    }
}