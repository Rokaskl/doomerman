using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests
{
    [TestClass]
    public class AppOptionsTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private AppOptions CreateAppOptions()
        {
            return new AppOptions();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var appOptions = this.CreateAppOptions();

            // Act


            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
