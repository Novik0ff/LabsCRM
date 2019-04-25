using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Labs.FetchXML
{
    class FetchXML
    {
        public const string fetchString = @"<fetch mapping='logical'>
                <entity name='account'>
                <attribute name='accountid'/> <attribute name='name'/>
                    <link-entity name='systemuser' to='owninguser'> 
                        <filter type='and'> <condition attribute='lastname' operator='ne' value='Cannon' /> </filter>
                    </link-entity> 
                </entity>
            </fetch> ";
        public const string fetchXml =
            @"<fetch mapping='logical'>
                <entity name='contact'>
                <attribute name='fullname'/>
                    <filter type='and'>
                     <condition attribute='jobtitle' operator='eq' value='Purchasing Assistant'/>
                    </filter>
                </entity>
            </fetch>";
        public static EntityCollection FethcXMLRequest(string fetchXML, IOrganizationService organizationService)
        {
            try
            {
                return organizationService.RetrieveMultiple(new FetchExpression(fetchXML));
            }
            catch (Exception)
            {
                throw new ArgumentException($@"Bad fetchXML request");
            }
        }
    }
}
