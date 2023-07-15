
using Assignment8July.ViewModel;

namespace Assignment8July.ResponseModel
{
    public class GetEmployeResponse
    {
        public List<GetEmployeeView> getEmployeeData { get; set; }
        public string message { get; set; }
        public int statuscode { get; set; }

    }
    public class GetEmployeByIdResponse
    {
        public GetEmployeeView getEmployeeDataById { get; set; }
        public string message { get; set; }
        public int statuscode { get; set; }

    }
}
