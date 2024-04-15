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
        

    }
}