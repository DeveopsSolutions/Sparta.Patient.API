using Sparta.Patient.API.DataAccessLayers;
namespace Sparta.Patient.API.BusinessLayers
{
    public class BaseBL
    {
        protected readonly UnitOfWork _unitOfWork;
        public BaseBL(IConfiguration configuration)
        {
            _unitOfWork = new UnitOfWork(configuration);
        }
    }
}
