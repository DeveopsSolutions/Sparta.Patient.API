using Sparta.Models.Models;

namespace Sparta.Patient.API.BusinessLayers
{
  public interface IPatientBL
    {
        IEnumerable<PatientDTO> GetPatients();
        PatientDTO GetPatientByID(int id);
        int InsertPatient(PatientDTO patientDTO);
        void UpdatePatient(PatientDTO patientDTO);
        int DeletePatient(int id);
    }
}
