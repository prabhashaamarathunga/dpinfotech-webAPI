using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMPWebAPI.Models;

namespace EMPWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
                           select Code, Initials, Firstname, Surname, EmpAddress, convert(varchar(10), DOB, 120) as DOB, EmpStatus from 
                           EmpDetails";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                           Insert into EmpDetails Values ('"+ employee.Code +"','"+employee.Initials+ "','"+employee.Firstname+ "','"+employee.Surname+ "','"+employee.EmpAddress+ "','"+employee.DOB+ "','"+employee.EmpStatus+"')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {


                return "Add Failed";
            }
        }

        public string Put(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            Update EmpDetails set Initials='"+employee.Initials+"', Firstname='"+employee.Firstname+"',Surname='"+employee.Surname+"', EmpAddress='"+employee.EmpAddress+ "', DOB='" + employee.DOB + "', EmpStatus='"+employee.EmpStatus+"' where Code='" + employee.Code + "' ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {


                return "Update Failed";
            }
        }

        public string Delete(string id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"
                            delete from EmpDetails where Code ='"+id+"' ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {


                return "Delete Failed";
            }
        }

    }
}
