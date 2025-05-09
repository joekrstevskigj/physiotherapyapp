namespace API.Data
{
    using API.Interfaces.Data;
    using API.Models;

    public class ApplicationData : IApplicationData
    {
        private readonly List<PatientModel> _patients;
        private readonly List<ExerciseModel> _exercises;
        private readonly List<HeadsetDataModel> _headsetData;

        public ApplicationData()
        {
            _patients = new List<PatientModel>
                {
                    new PatientModel
                    {
                        Id = 1,
                        LastName = "Doe",
                        Name = "John",
                        Exercises = new List<int> { 1, 2 }
                    },
                    new PatientModel
                    {
                        Id = 2,
                        LastName = "Dolly",
                        Name = "Jane",
                        Exercises = new List<int> { 1, 2 }
                    },
                    new PatientModel
                    {
                        Id = 3,
                        LastName = "Crishtopher",
                        Name = "Jakson",
                        Exercises = new List<int> { 1 }
                    }
                };

            _exercises = new List<ExerciseModel>
                {
                    new ExerciseModel
                    {
                        Id = 1,
                        Name = "Exercise 1",
                        DurationSeconds = 20,
                        Repetitions = 3,
                        Sets = 4
                    },
                    new ExerciseModel
                    {
                        Id = 2,
                        Name = "Exercise 2",
                        DurationSeconds = 15,
                        Repetitions = 10,
                        Sets = 2
                    },
                    new ExerciseModel
                    {
                        Id = 3,
                        Name = "Exercise 3",
                        DurationSeconds = 125,
                        Repetitions = 3,
                        Sets = 1
                    },
                    new ExerciseModel
                    {
                        Id = 4,
                        Name = "Exercise 4",
                        DurationSeconds = 100,
                        Repetitions = 20,
                        Sets = 3
                    },
                    new ExerciseModel
                    {
                        Id = 5,
                        Name = "Exercise 5",
                        DurationSeconds = 358,
                        Repetitions = 21,
                        Sets = 13
                    }
                };

            _headsetData = new List<HeadsetDataModel>
                {
                    new HeadsetDataModel
                    {
                        PatiendId = 1,
                        ResultOfExercise = new List<ExerciseModel>
                        {
                            new ExerciseModel
                            {
                                Id = 1,
                                DurationSeconds = 30,
                                Repetitions = 2,
                                Sets = 1
                            },
                            new ExerciseModel
                            {
                                Id = 2,
                                DurationSeconds = 22,
                                Repetitions = 4,
                                Sets = 5
                            }
                        }
                    },
                    new HeadsetDataModel
                    {
                        PatiendId = 2,
                        ResultOfExercise = new List<ExerciseModel>
                        {
                            new ExerciseModel
                            {
                                Id = 1,
                                DurationSeconds = 30,
                                Repetitions = 2,
                                Sets = 1
                            },
                            new ExerciseModel
                            {
                                Id = 2,
                                DurationSeconds = 22,
                                Repetitions = 4,
                                Sets = 5
                            }
                        }
                    }
                };
        }

        public List<PatientModel> Patients => _patients;
        public List<ExerciseModel> Exercises => _exercises;
        public List<HeadsetDataModel> HeadsetData => _headsetData;
    }
}
