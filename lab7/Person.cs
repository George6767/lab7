﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Person
    {
        static SqlConnection connection;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }

        static Person()
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(strcon);
        }
        private static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
        }
        public static IEnumerable<Person> getAllPerson()
        {
            OpenConnection();
            var SQLstr = "SELECT * FROM Person";
            SqlCommand getAllCommand = new SqlCommand(SQLstr, connection);
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var sum = reader.GetDecimal(2);
                    var person = new Person() { Id = id, Name = name, Sum = sum };
                    yield return person;
                }
            }
            connection.Close();
        }
        public void Insert()
        {
            OpenConnection();
            var SQLstr = "INSERT INTO Person (Name, Sum) VALUES (@name, @sum)";
            SqlCommand insertCommand = new SqlCommand(SQLstr, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("name", Name),
                new SqlParameter("sum", Sum)
            });
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void Delete(int id)
        {
            OpenConnection();
            var commandString = "DELETE FROM Person WHERE(Id=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connection);
            deleteCommand.Parameters.AddWithValue("id", id);
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void Update()
        {
            OpenConnection();
            var commandString = "UPDATE Person SET Name=@name, Sum=@sum WHERE(Id=@id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {
                             new SqlParameter("name", Name),
                             new SqlParameter("sum", Sum),
                             new SqlParameter("id", Id),});
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static Person Find(string name)
        {
            foreach (var person in getAllPerson())
            {
                if (person.Name == name)
                    return person;
            }
            return null;
        }
        public override string ToString()
        {
            return $"№ {Id} Имя: {Name}, Сумма: {Sum:0.000}";
        }

        internal static IEnumerable<Person> getAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}