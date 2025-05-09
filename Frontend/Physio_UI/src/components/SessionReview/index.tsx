import { Box, Divider, Stack, Typography } from "@mui/material";
import { BarChart } from "@mui/x-charts";
import type HeadsetDataDto from "../../types/HeadsetDataDto";

export default function SessionReview(props:{
    data:HeadsetDataDto
}) {
    return (
        <Stack gap={2}>
            {
                props.data.resultOfExercise.map((exercise) => {
                    const assignedExercise = props.data.exercisesAssigned.find((e) => e.id === exercise.id);

                    if (!assignedExercise) return null;

                    const propertiesToCompare = Object.keys(exercise).filter(
                        (key) => key !== 'id' && key !== 'name'
                    );

                    const series = [
                        {
                            label: 'Result of Session',
                            data: propertiesToCompare.map((key) => typeof exercise[key as keyof typeof exercise] === 'number' ? exercise[key as keyof typeof exercise] as number : null),
                        },
                        {
                            label: 'Target Exercise',
                            data: propertiesToCompare.map((key) => typeof assignedExercise[key as keyof typeof assignedExercise] === 'number' ? assignedExercise[key as keyof typeof assignedExercise] as number : null),
                        },
                    ];

                    const xAxis = [{ data: propertiesToCompare }];

                    return (
                        <Box key={exercise.id}>
                            <Typography variant="caption" textAlign={'left'}>
                                {assignedExercise.name || ''}
                            </Typography>
                            <BarChart series={series} height={250} xAxis={xAxis} />
                            <Divider sx={{ my: 2 }} />
                        </Box>
                    );
                })}
        </Stack>
    );
}