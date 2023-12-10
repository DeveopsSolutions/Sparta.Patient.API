using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sparta.Models.Models;
using Sparta.Entities;
using Sparta.Patient.API.BusinessLayers;
using Microsoft.Extensions.Logging;
namespace Sparta.Patient.API.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        readonly IPatientBL patientBL;
        private readonly ILogger<PatientController> _logger;
        public PatientController(IConfiguration configuration, ILogger<PatientController> logger, IPatientBL _patientBL)
        {
            patientBL = _patientBL;
            _logger = logger;
        }

       
        [HttpGet]
        public IActionResult GetPatients()
        {
            try
            {
                var patientList = patientBL.GetPatients();
                return StatusCode(200,patientList);
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.ToString(), Array.Empty<Object>());
                return StatusCode(500, "An exception occured while trying to getting the patient data");
            }
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult createPatient(PatientDTO patient)
        {
            try
            {
                var patientList = patientBL.InsertPatient(patient);
                return StatusCode(200,patientList);
            }catch(Exception ex)
            {
                this._logger.LogError(ex.ToString(), Array.Empty<Object>());
                return StatusCode(500, "An exception occured while trying to inserting the patient data");
            }
        }
        [HttpPut]
        [Route("/Update")]
        public IActionResult UpdatePatient(PatientDTO patient)
        {
            try
            {
                patientBL.UpdatePatient(patient);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString(), Array.Empty<Object>());
                return StatusCode(500, "An exception occured while trying to updating the patient data");
            }
        }
        [HttpDelete]
        [Route("/Delete/{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
               var result= patientBL.DeletePatient(id);
                return StatusCode(200, true);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString(), Array.Empty<Object>());
                return StatusCode(500, "An exception occured while trying to Delete the patient data");
            }
        }
    }
}
