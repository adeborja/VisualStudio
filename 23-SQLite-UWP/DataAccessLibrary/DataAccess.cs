using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public static void inicializarBaseDatos()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=SQLitePrueba.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddDatos(string inputText)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=SQLitePrueba.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();

                insertCommand.Connection = db;

                //Usar sentencia preparada para evitar ataques de inyeccion SQL
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static List<String> getDatos()
        {
            List<String> textos = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=SQLitePrueba.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry FROM MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while(query.Read())
                {
                    textos.Add(query.GetString(0));
                }

                db.Close();
            }

                return textos;
        }
    }
}
