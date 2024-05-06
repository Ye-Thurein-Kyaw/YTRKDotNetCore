﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YTRKDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query,params AdoDotNetParameter[]? parameters) 
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0 ) 
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Name, item.Value);
                }

                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt); // C# to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //json to C#
            return lst;

            // ရလာတဲ့ dataTable ကို list object ပြောင်းချင်ရင် Newtonsoft.Json ဆိုတဲ့ package အရင် သွင်းရတယ် ပီးတော့ json ပြောင်းပီးတော့ လုပ်လို့ရတယ် 

        }

        public T? QueryFirstOrDefalut<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach (var item in parameters)
                //{
                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}

                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());

                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt); // C# to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //json to C#
            if (dt.Rows.Count == 0)
            {
                return default;
            }
            return lst[0];

        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            return result;
        }
    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter() { }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
