
using System.Data;
using System.Data.SqlClient;
using YTRKDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");


//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "LAPTOP-1PC0MA3L\\MSSQLSERVER2022"; // server Name
//stringBuilder.InitialCatalog = "DotNetTraningBatch4";  //db name
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString); // bellow code and this code are same
//// SqlConnection connection = new SqlConnection("Data Source=LAPTOP-1PC0MA3L\\MSSQLSERVER2022;Initial Catalog=DotNetTraningBatch4;User ID=sa;Password=sa@123");
//connection.Open();
//Console.WriteLine("Connection Open");

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);


//connection.Close();
//Console.WriteLine("Connection Close");

//// run ပီးတဲ့အချိန်မှာ dt ထဲကို fill ပီးသားမို့ connection close ပီးမှအေးဆေးခေါ်လဲရတယ် 

//// dataset ဆို တာက datatable တစ်ခုထပ်ပိုပီးသိမ်းလို့ရတယ်
//// datatable မှာ datarow တွေ အများကြီးရှိပါတယ်
//// datarow အောက်မှာ column တွေရှိမယ် 

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog ID => " + dr["BlogId"]);
//    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Authour => " + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//    Console.WriteLine("--------------------------------------");
//}

//ADO.net CRUD

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(1, "adfad", "sgg", "deeaf");
//adoDotNetExample.Delete(1);
adoDotNetExample.Edit(2);

Console.ReadKey();
