using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Core.Services;
using EnqueteApi.Test.Config;
using Moq;
using NUnit.Framework;
using System;

namespace EnqueteApi.Test.Service
{
    public class OptionServiceTest
    {
        private Mock<OptionsService> optionsServiceMock;

        private Mock<IOptionsRepository> optionsRepositorioMock;

        private Option optionsDbMock;

        [SetUp]
        public void Setup()
        {
            optionsDbMock = OptionTestMock.GetOptionMock();

            optionsRepositorioMock = new Mock<IOptionsRepository>();

            optionsRepositorioMock.Setup(s => s.GetbyId(It.IsAny<int>())).Returns(optionsDbMock);
            

            optionsServiceMock = new Mock<OptionsService>(optionsRepositorioMock.Object);
        }

        [Test]
        public void VoteOptionsExceptionNotFound()
        {

            optionsRepositorioMock.Setup(s => s.GetbyId(It.IsAny<int>())).Returns((Option)null);

            var ex = Assert.Throws<ArgumentException>(() => optionsServiceMock.Object.Update(optionsDbMock));
            Assert.That(ex.Message, Is.EqualTo("Opção não encontrada!"));
            optionsRepositorioMock.Verify(p => p.Update(It.IsAny<Option>()), Times.Never);
        }

        [Test]
        public void VoteOptionsSuccess()
        {
            optionsDbMock.Count = 1;
            optionsRepositorioMock.Setup(s => s.Update(It.IsAny<Option>())).Returns(optionsDbMock);

            var optionsMock = OptionTestMock.GetOptionMock();
            var result = optionsServiceMock.Object.Update(optionsMock);

            Assert.NotNull(result);
            Assert.True(result.Count == optionsDbMock.Count);
            optionsRepositorioMock.Verify(p => p.Update(It.IsAny<Option>()), Times.Once);
        }
    }
}
