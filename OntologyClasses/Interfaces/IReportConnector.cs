using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.Interfaces
{
    interface IReportConnector
    {
        clsOntologyItem NewRow();

        clsOntologyItem Get_OItem_Module();
    }
}
