using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionHandler.ExceptionHandler.AddUnhandledExceptionHandler();
            var service = Service.Service.GetOrganization();

            Console.WriteLine("===Organization===");

            var organization = ExecuteMethod.ExecuteMethod.GetAllAcctAttributes(new string[] { "name","owner" }, service).Entities;
            foreach (var item in organization)
            {
                Console.WriteLine(item.Attributes["name"]);
            }

            var users = ExecuteMethod.ExecuteMethod.GetAllUserAttributes(new string[] { "fullname" }, service).Entities;

            organization[0].Attributes["ownerid"] = new EntityReference(users[0].LogicalName, users[0].Id);

            service.Update(organization[0]);

            Console.WriteLine("===Users===");

            foreach (var item in users)
            {
                Console.WriteLine(item.Attributes["fullname"]);
            }
            Console.Read();
        }
    }
}
