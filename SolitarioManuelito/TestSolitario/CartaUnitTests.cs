
using SolitarioClassi;
namespace TestSolitario
{
    [TestClass]
    public class CartaUnitTests
    {
        [TestMethod]
        public void Carta_Valore0()
        {
            Assert.ThrowsException<ArgumentException>(() => new Carta((Valore)0,Semi.A));
        }
        [TestMethod]
        public void Carta_Valore11()
        {
            Assert.ThrowsException<ArgumentException>(() => new Carta((Valore)11, Semi.A));
        }
        [TestMethod]
        public void Carta_Seme0()
        {
            Assert.ThrowsException<ArgumentException>(() => new Carta(Valore.Asso, (Semi)0));
        }
        [TestMethod]
        public void Carta_Seme5()
        {
            Assert.ThrowsException<ArgumentException>(() => new Carta(Valore.Asso, (Semi)5));
        }
    }
}
