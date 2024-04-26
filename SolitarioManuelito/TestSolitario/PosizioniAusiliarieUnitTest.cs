using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class PosizioniAusiliarieUnitTest
    {
        [TestMethod]
        public void AggiungiCarta_Corretta()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta carta = new Carta(Valore.Tre, Semi.A);
            posizioniAusiliarieTest.AggiungiCarta(carta, 1);
            Carta expected = carta;
            Carta actual = posizioniAusiliarieTest.GuardaCartaInCima(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AggiungiCarta_InaccettabileSemeUguale()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta carta = new Carta(Valore.Tre, Semi.D);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileValoreSbagliato()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta carta = new Carta(Valore.Due, Semi.A);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileMazzo0()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta carta = new Carta(Valore.Tre, Semi.A);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 0));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileMazzo5()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta carta = new Carta(Valore.Tre, Semi.A);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => posizioniAusiliarieTest.AggiungiCarta(carta, 5));
        }
        [TestMethod]
        public void RimuoviCarta_CartaRimossa()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta expected = new Carta(Valore.Quattro,Semi.D);
            Carta actual = posizioniAusiliarieTest.RimuoviCarta(1);
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.GuardaCartaInCima(1));
        }
        [TestMethod]
        public void RimuoviCarta_CartaCorretta()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            Carta expected = new Carta(Valore.Quattro, Semi.D);
            Carta actual = posizioniAusiliarieTest.GuardaCartaInCima(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RimuoviCarta_MazzoVuoto()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            posizioniAusiliarieTest.RimuoviCarta(1);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.RimuoviCarta(1));
        }
        [TestMethod]
        public void GuardaCartaInCima_MazzoVuoto()
        {
            PosizioniAusiliarie posizioniAusiliarieTest = new PosizioniAusiliarie(new Carta(Valore.Quattro,Semi.D), new Carta(Valore.Sette, Semi.A),new Carta(Valore.Re, Semi.C), new Carta(Valore.Fante, Semi.B));
            posizioniAusiliarieTest.RimuoviCarta(1);
            Assert.ThrowsException<Exception>(() => posizioniAusiliarieTest.GuardaCartaInCima(1));
        }
    }
}