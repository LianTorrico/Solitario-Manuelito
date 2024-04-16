using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class PosizioniAusiliarieUnitTest
    {
        [TestMethod]
        public void AggiungiCarta_Corretta()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta carta = new Carta(Valore.Tre, Semi.Spade);
            posizioniAusiliarieTest.AggiungiCarta(carta, 1);
            Carta expected = carta;
            Carta actual = posizioniAusiliarieTest.GuardaCartaInCima(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AggiungiCarta_InaccettabileSemeUguale()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta carta = new Carta(Valore.Tre, Semi.Denara);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileValoreSbagliato()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta carta = new Carta(Valore.Due, Semi.Spade);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileMazzo0()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta carta = new Carta(Valore.Tre, Semi.Spade);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 0));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileMazzo5()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta carta = new Carta(Valore.Tre, Semi.Spade);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 5));
        }
        [TestMethod]
        public void RimuoviCarta_CartaRimossa()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta expected = new Carta(Valore.Quattro,Semi.Denara);
            Carta actual = posizioniAusiliarieTest.RimuoviCarta(1);
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.GuardaCartaInCima(1));
        }
        [TestMethod]
        public void RimuoviCarta_CartaCorretta()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            Carta expected = new Carta(Valore.Quattro, Semi.Denara);
            Carta actual = posizioniAusiliarieTest.GuardaCartaInCima(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RimuoviCarta_MazzoVuoto()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            posizioniAusiliarieTest.RimuoviCarta(1);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.RimuoviCarta(1));
        }
        [TestMethod]
        public void GuardaCartaInCima_MazzoVuoto()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.Denara), new Carta(Valore.Sette, Semi.Spade),new Carta(Valore.Re, Semi.Bastoni), new Carta(Valore.Fante, Semi.Coppe));
            posizioniAusiliarieTest.RimuoviCarta(1);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.GuardaCartaInCima(1));
        }
    }
}