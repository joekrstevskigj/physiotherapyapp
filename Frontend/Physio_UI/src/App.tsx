import './App.css'
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import Patients from './pages/Patients';
import HeadsetDataPage from './pages/HeadsetDataPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Patients />} />
        <Route path="/headset-data/:patientId" element={<HeadsetDataPage />} />
      </Routes>
    </Router>
  );

}

export default App
