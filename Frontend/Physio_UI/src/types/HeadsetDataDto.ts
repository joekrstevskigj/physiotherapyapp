export default interface HeadsetDataDto {
    patientId: number;
    resultOfExercise: {
        id: number;
        name: string;
        repetitions: number;
        sets: number;
        durationSeconds: number;
    }[];
    exercisesAssigned: {
        id: number;
        name: string;
        repetitions: number;
        sets: number;
        durationSeconds: number;
    }[];
    patientData: {
        id: number;
        firstName: string;
        lastName: string;
        exercises: number[];
    };
}