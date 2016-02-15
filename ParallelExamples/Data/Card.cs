using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class Card
    {
        public int ID { get; set; }
        public string name { get; set; }

        public Task build(string json)
        {
            //Func<string, bool> builder = buildFromJson;
            //Task.Run<bool>(buildFromJson);
            return Task.Run(new Func<bool>(buildFromJson));
            //return Task.Run(() => buildFromJson(json));
        }

        private bool buildFromJson()
        {
            throw new NotImplementedException();
        }

        public bool buildFromJson(string j)
        {
            return true;
        }
    }
}
