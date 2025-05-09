import { Box, Typography, Paper, Button, Divider, CircularProgress } from '@mui/material';
import React, { useState } from 'react';
import type PatientDto from '../../types/PatientDto';
import type ExerciseDto from '../../types/ExerciseDto';
import useApi from '../../hooks/useApi';
import PatientSubItem from '../PatientSubItem';

export default function PatientItem(props: {
  patient: PatientDto,
  index: number
}) {
  const { data: exercises, loading, error, fetchData } = useApi<ExerciseDto[]>('ExerciseContoller/GetExercisesById');
  const [isSubviewVisible, setIsSubviewVisible] = useState(false);

  const handleViewClick = async () => {
    if (isSubviewVisible) {
      setIsSubviewVisible(false);
      return;
    }

    if (exercises) {
      setIsSubviewVisible(true);
      return;
    }

    loadExercises();
  };

  const handleExerciseUpdate = async (updatedExercises: number[]) => {
    await loadExercises(updatedExercises);
  }

  const loadExercises = async (exerciseIds: number[] = props.patient.exercises) => {
    const queryString = exerciseIds
      .map((exerciseId) => `exerciseID=${exerciseId}`)
      .join('&');

    await fetchData('GET', queryString);
    setIsSubviewVisible(true);
  }

  return (
    <React.Fragment>
      <Paper sx={{ p: 2 }}>
        <Box
          display="flex"
          alignItems="start"
          justifyContent="space-between"
          flexWrap="wrap"
          gap={1}
        >
          <Typography sx={{ flexGrow: 1, textAlign: 'left' }}>
            {props.index + 1}. {props.patient.lastName}, {props.patient.firstName}
          </Typography>
          <Typography sx={{ minWidth: '140px', textAlign: 'right' }}>
            Prescription(s): {props.patient.exercises.length}
          </Typography>
          <Button variant="outlined" size="small" onClick={handleViewClick} disabled={loading}>
            {loading ? <CircularProgress size="1rem" /> : isSubviewVisible ? 'Hide' : 'View'}
          </Button>
        </Box>
        {error && <p>Error: {error}</p>}
        {isSubviewVisible && exercises &&
          <PatientSubItem exercises={exercises} onExercisesUpdated={(updatedExercises) => handleExerciseUpdate(updatedExercises)} patientId={props.patient.id} />}
      </Paper>
      <Divider />
    </React.Fragment>
  );
}