﻿using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Core.Services;
using EnqueteApi.Test.Config;
using Moq;
using NUnit.Framework;
using System;

namespace EnqueteApi.Test.Service
{
    public class PollServiceTest
    {
        private Mock<PollService> pollServiceMock;

        private Mock<IPollRepository> pollRepositorioMock;

        [SetUp]
        public void Setup()
        {
            pollRepositorioMock = new Mock<IPollRepository>();
            
            var pollMock = PollTestMock.GetPollMock();

            pollRepositorioMock.Setup(s => s.GetbyId(It.IsAny<int>())).Returns(pollMock);           
            pollRepositorioMock.Setup(s => s.Add(It.IsAny<Poll>())).Returns(pollMock.Id);

            pollServiceMock = new Mock<PollService>(pollRepositorioMock.Object);
        }

        [Test]
        public void GetPollByIdSuccess()
        {
            var pollDbMock = PollTestMock.GetPollMock();
            var result = pollServiceMock.Object.GetbyId(It.IsAny<int>());

            Assert.NotNull(result);
            Assert.AreEqual(pollDbMock.Id, result.Id);
            Assert.AreEqual(pollDbMock.PollDescription, result.PollDescription);
            Assert.AreEqual(pollDbMock.Options.Count, result.Options.Count);
        }

        [Test]
        public void GetPollByIdExceptionNotFound()
        {
            pollRepositorioMock.Setup(s => s.GetbyId(It.IsAny<int>())).Returns((Poll)null);
            
            var ex = Assert.Throws<ArgumentException>(() => pollServiceMock.Object.GetbyId(It.IsAny<int>()));
            Assert.That(ex.Message, Is.EqualTo("Enquete não encontrada!"));

            pollRepositorioMock.Verify(p => p.Add(It.IsAny<Poll>()), Times.Never);
        }

        [Test]
        public void AddPollSuccess()
        {
            var pollDbMock = PollTestMock.GetPollMock();
            var result = pollServiceMock.Object.Add(pollDbMock);

            Assert.NotNull(result);
            Assert.AreEqual(pollDbMock.Id, result);

            pollRepositorioMock.Verify(p => p.Add(It.IsAny<Poll>()), Times.Once);
        }
    }
}
