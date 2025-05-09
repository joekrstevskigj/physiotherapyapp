import { useState, useEffect } from 'react';
import { Box, Typography, Button } from '@mui/material';
import Grid from '@mui/material/Grid';
import type ExerciseDto from '../../types/ExerciseDto';
import useApi from '../../hooks/useApi';
import AssignExercisesDialog from '../AssignExercisesDialog';
import { useNavigate } from 'react-router-dom';

export default function PatientSubItem(props: {
    exercises: ExerciseDto[];
    onExercisesUpdated: (newExercises: number[]) => void;
    patientId: number;
}) {
    const [isDialogOpen, setIsDialogOpen] = useState(false);
    const [availableExercises, setAvailableExercises] = useState<ExerciseDto[]>([]);

    const { data, loading, error, fetchData } = useApi<ExerciseDto[]>('ExerciseContoller/GetAll');
    const navigate = useNavigate();

    const handleOpenDialog = async () => {
        setIsDialogOpen(true);

        await fetchData();
    };

    useEffect(() => {
        if (data) {
            setAvailableExercises(data);
        }
    }, [data]);

    const handleCloseDialog = () => {
        setIsDialogOpen(false);
    };

    const hanldeHeadsetViewOpen = () => {
        navigate(`/headset-data/${props.patientId}`);
    }

    const handleAddExercises = async (selectedExerciseIds: number[]) => {
        const response = await fetch(`${import.meta.env.VITE_API_URL}Patient/AssignExerciseAsync`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                patientId: props.patientId,
                exercisesId: selectedExerciseIds,
            }),
        });

        if (response.ok) {
            props.onExercisesUpdated(selectedExerciseIds);
            handleCloseDialog();
        } else {
            console.error('Failed to assign exercise');
        }
    };

    return (
        <Box >
            <Typography pb={2} textAlign={'left'}>Exercises:</Typography>
            {props.exercises.map((exercise) => (
                <Grid container spacing={2} key={exercise.id}>
                    <Grid size={{ xs: 12, sm: 3 }}>
                        <Typography>Name: {exercise.name}</Typography>
                    </Grid>
                    <Grid size={{ xs: 12, sm: 3 }}>
                        <Typography>Repetitions: {exercise.repetitions}</Typography>
                    </Grid>
                    <Grid size={{ xs: 12, sm: 3 }}>
                        <Typography>Sets: {exercise.sets}</Typography>
                    </Grid>
                    <Grid size={{ xs: 12, sm: 3 }}>
                        <Typography>Duration: {exercise.durationSeconds} seconds</Typography>
                    </Grid>
                </Grid>

            ))}

            <Box
                display="flex"
                justifyContent="flex-end"
                gap={2}
                sx={{
                    mt: 2,
                    flexDirection: { xs: 'column', sm: 'row' },
                    alignItems: { xs: 'stretch', sm: 'center' },
                }}
            >
                <Button variant="outlined" color="primary" onClick={handleOpenDialog}>
                    Assign Exercise
                </Button>
                <Button variant="contained" color="primary" onClick={hanldeHeadsetViewOpen}>
                    View Headset Data
                </Button>
            </Box>


            <AssignExercisesDialog
                open={isDialogOpen}
                onClose={handleCloseDialog}
                onAdd={handleAddExercises}
                availableExercises={availableExercises}
                assignedExerciseIds={props.exercises.map((exercise) => exercise.id)}
                loading={loading}
                error={error}
            />
        </Box>
    );
}