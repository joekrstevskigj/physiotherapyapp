namespace API.Repositories
{
    using API.Interfaces.Data;
    using API.Interfaces.Repositories;
    using API.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PatientRepository : IPatientRepository
    {
        private readonly IApplicationData applicationData;

        public PatientRepository(IApplicationData applicationData)
        {
            this.applicationData = applicationData;
        }

        public Task<int> AddAsync(PatientModel patient)
        {
            var _patients = applicationData.Patients;

            try
            {
                patient.Id = _patients[^1].Id + 1;
                _patients.Add(patient);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return Task.FromResult(-1);
            }
            

            return Task.FromResult(patient.Id);
        }

        public Task<int> AddExerciseAsync(int patientId, List<int> exerciseIds)
        {
            var _patients = applicationData.Patients;

            var patient = _patients.FirstOrDefault(p => p.Id == patientId);

            if (patient != null)
            {
                patient.Exercises = [];

                patient.Exercises.AddRange(exerciseIds);
                return Task.FromResult(1);
            }

            return Task.FromResult(-1);
        }

        public Task<List<PatientModel>> GetAllAsync()
        {
            var _patients = applicationData.Patients;

            return Task.FromResult(_patients.ToList());
        }

        public Task<PatientModel?> GetByIdAsync(int id)
        {
            var _patients = applicationData.Patients;

            var patient = _patients.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(patient);
        }
    }
}
