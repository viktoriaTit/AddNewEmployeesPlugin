using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp.Domain;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;

namespace AddEmployeesPlugin
{
      [Author(Name = "Viktoria Titarenko")]
    public class Plugin : IPluggable
    {
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("Starting Add");

       List<EmployeesDTO> employeesList = new List<EmployeesDTO>();
            {  try
            {
               var json = File.ReadAllText("users.json");

               UsersJson users = JsonConvert.DeserializeObject<UsersJson>(json);
                    foreach (var user  in users.Data )
                    {
                        var name = user.FirstName + " " + user.MaidenName + " " + user.LastName;
                        var employee = new  EmployeesDTO();
                        employee.Name = name;
                        employee.AddPhone(user.Phone);
                        employeesList.Add(employee);
                    }
                }
                catch (Exception ex)
            {
               throw;
            }}
                

            
            return employeesList.Cast<DataTransferObject>();
        }
    }
    
}
