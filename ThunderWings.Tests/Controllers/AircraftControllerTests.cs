using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ThunderWings.API.Controllers;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;
using Xunit;


namespace ThunderWings.Tests.Controllers
{
    public class AircraftControllerTests
    {
        private readonly Mock<IAircraftRepository> _mockAircraftRepository;
        private readonly AircraftController _controller;

        public AircraftControllerTests()
        {
            _mockAircraftRepository = new Mock<IAircraftRepository>();
            _controller = new AircraftController(_mockAircraftRepository.Object);
        }


        [Fact]
        public async Task GetAircraft_ReturnsOkResult_WithAircraftList()
        {
            // Arrange
            var aircraftList = new List<Aircraft>
            {
                new Aircraft { Id = 1, Name = "F-22 Raptor", Manufacturer = "Lockheed Martin", Country = "USA", Role = "Fighter", TopSpeed = 2410, Price = 150000000 },
                new Aircraft { Id = 2, Name = "Su-57", Manufacturer = "Sukhoi", Country = "Russia", Role = "Fighter", TopSpeed = 2600, Price = 40000000 }
            };
            _mockAircraftRepository.Setup(repo => repo.GetAircraftAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<AircraftFilter>()))
                                .ReturnsAsync(aircraftList);

            // Act
            var result = await _controller.GetAircraft(1, 10, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Aircraft>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }

        [Fact]
        public async Task GetAircraft_ReturnsEmptyList_WhenNoAircrafts()
        {
            // Arrange
            _mockAircraftRepository.Setup(repo => repo.GetAircraftAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<AircraftFilter>()))
                                .ReturnsAsync(new List<Aircraft>());

            // Act
            var result = await _controller.GetAircraft(1, 10, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Aircraft>>(okResult.Value);
            Assert.Empty(returnValue);
        }

        [Fact]
        public async Task GetAircraft_UsesProvidedFilter()
        {
            // Arrange
            var filter = new AircraftFilter { Country = "USA" };
            _mockAircraftRepository.Setup(repo => repo.GetAircraftAsync(It.IsAny<int>(), It.IsAny<int>(), filter))
                                .ReturnsAsync(new List<Aircraft>());

            // Act
            var result = await _controller.GetAircraft(1, 10, filter);

            // Assert
            _mockAircraftRepository.Verify(repo => repo.GetAircraftAsync(1, 10, filter), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Aircraft>>(okResult.Value);
            Assert.Empty(returnValue);
        }
    }
}