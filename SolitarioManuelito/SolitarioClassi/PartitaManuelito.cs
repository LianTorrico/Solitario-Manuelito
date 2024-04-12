using System;
using System.Collections.Generic;
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
        /// Muovi carta da posizioni ausiliarie o finali a posizioni ausiliarie o finali 
        /// </summary>
        /// <param name="posizionePartenza"></param>
        /// <param name="mazzoPartenza"></param>
        /// <param name="posizioneArrivo"></param>
        /// <param name="mazzoArrivo"></param>
        public void MuoviCarta(Posizioni posizionePartenza, int mazzoPartenza, Posizioni posizioneArrivo, int mazzoArrivo)
        {
            //gestione accettabilità spostamento

        }
        /// <summary>
        /// Muovi carta da mazzo centrale a posizioni finali o ausiliarie, per muovere carte che si trovano in altri mazzi usare l'overload
        /// </summary>
        /// <param name="posizioneArrivo"></param>
        /// <param name="mazzoArrivo"></param>
        public void MuoviCarta(Posizioni posizioneArrivo, int mazzoArrivo)
        {
            //gestione accettabilità spostamento

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