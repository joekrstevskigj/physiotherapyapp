import './App.css'
import { useEffect, useState } from 'react';
import type PatientDto from './types/PatientDto';
import PatientList from './pages/PatientList';

function App() {

  const [patients, setPatients] = useState<PatientDto[]>([]);

  useEffect(() => {
    setPatients([
      {
        id: 1,
        firstName: "Joe",
        lastName: "Doe",
        prescriptionCount: 3,
      },
      {
        id: 2,
        firstName: "Jane",
        lastName: "Dolly",
        prescriptionCount: 2,
      },
      {
        id: 3,
        firstName: "Cristopher",
        lastName: "DeJohnosson",
        prescriptionCount: 2,
      },
    ])
  }, []);

  return (
    <PatientList patients={patients} />
  )
}

export default App
