using NUnit.Framework;


namespace FirstAPPInMVC.Controllers
{
   [TestFixture]
    public class HomeControllerTest
    {

        [Test]
        public void TestIndexView()
        {
            // Arrange
            int a = 5;
            int b = 7;

            // Act
            int resultado = a + b;

            // Assert
            Assert.AreEqual(12, resultado);
        }
    }
}
