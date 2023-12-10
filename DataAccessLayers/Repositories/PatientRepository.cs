

namespace Sparta.Patient.API.DataAccessLayers.Repositories
{
    public class PatientRepository : RepositoryBase<Entities.Patient, int>
    {
        public PatientRepository(PatientDbContext context) : base(context) { }
    }
}
