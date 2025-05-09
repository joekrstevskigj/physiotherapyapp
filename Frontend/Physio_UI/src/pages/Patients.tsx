import { useEffect } from "react";
import useApi from "../hooks/useApi";
import { CircularProgress } from "@mui/material";
import PatientList from "../components/PatientList";
import type PatientDto from "../types/PatientDto";

export default function Patients() {
    const { data: patients, loading, error, fetchData } = useApi<PatientDto[]>('Patient/GetAllPatients');

    useEffect(() => {
        fetchData();
    }, []);

    if (loading) return <CircularProgress size="3rem" />;
    if (error) return <p>Error: {error}</p>;

    return <PatientList patients={patients || []} />;
}