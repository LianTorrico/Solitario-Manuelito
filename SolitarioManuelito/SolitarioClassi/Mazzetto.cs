using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioClassi
{
    public class Mazzetto
    {
        private Posizioni _tipoPosizioni;
        private int _numero;
        private List<Carta> _carte;
        public Posizioni TipoPosizioni
        {
            get { return _tipoPosizioni;}
            private set
            {
                if ((int)value < 0 || (int)value > 2) throw new ArgumentException("Tipo posizione non valida");
                _tipoPosizioni = value;
            }
        }
        public int Numero
        { 
            get { return _numero; }
            private set
            {
                if(value<0 || value >= 4) throw new ArgumentException("Numero mazzetto non valido");
                _numero = value;
            }
        }
        public List<Carta> Carte
        {
            get { return _carte; }
            private set
            {
                if (value == null) throw new ArgumentException("carte null");
                _carte = value;
            }
        }
        public Mazzetto(Posizioni tipoPosizioni, int numero)
        {
            if (tipoPosizioni == Posizioni.Centrale && numero != 0) throw new ArgumentException("I mazzetti centrali possono avere solo numero 0");
            TipoPosizioni = tipoPosizioni;
            Numero = numero;
            _carte = new List<Carta>();
        }
        public Carta? RimuoviCarta()
        {
            Carta? cartaRimossa = Carte.LastOrDefault();
            if (Carte.Count != 0) _carte.Remove(cartaRimossa);
            return cartaRimossa;
        }
        public Carta? GuardaCarta()
        {
            Carta? cartaGuardata = Carte.LastOrDefault();
            return cartaGuardata;
        }
        public void AggiungiCarta(Carta carta)
        {
            if (carta == null) throw new ArgumentException("carta null");
            if (TipoPosizioni == Posizioni.Centrale) {
                Carte.Add(carta);
            }
            else if(TipoPosizioni == Posizioni.Ausiliarie)
            {
                if (Carte.Count == 0 || (Carte.Last().Seme != carta.Seme && (int)carta.Valore == (int)Carte.Last().Valore -1 ))
                {
                    Carte.Add(carta);
                }else
                {
                    throw new ArgumentException("Carta non aggiungibile");
                }
            }else
            {
                if ((Carte.Count == 0 && carta.Valore == Valore.Asso))
                {
                    Carte.Add(carta);
                }
                else if (Carte.Count != 0 && (Carte.Last().Seme == carta.Seme && (int)carta.Valore == (int)Carte.Last().Valore + 1))
                {
                    Carte.Add(carta);
                }
                else
                {
                    throw new ArgumentException("Carta non aggiungibile");
                }
            }
        }
        public void Svuota()
        {
            _carte.Clear();
        }
    }
}
