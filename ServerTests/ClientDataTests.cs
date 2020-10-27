using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;

namespace ServerTests
{
    [TestClass]
    public class ClientDataTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ClientData CreateClientData()
        {
            return new ClientData();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var clientData = this.CreateClientData();

            // Act


            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
