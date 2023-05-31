using IdentityTable.Auth;
using IdentityTable.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class AngularCrudController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public AngularCrudController(ApplicationDbContext context)
        {
            _Db = context;
        }
        [HttpGet]
        [Route("GetEmpData")]
        public Response GetAll()
        {
            Response res = new Response();
            try
            {
                var data = _Db.Employees.Where(x => x.IActive == true).ToList();
                if (data.Count!= 0)
                { res.Data = data; res.Status = true; }
                else
                {
                    res.Data = "data not found";
                    res.Status = true;
                }
                //return Ok(data);
                return res;

            }
            catch (Exception ee)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmpDataById")]
        public Response GetDataById(int id)
        {
            Response res = new Response();
            try
            {
                var data = _Db.Employees.Where(x => x.IActive == true && x.EmployeeID==id).FirstOrDefault();
                if (data != null)
                { res.Data = data; res.Status = true; }
                else
                {
                    res.Data = "data not found";
                    res.Status = true;
                }
                return res;

            }
            catch (Exception ee)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("RegisterEmp")]
        public Response SaveData(AnUserRegister model)
        {
            model.IActive = true;
            Response res = new Response();
            _Db.Employees.Add(model);
            _Db.SaveChanges();
            res.Status = true;
            res.Message = "Data Saved";
            return res;
        }
        [HttpDelete]
        [Route("DeleteData")]
        public Response DeleteData(int id)
        {
            Response res = new Response();
            AnUserRegister data = _Db.Employees.Where(x => x.EmployeeID == id && x.IActive==true).FirstOrDefault();
            if(data!=null)
            {
                data.IActive = false;
                _Db.Employees.Update(data);
                _Db.SaveChanges();
                res.Status = true;
                res.Message = "Data Deleted";
                res.Data = data;
            }
            else
            {
                res.Status = true;
                res.Message = "User Not Exist";
            }
            return res;
        }

        [HttpPost]
        [Route("UpdateData")]
        public Response Update(AnUserRegister model)
        {
            Response res = new Response();
            try
            {
                var data = _Db.Employees.Where(x => x.EmployeeID == model.EmployeeID).FirstOrDefault();
                if(data!=null)
                {
                    data.EmployeeID = model.EmployeeID;
                    data.EmployeeName = model.EmployeeName;
                    data.Address = model.Address;
                    data.City = model.City;
                    data.Country = model.Country;
                    data.Department = model.Department;
                    data.EmailId = model.EmailId;
                    data.Password = model.Password;
                    data.PhoneNumber = model.PhoneNumber;
                    data.State = model.State;
                    _Db.Employees.Update(data);
                    _Db.SaveChanges();
                    res.Message = "Updated Successfully";
                    res.Status = true;
                    res.Data = data;
                }
                else
                {
                    res.Message = "User Not Exist";
                    res.Status = false;
                    
                }
                return res;
            }
            catch(Exception ex)
            {
                res.Message = ex.ToString();
                res.Status = false;
                return res;
            }
        }
    }
}
