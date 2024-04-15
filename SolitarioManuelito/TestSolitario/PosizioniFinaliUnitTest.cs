using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class PosizioniFinaliUnitTest
    {
        [TestMethod]
        public void AggiungiCarta_Asso()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Asso,Semi.Denara);
            posizioniFinaliTest.AggiungiCarta(carta, 1);
            Carta expected = carta;
            Carta actual = posizioniFinaliTest.GuardaCartaInCima(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabilePrimaCarta()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Due, Semi.Denara);
            Assert.ThrowsException<Exception>(() => posizioniFinaliTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileSemeDiverso()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Due, Semi.Bastoni);
            Carta primaCarta = new Carta(Valore.Asso, Semi.Denara);
            posizioniFinaliTest.AggiungiCarta(primaCarta,1);
            Assert.ThrowsException<Exception>(() => posizioniFinaliTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileValoreSbagliato()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Tre, Semi.Denara);
            Carta primaCarta = new Carta(Valore.Asso, Semi.Denara);
            posizioniFinaliTest.AggiungiCarta(primaCarta, 1);
            Assert.ThrowsException<Exception>(() => posizioniFinaliTest.AggiungiCarta(carta, 1));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileMazzo0()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Asso, Semi.Denara);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => posizioniFinaliTest.AggiungiCarta(carta, 0));
        }
        [TestMethod]
        public void AggiungiCarta_InaccettabileMazzo5()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Asso, Semi.Denara);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => posizioniFinaliTest.AggiungiCarta(carta, 5));
        }
        [TestMethod]
        public void RimuoviCarta_CartaRimossa()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Asso, Semi.Denara);
            posizioniFinaliTest.AggiungiCarta(carta, 1);
            Carta expected = carta;
            Carta actual = posizioniFinaliTest.RimuoviCarta(1);
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<Exception>(() => posizioniFinaliTest.GuardaCartaInCima(1));
        }
        [TestMethod]
        public void RimuoviCarta_CartaCorretta()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Carta carta = new Carta(Valore.Asso, Semi.Denara);
            posizioniFinaliTest.AggiungiCarta(carta, 1);
            Carta expected = carta;
            Carta actual = posizioniFinaliTest.GuardaCartaInCima(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RimuoviCarta_MazzoVuoto()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Assert.ThrowsException<Exception>(() => posizioniFinaliTest.RimuoviCarta(1));
        }
        [TestMethod]
        public void GuardaCartaInCima_MazzoVuoto()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            Assert.ThrowsException<Exception>(() => posizioniFinaliTest.GuardaCartaInCima(1));
        }
        [TestMethod]
        public void VerificaSePiene_NonPiene()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            bool expected = false;
            bool actual = posizioniFinaliTest.VerificaSePiene;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void VerificaSePiene_Piene()
        {
            PosizioniFinali posizioniFinaliTest = new PosizioniFinali();
            bool expected = true;
            for(int i=1;i<=10; i++)
            {
                for(int j = 1; j <= 4; j++)
                {
                    Carta carta = new Carta((Valore)i,(Semi)j);
                    posizioniFinaliTest.AggiungiCarta(carta, j);
                }
            }
            bool actual = posizioniFinaliTest.VerificaSePiene;
            Assert.AreEqual(expected, actual);
        }

    }
}