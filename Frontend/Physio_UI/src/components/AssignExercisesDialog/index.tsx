import { useEffect, useState } from 'react';
import {
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    Button,
    CircularProgress,
    Typography,
    FormControlLabel,
    Checkbox,
    Stack,
} from '@mui/material';
import type ExerciseDto from '../../types/ExerciseDto';

interface AssignExercisesDialogProps {
    open: boolean;
    onClose: () => void;
    onAdd: (selectedExerciseIds: number[]) => void;
    availableExercises: ExerciseDto[];
    assignedExerciseIds: number[];
    loading: boolean;
    error: string | null;
}

export default function AssignExercisesDialog({
    open,
    onClose,
    onAdd,
    availableExercises,
    assignedExerciseIds,
    loading,
    error,
}: AssignExercisesDialogProps) {
    const [selectedExercises, setSelectedExercises] = useState<number[]>([]);

    useEffect(() => {
        setSelectedExercises(assignedExerciseIds);
    }, [assignedExerciseIds]);

    const handleCheckboxChange = (exerciseId: number) => {
        setSelectedExercises((prevSelected) =>
            prevSelected.includes(exerciseId)
                ? prevSelected.filter((id) => id !== exerciseId) // Uncheck
                : [...prevSelected, exerciseId] // Check
        );
    };

    const handleAdd = () => {
        onAdd(selectedExercises);
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Assign Exercise</DialogTitle>
            <DialogContent>
                {loading ? (
                    <CircularProgress />
                ) : error ? (
                    <Typography color="error">Failed to load exercises</Typography>
                ) : (
                    <Stack spacing={2}>
                        {availableExercises.map((exercise) => (
                            <FormControlLabel
                                key={exercise.id}
                                control={
                                    <Checkbox
                                        checked={selectedExercises.includes(exercise.id)}
                                        onChange={() => handleCheckboxChange(exercise.id)}
                                    />
                                }
                                label={exercise.name}
                            />
                        ))}
                    </Stack>
                )}
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} color="secondary">
                    Cancel
                </Button>
                <Button onClick={handleAdd} color="primary" disabled={selectedExercises.length === 0}>
                    Add
                </Button>
            </DialogActions>
        </Dialog>
    );
}