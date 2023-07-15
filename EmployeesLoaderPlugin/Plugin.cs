using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp.Domain;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;

namespace EmployeesLoaderPlugin
{ 

  [Author(Name = "Ivan Petrov")]
  public class Plugin : IPluggable
  {
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
    {
      logger.Info("Loading employees");
       string json = EmployeesLoaderPlugin.Properties.Resources.EmployeesJson;
      
      var employeesData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
        List<EmployeesDTO> employeesList = args.Cast<EmployeesDTO>().ToList();

            foreach (var employeeData in employeesData)
{
    if (employeeData.TryGetValue("Name", out string name) &&
        employeeData.TryGetValue("Phone", out string phoneNumber))
    {
        var employee = new EmployeesDTO();
        employee.Name = name;
        employee.AddPhone(phoneNumber);
       
        employeesList.Add(employee);
    }
}

      logger.Info($"Loaded {employeesList.Count()} employees");
      return employeesList.Cast<DataTransferObject>();
    }
  }
}
