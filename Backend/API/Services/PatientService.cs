namespace API.Services
{
    using API.DTOs.Request;
    using API.DTOs.Response;
    using API.Interfaces.Repositories;
    using API.Interfaces.Services;
    using API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreatePatientAsync(CreatePatientRequestDto newPatient)
        {
            if (string.IsNullOrEmpty(newPatient.FirstName) || string.IsNullOrEmpty(newPatient.LastName))
            {
                throw new ArgumentNullException(nameof(newPatient), "FirstName and LastName cannot be null.");
            }
            
            var patient = new PatientModel
            {
                Name = newPatient.FirstName,
                LastName = newPatient.LastName,
                Exercises = [],
            };

            return await _repository.AddAsync(patient).ConfigureAwait(false); ;
        }

        public async Task<List<PatientResponseDto>> GetAllPatientsAsync()
        {
            var result = await _repository.GetAllAsync().ConfigureAwait(false);

            return result
                .Select(p => new PatientResponseDto()
                {
                    Id = p.Id,
                    FirstName = p.Name,
                    LastName = p.LastName,
                    Exercises = p.Exercises.ToList(),
                })
                .ToList();
        }

        public async Task<PatientResponseDto?> GetPatientAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id).ConfigureAwait(false);
            return patient == null
                ? null
                : new PatientResponseDto()
                {
                    Id = patient.Id,
                    FirstName = patient.Name,
                    LastName = patient.LastName,
                    Exercises = patient.Exercises.ToList(),
                };
        }

        public async Task<int> AssingExercise(int patientId, int exerciseId)
        {
            if (exerciseId <= 0 || patientId <= 0)
            {
                return -1;
            }

            var result = await _repository.AddExerciseAsync(patientId, exerciseId).ConfigureAwait(false);  

            return result; 
        }
    }
}
