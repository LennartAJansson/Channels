using System.Text.Json;

using ImportBarometer;

using MySql.Data.MySqlClient;

using Z.Dapper.Plus;

JsonSerializerOptions options = new();
options.Converters.Add(new DateTimeConverterUsingDateTimeParse());

string connectionString = "Server=mysql.ubk3s;Port=3307;Database=barometerservicedb;User=root;Password=password;";
using MySqlConnection connection = new(connectionString);

string json = File.ReadAllText("H:\\AzureDevops\\Kubernetes\\BarometerData2.json");
IEnumerable<Measures> measures = JsonSerializer.Deserialize<IEnumerable<Measures>>(json, options);

connection.BulkInsert<Measures>(measures);
