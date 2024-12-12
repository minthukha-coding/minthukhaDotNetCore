using minthukhaDotNetCore.ConsoleApp.AdoDotNetExamples;
using minthukhaDotNetCore.ConsoleApp.DapperPractice;
using minthukhaDotNetCore.ConsoleApp.EFCoreExamples;
using minthukhaDotNetCore.ConsoleApp.HttpClientExamples;
using minthukhaDotNetCore.ConsoleApp.RestClientExamples;
using Serilog;
using Serilog.Sinks.MSSqlServer;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true)
    .WriteTo
    .MSSqlServer(
        connectionString: "Server=.;Database=LemonDotNetCore; User ID = sa;Password = sasa@123;TrustServerCertificate = true",
        sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_Log", AutoCreateSqlTable = true })
    .CreateLogger();

try
{
    // Your program here...
    const string name = "Serilog";
    Log.Information("Hello, {Name}!", name);
    throw new InvalidOperationException("Oops...");
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled exception");
}
finally
{
    await Log.CloseAndFlushAsync(); // ensure all logs written before app exits
}


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

//DapperPractices deper = new DapperPractices();
//deper.Run();

//EFCoreExample efcor = new EFCoreExample();
//efcor.Run();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read(1, 7);
//adoDotNetExample.Read(5, 7);

Console.ReadKey();