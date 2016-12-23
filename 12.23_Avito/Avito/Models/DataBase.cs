using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Avito.Models
{
    public class DataBase
    {
        private string path = @"C:\Users\iljap\Documents\Projects\database.csv";
        public List<Record> records = new List<Record>();
        public void Add(Record r)
        {
            records.Add(r);
        }
        public void SaveChanges()
        {
            StreamWriter db = new StreamWriter(path, true);
            foreach(Record r in records)
            {
                string record =
                string.Format("{0};{1};{2};{3};{4};",
                r.Name, r.PhoneNumber, r.Address, r.Text, r.isCard);
                db.WriteLine(record);
            }
            db.Close();
        }

        public void Update()
        {
            records = new List<Record>();
            if (!File.Exists(path))
            {
                return;
            }
            
            StreamReader reader = new StreamReader(path);
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                string[] data = str.Split(';');
                records.Add(new Record
                {
                    Name = data[0],
                    PhoneNumber = long.Parse(data[1]),
                    Address = data[2],
                    Text = data[3],
                    isCard = bool.Parse(data[4])
                });
            }
            reader.Close();
        }
    }
}