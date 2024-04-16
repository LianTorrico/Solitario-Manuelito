using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class PartitaManuelitoUnitTests
    {
        [TestMethod]
        public void PescaMano_MazzoVuoto()
        {
            PartitaManuelito partitaTest = new PartitaManuelito();
            for (int i = 0; i < 12 ; i++) partitaTest.PescaMano();
            Assert.ThrowsException<Exception>(() => partitaTest.PescaMano());
        }
        [TestMethod]
        public void PescaMano_ManoPescata()
        {
            PartitaManuelito partitaTest = new PartitaManuelito();
            partitaTest.PescaMano();
            Assert.IsTrue(partitaTest.CarteUscite.Count() == 3);
        }
        [TestMethod]
        public void RicostruisciMazzo_MazzoVieneRicostruito()
        {
            PartitaManuelito partitaTest = new PartitaManuelito();
            for (int i = 0; i < 12; i++) partitaTest.PescaMano();
            partitaTest.RicostruisciMazzo();
            partitaTest.PescaMano();
        }
    }
}