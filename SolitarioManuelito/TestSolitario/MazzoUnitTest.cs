using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class MazzoUnitTest
    {

        [TestMethod]
        public void RicostruisciMazzo_RicostruitoCorrettamente()
        {
            Mazzo mazzo = new Mazzo();
            Carta carta = new Carta(Valore.Asso, Semi.A);
            mazzo.Ricostruisci(new List<Carta> { carta });
            Carta actual = mazzo.PescaCarta();
            Assert.AreEqual(carta, actual);
        }
        [TestMethod]
        public void RicostruisciMazzo_CarteVuote()
        {
            Mazzo mazzo = new Mazzo();
            Assert.ThrowsException<Exception>(() => mazzo.Ricostruisci(new List<Carta>()));                  
        }
    }
}
