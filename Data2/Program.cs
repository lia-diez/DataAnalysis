using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using MySql.Data.MySqlClient;


string connectionString = "server=localhost" +
                          ";user=root;" +
                          "database=data_analysis;" +
                          "password=Elanor2002;";
MySqlConnection connection = new MySqlConnection(connectionString);
connection.Open();


/*using (var reader = new StreamReader(File.Open("data.dat", FileMode.Open)))
{
    
}*/

var data = "";