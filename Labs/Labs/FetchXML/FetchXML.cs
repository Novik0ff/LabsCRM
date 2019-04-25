using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace Labs.FetchXML
{
    class FetchXML
    {
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
