using Sparta.Models.Models;
using Sparta.Patient.API.DataAccessLayers.Repositories;

namespace Sparta.Patient.API.DataAccessLayers
{
    public class UnitOfWork
    {
        protected PatientDbContext context;

        public UnitOfWork(IConfiguration configuration)
        {
            context = new PatientDbContext(configuration);
        }

        private PatientRepository _patientRepository;
        public PatientRepository PatientRepository => _patientRepository ?? (_patientRepository = new PatientRepository(context));
    }
}
