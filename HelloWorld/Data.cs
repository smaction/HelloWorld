using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class Data
    {
       private List<Horse> horses;
        public Data()
        {
            loadData();
        }
        private void loadData()
        {
            const string DATAFILE = "data.csv";
            
            using (var tr = new System.IO.StreamReader(DATAFILE))
            {
                using (var csv = new CsvHelper.CsvReader(tr, System.Globalization.CultureInfo.CurrentCulture))
                {
                    horses = csv.GetRecords<Horse>().ToList();
                }
            }
        }
        public List<Horse> GetHorses()
        {
            return horses;
        }

















    }
}
