namespace API.Interfaces.Data
{
    using API.Data;
    using API.Models;

    public interface IApplicationData
    {
        public List<PatientModel> Patients { get; } 
        public List<ExerciseModel> Exercises { get; } 
        public List<HeadsetDataModel> HeadsetData { get; }
    }
}
