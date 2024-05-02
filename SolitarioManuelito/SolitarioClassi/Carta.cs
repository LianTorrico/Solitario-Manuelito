using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolitarioClassi
{
    public enum Semi
    {
        A=1,
        B,
        C,
        D
    }
    public enum Valore
    {
        Asso = 1,
        Due,
        Tre,
        Quattro,
        Cinque,
        Sei,
        Sette,
        Fante,
        Cavallo,
        Re
    }
    public class Carta
    {
        private Valore _valore;
        private Semi _seme;
        private string _percorso;

        public Carta(Valore valore, Semi seme)
        {
            Valore = valore;
            Seme = seme;
            InizializzaPercorso();
        }
        private void InizializzaPercorso()
        {
            _percorso = "images/carte/" + (int)Valore + Seme.ToString() + ".jpg";
        }
        public string Percorso
        {
            get { return _percorso; }
        }
        public Valore Valore
        {
            get { return _valore; }
            private set
            {
                if((int)value <=0 || (int)value>10)throw new ArgumentException("Valore della carta non valido");
                _valore = value;
            }
        }
        public Semi Seme
        {
            get { return _seme; }
            private set
            {
                if ((int)value <= 0 || (int)value > 4) throw new ArgumentException("Valore della carta non valido");
                _seme = value;
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(!(obj is Carta)) return false;
            Carta c = (Carta)obj;
            if (c.Seme == this.Seme && c.Valore == this.Valore) return true;
            return false;
        }


    }
}