using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearchNestConnector;
using OntologyClasses.DataClasses;

namespace ConnectorTester
{
    class Program
    {
        private static clsDBSelector objDBSelector;
        private static clsCopyIndex objCopyIndex;
        private static clsDataTypes objDataTypes = new clsDataTypes();

        static void Main(string[] args)
        {
            objDBSelector = new clsDBSelector("localhost", 9200, "ontology_db", "reports", 20000, new Guid().ToString());
            objCopyIndex = new clsCopyIndex(objDBSelector);
            objCopyIndex.ClearLists();
            //objCopyIndex.CopyIndex("ontodb", CopyItem.DataTypes | CopyItem.AttributeTypes | CopyItem.Classes | CopyItem.RelationTypes | CopyItem.Objects);
            //objCopyIndex.OList_DataTypes = objDataTypes.DataTypes;
            //objCopyIndex.CopyIndex("ontodb", CopyItem.Objects );
            //objCopyIndex.CopyIndex("ontodb", CopyItem.ClassAttributes);
            //objCopyIndex.CopyIndex("ontodb", CopyItem.AttributeTypes);
            //objCopyIndex.CopyIndex("ontodb", CopyItem.ObjectAttributes);
            objCopyIndex.CopyIndex("ontodb", CopyItem.ObjectRelations);
        }
    }
}
