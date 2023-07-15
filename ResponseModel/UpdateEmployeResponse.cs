using Assignment8July.ViewModel;

namespace Assignment8July.ResponseModel
{
    public class UpdateEmployeResponse
    {
        public UpdateViewModel UpdateEmployeData { get; set; }
        public string message { get; set; }
        public int statuscode { get; set; }
    }
}

