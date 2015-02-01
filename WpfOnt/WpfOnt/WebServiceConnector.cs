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
        private static OntoWeb.OntoWeb ontoWebSoapClient;
        public static OntoWeb.OntoWeb OntologyWebSoapClient
        {
            get 
            {
                if (ontoWebSoapClient == null)
                {
                    ontoWebSoapClient = new OntoWeb.OntoWeb();

                }
                return ontoWebSoapClient;
            }
            
        }

    }
}
