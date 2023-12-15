using LemonDotNetCore.ConsoleApp.AdoDotNetExamples;
using LemonDotNetCore.ConsoleApp.DapperPractice;
using System.Data;
using System.Data.SqlClient;

//console.writeline("hello, world!");

////sqlconnectionstringbuilder sqlconnectionstringbuilder = new sqlconnectionstringbuilder();
////sqlconnectionstringbuilde.datasource = ".";
////sqlconnectionstringbuilder.initialcatalog = "lemondotnetcore";
////sqlconnectionstringbuilder.userid = "sa";
////sqlconnectionstringbuilder.password = "sasasu";

//sqlconnectionstringbuilder sqlconnectionstringbuilder = new sqlconnectionstringbuilder()
//{
//    datasource = ".",
//    initialcatalog = "lemondotnetcore",
//    userid = "sa", 
//    password = "sasasu"
//};
//sqlconnection connection = new sqlconnection(sqlconnectionstringbuilder.connectionstring);

//connection.open();
//console.writeline("connection is opened");

//string query = @"select [blog_id]
//      ,[blog_title]
//      ,[blog_author]
//      ,[blog_content]
//  from [dbo].[tbl_blog]";

//sqlcommand command = new sqlcommand(query, connection);
//sqldataadapter sqldataadapter = new sqldataadapter(command);
//datatable dt = new datatable();
//sqldataadapter.fill(dt);

//connection.close();
//console.writeline("connection is closed");

//foreach (datarow dr in dt.rows)
//{
//    console.writeline("id => " + dr["blog_id"]);
//    console.writeline($"title => {dr["blog_title"]}");
//    console.writeline("author => " + dr["blog_author"]);
//    console.writeline("content => " + dr["blog_content"]);
//}

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Run();

DapperPractices deper = new DapperPractices();
deper.Run();

Console.ReadKey();