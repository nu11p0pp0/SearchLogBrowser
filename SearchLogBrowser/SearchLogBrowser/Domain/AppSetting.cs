using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLogBrowser.Domain
{
    class AppSetting
    {
        public List<SearchEngineItem> SearchEngineItems { get; set; }
        public String Id { get; set; }
        public AppSetting() {
            SearchEngineItems = JsonConvert.DeserializeObject<List<SearchEngineItem>>(ConfigurationManager.AppSettings["searchEngineList"]);
            Id = ConfigurationManager.AppSettings["id"];
        }
    }
}
