using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;


namespace Labs.ExecuteMethod
{
    public class ExecuteMethod
    {
        public static EntityCollection GetAllAcctAttributes(string[] attributes, IOrganizationService service)
        {
            try
            {
                ColumnSet cs = new ColumnSet(true);
                QueryExpression qe = new QueryExpression("account")
                {
                    ColumnSet = cs
                };
                RetrieveMultipleRequest rmr = new RetrieveMultipleRequest
                {
                    Query = qe
                };
                RetrieveMultipleResponse rResponse =
                (RetrieveMultipleResponse)service.Execute(rmr);
                return rResponse.EntityCollection;
            }
            catch (Exception)
            {
                throw new ArgumentException($@"GetAllAcctAttributes fail");
            }
        }
        public static EntityCollection GetAllUserAttributes(string[] attributes,
            IOrganizationService service)
        {
            try
            {
                ColumnSet cs = new ColumnSet(attributes);

                ConditionExpression ce = new
                ConditionExpression("isdisabled", ConditionOperator.Equal,
                new object[] { false });

                ConditionExpression excluded = new 
                ConditionExpression("fullname", ConditionOperator.NotIn,
                new object[] { false });

                FilterExpression fe = new FilterExpression(LogicalOperator.And);
                fe.AddCondition(ce);
                fe.AddCondition(excluded);
                QueryExpression qe = new QueryExpression("systemuser")
                {
                    ColumnSet = cs,
                    Criteria = fe
                };
                RetrieveMultipleRequest rmr = new RetrieveMultipleRequest
                {
                    Query = qe
                };
                RetrieveMultipleResponse rResponse =
                (RetrieveMultipleResponse)service.Execute(rmr);
                return rResponse.EntityCollection;
            }
            catch (Exception)
            {
                throw new ArgumentException($@"GetAllUserAttributes fail");
            }
        }
    }
}
