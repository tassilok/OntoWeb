using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.DataClasses;

namespace ElasticSearchNestConnector
{
    public class clsUserAppDBDeletor
    {
        private clsUserAppDBSelector objUserAppDBSelector;

        private clsLogStates objLogStates = new clsLogStates();

        public clsUserAppDBDeletor(clsUserAppDBSelector userAppDBSelector)
        {
            objUserAppDBSelector = userAppDBSelector;
        }
    }
}
