using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;


namespace HelloWorld
{
    public class Data
    {
       private List<Horse> horses;
        public Data()
        {
            loadDatabase();
        }
        private void loadDatabase()
        {
            
            const string CONNECTIONSTRING = @"Provider=sqloledb; Data Source=(local)\SQLExpress; Integrated Security=SSPI;  Initial Catalog=Handicap";
            horses = new List<Horse>();
            using (var connection = new OleDbConnection(CONNECTIONSTRING))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;     // indicates SQL text
                    command.CommandText = "SELECT horse, finish, start FROM Horses";

                    var dataset = new DataSet();
                    var dataAdapter = new OleDbDataAdapter(command);

                    dataAdapter.Fill(dataset);

                    for (var i = 0; i < dataset.Tables[0].Rows.Count; i++)
                    {
                        var row = dataset.Tables[0].Rows[i];
                        var horse = new Horse();
                        horse.name = row["horse"].ToString();
                        horse.finish = Convert.ToInt32(row["finish"]);
                        horse.start = Convert.ToInt32(row["start"]);

                        // add the horse to our in-memory List<>
                        horses.Add(horse);
                    }
                }
            }
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
