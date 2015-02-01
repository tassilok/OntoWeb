using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OntoWeb;

namespace WpfOnt
{
    public static class WebServiceConnector
    {
        private static OntoWebSoapClient ontoWebSoapClient;
        public static OntoWebSoapClient OntologyWebSoapClient
        {
            get 
            {
                if (ontoWebSoapClient == null)
                {
                    ontoWebSoapClient = new OntoWebSoapClient();
                }
                return ontoWebSoapClient;
            }
            
        }

    }
}
