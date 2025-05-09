using API.DTOs.Response;
using API.Interfaces.Repositories;
using API.Models;
using API.Services;
using Moq;
using Xunit;

namespace UnitTests.ServiceTests
{
    public class PatientServiceTest
    {
        private readonly Mock<IPatientRepository> _mockRepository;
        private readonly PatientService _patientService;

        public PatientServiceTest()
        {
            _mockRepository = new Mock<IPatientRepository>();
            _patientService = new PatientService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllPatientsAsync_ShouldReturnListOfPatients_WhenPatientsExist()
        {
            var patients = new List<PatientModel>
            {
                new PatientModel { Id = 1, Name = "John", LastName = "Doe", Exercises = new List<int> { 1, 2 } },
                new PatientModel { Id = 2, Name = "Jane", LastName = "Smith", Exercises = new List<int> { 3 } }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(patients);

            var result = await _patientService.GetAllPatientsAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].FirstName);
            Assert.Equal("Jane", result[1].FirstName);
        }

        [Fact]
        public async Task GetAllPatientsAsync_ShouldReturnEmptyList_WhenNoPatientsExist()
        {
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<PatientModel>());

            var result = await _patientService.GetAllPatientsAsync();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetPatientAsync_ShouldReturnPatient_WhenPatientExists()
        {
            var patient = new PatientModel { Id = 1, Name = "John", LastName = "Doe", Exercises = new List<int> { 1, 2 } };
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(patient);

            var result = await _patientService.GetPatientAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        [Fact]
        public async Task GetPatientAsync_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            
            _mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((PatientModel?)null);

            var result = await _patientService.GetPatientAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task AssingExercise_ShouldReturnPositiveResult_WhenExerciseIsAssigned()
        {
            var patientId = 1;
            var exercises = new List<int> { 1, 2 };
            _mockRepository.Setup(repo => repo.AddExerciseAsync(patientId, exercises)).ReturnsAsync(1);

            var result = await _patientService.AssingExercise(patientId, exercises);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task AssingExercise_ShouldReturnNegativeResult_WhenPatientIdIsInvalid()
        {
            var patientId = -1;
            var exercises = new List<int> { 1, 2 };

            var result = await _patientService.AssingExercise(patientId, exercises);

            Assert.Equal(-1, result);
        }

        [Fact]
        public async Task AssingExercise_ShouldReturnNegativeResult_WhenExercisesAreNull()
        {
            var patientId = 1;

            var result = await _patientService.AssingExercise(patientId, null);

            Assert.Equal(-1, result);
        }
    }
}
