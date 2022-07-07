using AutoMapper;
using Moq;
using Petfy.Data.Models;
using Petfy.Data.Repositories;
using Petfy.Domain.Services;

namespace Petfy.Test
{
    [TestClass]
    public class PetServiceTest
    {
        private Mock<IPetRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private PetService _petService;
        public const int PetID0 = 0;
        public const int PetIDNotFound = 20;
        public const int PetIDNegative = -1;
        public const int PetIDNoOwner = 10;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPetRepository>();
            _mockRepository.Setup(r => r.DeletePet(PetID0)).Returns(false);
            _mockRepository.Setup(r => r.DeletePet(PetIDNegative)).Returns(false);
            _mockRepository.Setup(r => r.GetById(PetIDNotFound)).Returns((Pet)null);
            _mockRepository.Setup(r => r.GetById(PetIDNoOwner)).Returns(new Pet() { Owner = null });
            _petService = new PetService(_mockRepository.Object, _mockMapper.Object);
        }

        [TestCleanup]
        public void CleanUp()
        {
           
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_Negative()
        {
            //Act
            var result = _petService.DeletePet(PetIDNegative);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_0()
        {
            //Act
            var result = _petService.DeletePet(PetID0);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_Positive()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeletePet_Should_Throw_Exception_When_Not_Found()
        {
            //Act
            _petService.DeletePet(PetIDNotFound);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeletePet_Should_Throw_Exception_When_Owner_Is_Null()
        {
            _petService.DeletePet(PetIDNoOwner);
        }
    }
}