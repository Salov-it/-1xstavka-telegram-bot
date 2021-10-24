using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Music_mp3_bot
{
    class confingsql : Program
    {//работа с бд


        public void MysqlConnect(string FirstName, string UserName)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=salovv21.beget.tech;uid=salovv21_bot;" +
               "pwd=Syka_start123;database=salovv21_bot";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                //Пример отправки данных на сервер

                string sql = $"INSERT INTO user (first_name, username) VALUES ('{FirstName}','{UserName}')";
                //проверка записи на существования

                var checkUser = $"SELECT username FROM  user WHERE username = '{UserName}'";

                MySqlCommand cmd = new MySqlCommand(checkUser, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Console.WriteLine(result.ToString());
                    Console.WriteLine("Такой тип уже есть");
                }
                else
                {
                    MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                    cmd1.ExecuteNonQuery();
                }



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);


            }

        }
    }
}

