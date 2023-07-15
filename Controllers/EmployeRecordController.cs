using Assignment8July.Repository;
using Assignment8July.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment8July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeRecordController : ControllerBase
    {
        private readonly ITable ITab;
        public EmployeRecordController(ITable obj)
        {
            ITab = obj;
        }

        [HttpGet]
        [Route("GetAllData")]
        public IActionResult GetAllData()
        {
            var obj = ITab.GetEmployeeRecord();
            return Ok(obj);
        }
        [HttpGet]
        [Route("GetByIdData")]
        public IActionResult GetByIdData(int id)
        {
            var obj = ITab.GetEmployeeByIdrecord(id);
            return Ok(obj);
        }
        [HttpGet]
        [Route("GetGenderRecord")]
        public IActionResult GetGenderRecord()
        {
            var obj = ITab.GetGender();
            return Ok(obj);
        }
        [HttpGet]
        [Route("GetCountryRecord")]
        public IActionResult GetCountryRecord()
        {
            var obj = ITab.GetCountry();
            return Ok(obj);
        }
        [HttpGet]
        [Route("GetStateRecord")]
        public IActionResult GetStateRecord(int id)
        {
            var obj = ITab.GetState(id);
            return Ok(obj);
        }
        [HttpGet]
        [Route("GetciyRecord")]
        public IActionResult GetciyRecord(int id)
        {
            var obj = ITab.GetCity(id);
            return Ok(obj);
        }
        [HttpPost]
        [Route("AddAllData")]
        public IActionResult AddAllData( AddEmployeView emp)
        {
            var obj = ITab.AddEmployeeRecord(emp);
            return Ok(obj);
        }

        [HttpPost]
        [Route("UpdateRecord")]
        public IActionResult UpdateRecord([FromBody] UpdateViewModel update)
        {
            var obj = ITab.UpdateEmployeeRecord(update);
            return Ok(obj);
        }
        [HttpDelete]
        [Route("deletedata")]
        public IActionResult DeleteAllData(int id)
        {
            var obj = ITab.DeleteEmployeRecord(id);
            return Ok(obj);
        }
    }
}
