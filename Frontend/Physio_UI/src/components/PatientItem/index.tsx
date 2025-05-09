import { Box, Typography, Paper, Button, Divider } from '@mui/material';
import React from 'react';
import type PatientDto from '../../types/PatientDto';

export default function PatientItem(props :{
  patient:PatientDto,
  index :number
}) {
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
            prescription(s): {props.patient.prescriptionCount}
          </Typography>
          <Button variant="outlined" size="small">
            View
          </Button>
        </Box>
      </Paper>
      <Divider />
    </React.Fragment>
  );
}