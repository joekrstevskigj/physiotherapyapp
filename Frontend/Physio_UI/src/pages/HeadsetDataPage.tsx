import { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Box, Button, Typography, CircularProgress, Divider } from '@mui/material';
import useApi from '../hooks/useApi';
import type HeadsetDataDto from '../types/HeadsetDataDto';
import SessionReview from '../components/SessionReview';



export default function HeadsetDataPage() {
    const { patientId } = useParams<{ patientId: string }>();
    const navigate = useNavigate();

    const { data, loading, error, fetchData } = useApi<HeadsetDataDto>(`Headset/GetHeadsetDataForPatiendId?patientId=${patientId}`);

    useEffect(() => {
        if (patientId) {
            fetchData();
        }
    }, [patientId]);

    const handleOnBack = () => navigate("/");

    if (loading) {
        return (
            <Box p={2} textAlign="center">
                <CircularProgress />
            </Box>
        );
    }

    return (
        <Box p={2} textAlign={'left'}>
            <Button variant="outlined" onClick={handleOnBack} sx={{ mb: 2 }}>
                Back
            </Button>
            {
                error || !data ? <Typography variant='h5'>No data available!</Typography>
                    : <>
                        <Typography variant="h4" gutterBottom>
                            Review of session data
                        </Typography>

                        <Divider sx={{ my: 2 }} />

                        <Typography variant="h5" gutterBottom textAlign={'left'}>
                            Patient Data
                        </Typography>
                        
                        <Box mb={3} p={2} textAlign={'left'} border="1px solid #ccc" borderRadius={2}>
                            <Typography>First Name: <b>{data.patientData.firstName}</b>;
                                Last Name: <b>{data.patientData.lastName}</b></Typography>
                        </Box>

                        <SessionReview data={data} />
                    </>
            }
        </Box>
    );
}