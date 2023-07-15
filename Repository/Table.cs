using Assignment8July.Model;
using Assignment8July.ResponseModel;
using Assignment8July.ViewModel;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Assignment8July.Repository
{
    public class Table : ITable
    {
        public GetEmployeResponse GetEmployeeRecord()
        {
            GetEmployeResponse employe = new GetEmployeResponse();
            sdirectdbContext sd = new sdirectdbContext();
            try
            {
                var ObjEmp = (from emp in sd.EmployeTable12s.Where(h=>h.IsDeleted == false) 
                              join gd in sd.GenderTable12s on emp.GenderId equals gd.GenderId
                              join co in sd.CountryTable12s on emp.CountryId equals co.CountryId
                              join st in sd.StateTable12s on emp.StateId equals st.StateId
                              join ct in sd.CityTable12s on emp.CityId equals ct.CityId orderby emp.EmpId descending
                              select new GetEmployeeView  
                              {
                                
                                  EmpId = emp.EmpId,
                                  FirstName = emp.FirstName,
                                  LastName = emp.LastName,
                                  GenderId = emp.GenderId,
                                  Dob = emp.Dob,
                                  Phonenum = emp.Phonenum,
                                  CountryId = emp.CountryId,
                                  StateId = emp.StateId,
                                  CityId = emp.CityId,
                                  CreatedBy = emp.CreatedBy,
                                  CreatedDate = emp.CreatedDate,
                                  IsActive = emp.IsActive,
                                  IsDeleted = emp.IsDeleted,
                                  City = ct.City,
                                  CountryName = co.CountryName,
                                  Gender = gd.Gender,
                                  State = st.State,
                                  Zipcode=emp.Zipcode,
                                  Address=emp.Address
                                  
                              }).ToList();
                employe.getEmployeeData = ObjEmp;
                employe.statuscode = 200;
                employe.message = "success";
                return employe;
            }
            catch (Exception ex)
            {
                employe.statuscode = 400;
                employe.message = "Failed";
                return employe;
            }
        }

        public GetEmployeByIdResponse GetEmployeeByIdrecord(int id)
        {

            sdirectdbContext sd = new sdirectdbContext();
            GetEmployeByIdResponse name = new GetEmployeByIdResponse();
            var cl = sd.EmployeTable12s.FirstOrDefault(h => h.EmpId == id);
            if (cl != null)
            {
                var objemp = (from emp in sd.EmployeTable12s.Where(h => h.EmpId == id)
                              join gd in sd.GenderTable12s on emp.GenderId equals gd.GenderId
                              join co in sd.CountryTable12s on emp.CountryId equals co.CountryId
                              join st in sd.StateTable12s on emp.StateId equals st.StateId
                              join ct in sd.CityTable12s on emp.CityId equals ct.CityId
                              select new GetEmployeeView
                              {
                                  EmpId = emp.EmpId,
                                  FirstName = emp.FirstName,
                                  LastName = emp.LastName,
                                  GenderId = emp.GenderId,
                                  Dob = emp.Dob,
                                  Phonenum = emp.Phonenum,
                                  CountryId = emp.CountryId,
                                  StateId = emp.StateId,
                                  CityId = emp.CityId,
                                  CreatedBy = emp.CreatedBy,
                                  CreatedDate = emp.CreatedDate,
                                  IsActive = emp.IsActive,
                                  IsDeleted = emp.IsDeleted,
                                  City = ct.City,
                                  CountryName = co.CountryName,
                                  Gender = gd.Gender,
                                  State = st.State,
                                  Zipcode = emp.Zipcode,
                                  Address = emp.Address

                              }).FirstOrDefault();
                name.getEmployeeDataById = objemp;
                name.statuscode = 200;
                name.message = "OK";
                return name;
            }
            else
            {
                name.statuscode = 400;
                name.message = "ID not found";
                return name;
            }
        }
        public AddEmployeResponse AddEmployeeRecord(AddEmployeView employe)
        {
            AddEmployeResponse response = new AddEmployeResponse();
            sdirectdbContext sd = new sdirectdbContext();
            EmployeTable12 emp = new EmployeTable12();

            try
            {
                emp.FirstName = employe.FirstName;
                emp.LastName = employe.LastName;
                emp.GenderId = employe.GenderId;
                emp.CountryId = employe.CountryId;
                emp.StateId = employe.StateId;
                emp.CityId = employe.CityId;
                emp.Phonenum = employe.Phonenum;
                emp.Dob = employe.Dob;
                emp.CreatedBy = "admin";
                emp.CreatedDate = DateTime.Now;
                emp.Address = employe.Address;
                emp.Zipcode = employe.Zipcode;
                emp.IsActive = true;
                emp.IsDeleted = false;
                sd.Add(emp);
                sd.SaveChanges();
                response.AddEmployeData = employe;
                response.message = "success";
                response.statuscode = 200;
                return response;
            }
            catch (Exception ex)
            {
                response.statuscode = 400;
                response.message = "failed";
                return response;
            }

        }

        public UpdateEmployeResponse UpdateEmployeeRecord(UpdateViewModel update)
        {
            UpdateEmployeResponse updatedata = new UpdateEmployeResponse();
            sdirectdbContext sd = new sdirectdbContext();
            var objEmp = sd.EmployeTable12s.FirstOrDefault(l => l.EmpId == update.EmpId);
            if (objEmp != null)
            {
                
                objEmp.FirstName = update.FirstName;
                objEmp.LastName = update.LastName;
                objEmp.Address = update.Address;
                objEmp.Dob = update.Dob;
                objEmp.Phonenum = update.Phonenum;
                objEmp.GenderId = update.GenderId;
                objEmp.CountryId = update.CountryId;
                objEmp.StateId = update.StateId;
                objEmp.CityId = update.CityId;
                objEmp.Address = update.Address;
                objEmp.Zipcode = update.Zipcode;
                sd.SaveChanges();
                updatedata.UpdateEmployeData = update;
                updatedata.message = "success";
                updatedata.statuscode = 200;
                return updatedata;
            }

            else
            {
                updatedata.message = "error";
                updatedata.statuscode = 400;
                return updatedata;
            }
        }

        public List<GenderTable12> GetGender()
        {
            sdirectdbContext sd = new sdirectdbContext();
            var obj = sd.GenderTable12s.ToList();
            return obj;

        }

        public CountryResponse GetCountry()
        {
            CountryResponse country= new CountryResponse(); 
            sdirectdbContext sd = new sdirectdbContext();
            var obj = (from emp in sd.CountryTable12s
                       select new CountryView
                       {
                           CountryId = emp.CountryId,
                           CountryName = emp.CountryName,

                       }).ToList();
            country.GetCountryViews= obj;
            return country;
        }

        

        public Stateresponse GetState(int id)
        {
            Stateresponse state = new Stateresponse();
            sdirectdbContext sd = new sdirectdbContext();
            var objState = (from emp in sd.StateTable12s
                            where emp.CountryId== id
                       select new Stateview
                       {
                           StateId = emp.StateId,
                           State = emp.State,
                           CountryId = emp.CountryId
                       }).ToList();

            state.StateResponsedata = objState;
            return state;

          
        }
        public cityresponse GetCity(int id)
        {
            cityresponse city =new cityresponse();
            sdirectdbContext sd = new sdirectdbContext();
            var objState = (from emp in sd.CityTable12s
                            where emp.StateId == id
                            select new CityView
                            {
                                City=emp.City,
                                CityId=emp.CityId,
                                StateId=emp.StateId
                            }).ToList();
            city.GetCityViews= objState;
            return city;
        }



        public DeleteView DeleteEmployeRecord(int id)
        {
            sdirectdbContext sd=   new sdirectdbContext();
            DeleteView delete=new DeleteView();
            var obj=sd.EmployeTable12s.Where(h=>h.IsDeleted==false).FirstOrDefault(h=>h.EmpId==id);
            if (obj!=null)
            {
                obj.IsDeleted = true;
                obj.IsActive=false;
                sd.SaveChanges();
                delete.statuscode = 200;
                delete.message = "deleted";
                return delete;

            }
            else
            {
                delete.statuscode = 400;
                delete.message = "already deleted";
                return delete;
            }
        }
    }

}
