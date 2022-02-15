using System.Text.RegularExpressions;
using DataAnalysis;
using MySql.Data.MySqlClient;

var itemRecords = new List<ItemRecord>();

string connectionString = "server=localhost" +
                          ";user=root;" +
                          "database=data_analysis;" +
                          "password=Elanor2002;";
MySqlConnection connection = new MySqlConnection(connectionString);
connection.Open();


using (var reader = new StreamReader(File.Open("data.dat", FileMode.Open)))
{
    var data = reader.ReadToEnd();
    var recordRegex = new Regex("\\[.+?}", RegexOptions.Compiled);
    var textRegex = new Regex("\".+\"");
    var numberRegex = new Regex("\\d+");
    foreach (Match match in recordRegex.Matches(data))
    {
        var name = textRegex.Match(match.Value).Value.Trim('"');
        var temp = numberRegex.Matches(match.Value);
        var field1 = int.Parse(temp[0].Value);
        var field2 = int.Parse(temp[1].Value);
        itemRecords.Add(new ItemRecord(name, field1, field2));
    }
}

foreach (var record in itemRecords)
{
    var sql = $"INSERT INTO items (name, field1, field2) VALUES (\"{record.Name}\", {record.Field1}, {record.Field2})";
    var command = new MySqlCommand(sql, connection);
    command.ExecuteNonQuery();
}