import PatientItem from "../../components/PatientItem";
import type PatientDto from "../../types/PatientDto";
import { Stack, Typography } from '@mui/material';

export default function PatientList(props: {
    patients: PatientDto[]
}) {
    return (
        <Stack spacing={2} sx={{ p: 4 }}>
            <Typography variant="h4" gutterBottom>
                Patient Records
            </Typography>
            {props.patients.map((patient, index) => (
                <PatientItem key={patient.id} patient={patient} index={index} />
            ))}
        </Stack>
    );
}