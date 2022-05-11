using System.Data.SqlClient;

SqlConnectionStringBuilder connString1Builder;
connString1Builder = new SqlConnectionStringBuilder();
connString1Builder.DataSource = "tcp:m3gdulejm4.database.windows.net,1433";
connString1Builder.InitialCatalog = "ReadyToLunch";
connString1Builder.Encrypt = true;
connString1Builder.TrustServerCertificate = false;
connString1Builder.UserID = "lipidfresh@m3gdulejm4";
connString1Builder.Password = "Diva4dog";

var test = connString1Builder.ToString();
Console.WriteLine();
Console.ReadLine();