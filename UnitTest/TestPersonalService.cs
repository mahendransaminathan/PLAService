using NUnit.Framework;
using Moq;
using PLAService.Entities;
using PLAService.Providers;
using PLAService.PersonalServices;
using System;

using PLAService.Data;
using Microsoft.EntityFrameworkCore;


namespace PLAService.Tests
{
    public class PersonalServiceTests
    {

        private Mock<PersonalProvider> mockProvider;
        private PersonalService personalService;

        private ApplicationDBContext dbContext;


        [SetUp]
        public void Setup()
        {

            // Create mock for PersonalProvider
            mockProvider = new Mock<PersonalProvider>();

            // Instantiate PersonalService with the mocked provider

            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase("TestDatabase") // Use in-memory DB
                .Options;

            dbContext = new ApplicationDBContext(options); // Initialize DB context

            // Mock the PersonalProvider, injecting the real DbContext if needed
            mockProvider = new Mock<PersonalProvider>(dbContext);

            // Inject the mocked PersonalProvider into PersonalService

            personalService = new PersonalService(mockProvider.Object);
        }

        [Test]
        public void AddPerson_ShouldThrowArgumentException_WhenPersonIsNull()
        {
            // Arrange
            Person person = null;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => personalService.AddPerson(person));
            Assert.That(ex.Message, Is.EqualTo("Person data is required."));
        }

        [Test]
        public void AddPerson_ShouldCallAddPersonMethod_WhenPersonIsValid()
        {
            var mockProvider = new Mock<IPersonalProvider>();
            var personalService = new PersonalService(mockProvider.Object);

            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                AddressLine1 = "123 Main St",
                AddressLine2 = "Apt 101",
                City = "Some City",
                Country = "Country",
                Eircode = "1234",
                PhoneNumber = "1234567890",
                EmailID = "john.doe@example.com"
            };

            // Act
            personalService.AddPerson(person);

            // Assert
            mockProvider.Verify(p => p.AddPerson(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void AddPerson_ShouldNotCallAddPersonMethod_WhenPersonIsNull()
        {
            // Arrange
            Person person = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => personalService.AddPerson(person));
            mockProvider.Verify(p => p.AddPerson(It.IsAny<Person>()), Times.Never);
        }
    }
}
