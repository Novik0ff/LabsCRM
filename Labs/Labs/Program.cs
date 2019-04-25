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

            string fetchString =
            @"<fetch mapping='logical'>
                <entity name='account'>
                <attribute name='accountid'/> <attribute name='name'/>
                    <link-entity name='systemuser' to='owninguser'> 
                        <filter type='and'> <condition attribute='lastname' operator='ne' value='Cannon' /> </filter>
                    </link-entity> 
                </entity>
            </fetch> ";

            foreach (var item in FetchXML.FetchXML.FethcXMLRequest(fetchString, service).Entities)
            {
                {
                    Console.WriteLine(item.Attributes["name"]);
                }
            }

            Console.Read();
        }
    }
}
