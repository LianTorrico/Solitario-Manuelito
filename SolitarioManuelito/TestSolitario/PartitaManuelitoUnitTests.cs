using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class PartitaManuelitoUnitTests
    {
        [TestMethod]
        public void Partita_NomeVuoto()
        {
            Assert.ThrowsException<ArgumentException>(() => new PartitaManuelito(""));
        }
        [TestMethod]
        public void Partita_NomeLungo13()
        {
            Assert.ThrowsException<ArgumentException>(() => new PartitaManuelito("abcdeftoaodpw"));
        }
        [TestMethod]
        public void PescaMano_MazzoVuoto()
        {
            PartitaManuelito partitaTest = new PartitaManuelito("nome");
            for (int i = 0; i < 12 ; i++) partitaTest.PescaMano();
            Assert.ThrowsException<Exception>(() => partitaTest.PescaMano());
        }
        [TestMethod]
        public void PescaMano_ManoPescata()
        {
            PartitaManuelito partitaTest = new PartitaManuelito("nome");
            partitaTest.PescaMano();
            Assert.IsTrue(partitaTest.CarteUscite.Carte.Count() == 3);
        }
        [TestMethod]
        public void RicostruisciMazzo_MazzoVieneRicostruito()
        {
            PartitaManuelito partitaTest = new PartitaManuelito("nome");
            for (int i = 0; i < 12; i++) partitaTest.PescaMano();
            partitaTest.RicostruisciMazzo();
            partitaTest.PescaMano();
        }
    }
}