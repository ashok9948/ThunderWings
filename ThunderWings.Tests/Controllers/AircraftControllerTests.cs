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
        // Mock repository used to simulate interactions with the aircraft repository
        private readonly Mock<IAircraftRepository> _mockAircraftRepository;
        // Controller instance under test
        private readonly AircraftController _controller;

        public AircraftControllerTests()
        {
            // Initialize the mock repository and controller with the mock repository
            _mockAircraftRepository = new Mock<IAircraftRepository>();
            _controller = new AircraftController(_mockAircraftRepository.Object);
        }

        [Fact]
        public async Task GetAircraft_ReturnsOkResult_WithAircraftList()
        {
            // Arrange: Create a sample list of aircrafts and setup the mock repository to return this list
            var aircraftList = new List<Aircraft>
            {
                new Aircraft { Id = 1, Name = "F-22 Raptor", Manufacturer = "Lockheed Martin", Country = "USA", Role = "Fighter", TopSpeed = 2410, Price = 150000000 },
                new Aircraft { Id = 2, Name = "Su-57", Manufacturer = "Sukhoi", Country = "Russia", Role = "Fighter", TopSpeed = 2600, Price = 40000000 }
            };
            _mockAircraftRepository.Setup(repo => repo.GetAircraftAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<AircraftFilter>()))
                                .ReturnsAsync(aircraftList);

            // Act: Call the GetAircraft method of the controller
            var result = await _controller.GetAircraft(1, 10, null);

            // Assert: Verify that the result is an OkObjectResult and contains the expected list of aircraft
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Aircraft>>(okResult.Value);
            Assert.Equal(2, returnValue.Count()); // Ensure the returned list has 2 items
        }

        [Fact]
        public async Task GetAircraft_ReturnsEmptyList_WhenNoAircrafts()
        {
            // Arrange: Setup the mock repository to return an empty list of aircraft
            _mockAircraftRepository.Setup(repo => repo.GetAircraftAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<AircraftFilter>()))
                                .ReturnsAsync(new List<Aircraft>());

            // Act: Call the GetAircraft method of the controller
            var result = await _controller.GetAircraft(1, 10, null);

            // Assert: Verify that the result is an OkObjectResult and contains an empty list
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Aircraft>>(okResult.Value);
            Assert.Empty(returnValue); // Ensure the returned list is empty
        }

        [Fact]
        public async Task GetAircraft_UsesProvidedFilter()
        {
            // Arrange: Create a filter and setup the mock repository to return an empty list for this filter
            var filter = new AircraftFilter { Country = "USA" };
            _mockAircraftRepository.Setup(repo => repo.GetAircraftAsync(It.IsAny<int>(), It.IsAny<int>(), filter))
                                .ReturnsAsync(new List<Aircraft>());

            // Act: Call the GetAircraft method of the controller with the specified filter
            var result = await _controller.GetAircraft(1, 10, filter);

            // Assert: Verify that the repository's GetAircraftAsync method was called with the correct parameters
            _mockAircraftRepository.Verify(repo => repo.GetAircraftAsync(1, 10, filter), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<Aircraft>>(okResult.Value);
            Assert.Empty(returnValue); // Ensure the returned list is empty
        }
    }
}
