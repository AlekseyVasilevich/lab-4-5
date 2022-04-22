using System;
using System.Data;

namespace Tournament
{
    class Person
    {
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public Person(string personName, string personSurname)
        {
            PersonName = personName;
            PersonSurname = personSurname;
        }
        public Person()
        {
            PersonName = "Ivan";
            PersonSurname = "Ivanov";
        }
        public virtual DataTable DisplayInfo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Surname", typeof(string));
            table.Rows.Add(PersonName, PersonSurname);
            return table;
        }
    }
}
