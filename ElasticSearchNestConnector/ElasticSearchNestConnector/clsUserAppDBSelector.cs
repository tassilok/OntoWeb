using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Newtonsoft.Json.Linq;
using OntologyClasses.BaseClasses;

namespace ElasticSearchNestConnector
{
    public class clsUserAppDBSelector
    {

        private string strIndex;

        public string Server { get; private set; }
        public int Port { get; private set; }
        public string Index
        {
            get { return strIndex;  }
            set
            {
                if (strIndex != value)
                {
                    strIndex = value;
                    initialize_Client();    
                }
                
            }
        }
        public string App { get; private set; }
        public string ID_User { get; private set; }
        public int SearchRange { get; private set; }
        public string Session { get; private set; }
        public List<string> SpecialCharacters_Read { get; set; }

        public bool Paging { get; set; }
        public int LastPos { get; set; }
        public int PageCount { get; set; }
        public int CurPage { get; set; }
        public long Total { get; set; }


        public ElasticClient ElConnector { get; private set; }

        public List<KeyValuePair<string, string>> FilterItems { get; private set; }

        public clsUserAppDBSelector(string server,
                          int port,
                          string App,
                          string ID_user,
                          int searchRange,
                          string session)
        {
            this.Server = server;
            this.Port = port;
            this.ID_User = ID_user;
            this.App = App;
            this.SearchRange = searchRange;
            this.Session = session;
            this.Index = App + ID_User;


            SpecialCharacters_Read = new List<string> { "\\", "+", "-", "&&", "||", "!", "(", ")", "{", "}", "[", "]", "^", "\"", "~", "*", "?", ":" };
            //SpecialCharacters_Write = new List<string> { ":", "\"" };
            //SpecialCharacters_Read = new List<string> { " ", ":", "/", "\"" };


            LastPos = 0;

        }

        public clsUserAppDBSelector(string server,
                          int port,
                          string index,
                          int searchRange,
                          string session)
        {
            this.Server = server;
            this.Port = port;
            this.ID_User = null;
            this.App = null;
            this.SearchRange = searchRange;
            this.Session = session;
            this.Index = index;


            SpecialCharacters_Read = new List<string> { "\\", "+", "-", "&&", "||", "!", "(", ")", "{", "}", "[", "]", "^", "\"", "~", "*", "?", ":" };
            //SpecialCharacters_Write = new List<string> { ":", "\"" };




            LastPos = 0;

        }

        private void initialize_Client()
        {
            var uri = new Uri("http://" + Server + ":" + Port.ToString());

            var settings = new ConnectionSettings(uri).SetDefaultIndex(Index);
            ElConnector = new ElasticClient(settings);

            try
            {
                var indexSettings = new IndexSettings();
                ElConnector.CreateIndex(Index);

            }
            catch (Exception ex)
            {

                throw new Exception("Report index!");
            }
        }

        public List<string> GetData_Types(string strIndex = null)
        {
            
            var strTypes = new List<string>();
            var result = ElConnector.Search<dynamic>(s => s.Index(Index).Type("doctypes").QueryString("doctype:*").From(0).Size(1));
            //var result = ElConnector.Search(s => s.Index(Index).Type("doctypes").QueryString("doctype:*").From(0).Size(10000));
            if (result.Documents.Any())
            {
                strTypes.AddRange(result.Documents.Select(objType => objType["doctype"].ToString()).Cast<string>());
            }
           

            return strTypes;
        }

        private int AddKeyValue(KeyValuePair<string, string> keyValuePair)
        {
            var intIx = FilterItems.Count;

            FilterItems.Add(keyValuePair);

            return intIx;
        }

        public List<clsAppDocuments> GetData_Documents(string strIndex = null, string strType = null, bool paging = false, int lastPos = 0, string query = null)
        {
            LastPos = lastPos;
            Paging = paging;

            var Documents = new List<clsAppDocuments>();
            var intCount = SearchRange;
            var intPos = LastPos;


            while (intCount > 0)
            {
                intCount = 0;
                var type = strType ?? App ?? "*";
                var result = ElConnector.Search<dynamic>(s => s.Index(strIndex ?? Index).Type(type).QueryString(query ?? "*").From(intPos).Size(SearchRange));
                Total = result.Total;
                //var docs = new List<clsAppDocuments>();

                var docs = result.Hits.Select(h => new clsAppDocuments { Dict = new JObject(h.Source).ToObject<Dictionary<string, object>>(), Id = h.Id }).ToList();
                //var docs = result.Documents.Select(
                //    d =>  new clsAppDocuments { Dict = new JObject(d).ToObject<Dictionary<string, object>>(), Id = d["Id"] != null ? d["Id"].ToString() : null }).ToList();

                Documents.AddRange(docs);

                if (Paging)
                {
                    var pageCount = (double)result.Total / SearchRange;
                    PageCount = (int)Math.Ceiling(pageCount);
                    CurPage = LastPos / SearchRange;
                    LastPos += SearchRange;
                    break;
                }
            }

            return Documents;
        }
    }
}
