using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class MazzettoUnitTests
    {
        //TEST GENERICI
        [TestMethod]
        public void Mazzetto_NumeroNeg_Errore()
        {
            Assert.ThrowsException<ArgumentException>(() => new Mazzetto(Posizioni.Finali, -1));
        }
        [TestMethod]
        public void Mazzetto_Numero4_Errore()
        {
            Assert.ThrowsException<ArgumentException>(() => new Mazzetto(Posizioni.Finali, 4));
        }
        [TestMethod]
        public void Mazzetto_PosizioneNeg_Errore()
        {
            Assert.ThrowsException<ArgumentException>(() => new Mazzetto((Posizioni)(-1), 1));
        }
        [TestMethod]
        public void Mazzetto_Posizione3_Errore()
        {
            Assert.ThrowsException<ArgumentException>(() => new Mazzetto((Posizioni)3, 1));
        }
        [TestMethod]
        public void RimuoviCarta_CartaCorretta()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta asso = new Carta(Valore.Asso, Semi.D);
            mazzettoTest.AggiungiCarta(asso);
            Carta actual = mazzettoTest.RimuoviCarta();
            Carta expected = asso;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GuardaCarta_CartaCorretta()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta asso = new Carta(Valore.Asso, Semi.D);
            mazzettoTest.AggiungiCarta(asso);
            Carta actual = mazzettoTest.GuardaCarta();
            Carta expected = asso;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AggiungiCarta_Null_Errore()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Assert.ThrowsException<ArgumentException>(() => mazzettoTest.AggiungiCarta(null));
        }





        //TEST MAZZETTI FINALI
        [TestMethod]
        public void AggiungiCarta_MazzettoFinalePrimoNonAsso_Errore()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta carta = new Carta(Valore.Due, Semi.D);
            Assert.ThrowsException<ArgumentException>(() => mazzettoTest.AggiungiCarta(carta));
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoFinaleNonSuccessiva_Errore()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta asso = new Carta(Valore.Asso, Semi.D);
            Carta carta = new Carta(Valore.Tre, Semi.D);
            mazzettoTest.AggiungiCarta(asso);
            Assert.ThrowsException<ArgumentException>(() => mazzettoTest.AggiungiCarta(carta));
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoFinaleSemeDiverso_Errore()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta asso = new Carta(Valore.Asso, Semi.D);
            Carta carta = new Carta(Valore.Due, Semi.A);
            mazzettoTest.AggiungiCarta(asso);
            Assert.ThrowsException<ArgumentException>(() => mazzettoTest.AggiungiCarta(carta));
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoFinalePrimoAsso()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta carta = new Carta(Valore.Asso, Semi.D);
            mazzettoTest.AggiungiCarta(carta);
            Carta expected = carta;
            Carta actual = mazzettoTest.GuardaCarta();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoFinaleSecondoDue()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Finali, 1);
            Carta Asso = new Carta(Valore.Asso, Semi.D);
            Carta due = new Carta(Valore.Due, Semi.D);
            mazzettoTest.AggiungiCarta(Asso);
            mazzettoTest.AggiungiCarta(due);
            Carta expected = due;
            Carta actual = mazzettoTest.GuardaCarta();
            Assert.AreEqual(expected, actual);
        }

        //TEST POSIZIONI AUSILIARIE

        [TestMethod]
        public void AggiungiCarta_MazzettoAusiliarioNonDecrescente_Errore()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Ausiliarie, 1);
            Carta tre = new Carta(Valore.Tre, Semi.D);
            Carta carta = new Carta(Valore.Quattro, Semi.A);
            mazzettoTest.AggiungiCarta(tre);
            Assert.ThrowsException<ArgumentException>(() => mazzettoTest.AggiungiCarta(carta));
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoAusiliarioSemeUguale_Errore()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Ausiliarie, 1);
            Carta due = new Carta(Valore.Due, Semi.D);
            Carta carta = new Carta(Valore.Asso, Semi.D);
            mazzettoTest.AggiungiCarta(due);
            Assert.ThrowsException<ArgumentException>(() => mazzettoTest.AggiungiCarta(carta));
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoAusiliarePrimaCarta()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Ausiliarie, 1);
            Carta carta = new Carta(Valore.Asso, Semi.D);
            mazzettoTest.AggiungiCarta(carta);
            Carta expected = carta;
            Carta actual = mazzettoTest.GuardaCarta();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AggiungiCarta_MazzettoFinaleCartaDecrescente()
        {
            Mazzetto mazzettoTest = new Mazzetto(Posizioni.Ausiliarie, 1);
            Carta due = new Carta(Valore.Due, Semi.D);
            Carta asso = new Carta(Valore.Asso, Semi.A);
            mazzettoTest.AggiungiCarta(due);
            mazzettoTest.AggiungiCarta(asso);
            Carta expected = asso;
            Carta actual = mazzettoTest.GuardaCarta();
            Assert.AreEqual(expected, actual);
        }
        //TEST MAZZETTO CENTRALE
        [TestMethod]
        public void Mazzetto_MazzettoCentraleNonNumero1_Errore()
        {
            Assert.ThrowsException<ArgumentException>(() => new Mazzetto(Posizioni.Centrale, 2));
        }
    }
}
