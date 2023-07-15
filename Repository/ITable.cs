using Assignment8July.Model;
using Assignment8July.ResponseModel;
using Assignment8July.ViewModel;

namespace Assignment8July.Repository
{
    public interface ITable
    {
        public GetEmployeResponse GetEmployeeRecord();
        public GetEmployeByIdResponse GetEmployeeByIdrecord(int id);
        public AddEmployeResponse AddEmployeeRecord(AddEmployeView employe);
        public UpdateEmployeResponse UpdateEmployeeRecord(UpdateViewModel update);
        public DeleteView DeleteEmployeRecord(int id);

        public List<GenderTable12> GetGender();
        public CountryResponse GetCountry();
        public cityresponse GetCity(int id);
        public Stateresponse GetState(int id);

    }
}
