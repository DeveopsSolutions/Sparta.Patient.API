using Common.Utilities.AutoMapper;
using Sparta.Entities;
using Sparta.Models.Models;
using Sparta.Patient.API.DataAccessLayers.Repositories;

namespace Sparta.Patient.API.BusinessLayers
{
    public class PatientBL : BaseBL, IPatientBL
    {
        public PatientBL(IConfiguration configuration) : base(configuration) { 
        
        }

        public IEnumerable<PatientDTO> GetPatients()
        {
            return Mapping.Mapper.Map<IEnumerable<PatientDTO>>(_unitOfWork.PatientRepository.GetAll());
        }

        public PatientDTO GetPatientByID(int id)
        {
            return Mapping.Mapper.Map<PatientDTO>(_unitOfWork.PatientRepository.GetByID(id));
        }

        public int InsertPatient(PatientDTO patientDTO)
        {
            return _unitOfWork.PatientRepository.Add(Mapping.Mapper.Map<Entities.Patient>(patientDTO));
        }

        public void UpdatePatient(PatientDTO patientDTO)
        {
            _unitOfWork.PatientRepository.Update(Mapping.Mapper.Map<Entities.Patient>(patientDTO));
        }

        public int DeletePatient(int id)
        {      
           return _unitOfWork.PatientRepository.DeleteById(id);
        }
    }
}
