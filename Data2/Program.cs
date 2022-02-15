using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using MySql.Data.MySqlClient;


// string connectionString = "server=localhost" +
//                           ";user=root;" +
//                           "database=data_analysis;" +
//                           "password=Elanor2002;";
// MySqlConnection connection = new MySqlConnection(connectionString);
// connection.Open();
//
//
using (var reader = new StreamReader(File.Open("data.dat", FileMode.Open)))
{
    
}

var data = "";

string source =
    "{[\"Data\"]={[1]={[0]={[3]={[-1]={[\"2|6\"]={[\"Avg\"]=3,[\"Max\"]=3,[\"Min\"]=3,[\"EntryCount\"]=1,[\"AmountCount\"]=3,},[\"6|21\"]={[\"Avg\"]=30,[\"Max\"]=30,[\"Min\"]=30,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},[\"2|4|6\"]={[\"Avg\"]=4,[\"Max\"]=4,[\"Min\"]=4,[\"EntryCount\"]=1,[\"AmountCount\"]=200,},},},},},[2]={[1]={[37]={[10]={[4]={[\"Avg\"]=111,[\"Max\"]=111,[\"Min\"]=111,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},[36]={[13]={[4]={[\"Avg\"]=150,[\"Max\"]=150,[\"Min\"]=150,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},},[2]={[43]={[10]={[4]={[\"Avg\"]=126,[\"Max\"]=126,[\"Min\"]=126,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},[11]={[4]={[\"Avg\"]=126,[\"Max\"]=126,[\"Min\"]=126,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},[45]={[10]={[4]={[\"Avg\"]=129,[\"Max\"]=129,[\"Min\"]=129,[\"EntryCount\"]=2,[\"AmountCount\"]=2,},},},[41]={[10]={[4]={[\"Avg\"]=700,[\"Max\"]=700,[\"Min\"]=700,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},},[3]={[38]={[10]={[4]={[\"Avg\"]=1111,[\"Max\"]=1111,[\"Min\"]=1111,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},},},[4]={[1]={[15]={[-1]={[\"Avg\"]=5.8,[\"Max\"]=10,[\"Min\"]=4,[\"EntryCount\"]=20,[\"AmountCount\"]=1125,[\"SuggestedPrice\"]=3.75,},},},[0]={[15]={[-1]={[\"Avg\"]=3,[\"Max\"]=3,[\"Min\"]=3,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},},[6]={[1]={[16]={[-1]={[\"Avg\"]=67.5,[\"Max\"]=86,[\"Min\"]=49,[\"EntryCount\"]=2,[\"AmountCount\"]=2,},},},},[7]={[1]={[200]={[-1]={[\"Avg\"]=144.41,[\"Max\"]=1000,[\"Min\"]=20,[\"EntryCount\"]=228,[\"AmountCount\"]=228,[\"SuggestedPrice\"]=55.47,},},},[4]={[200]={[-1]={[\"Avg\"]=1972.17,[\"Max\"]=6000,[\"Min\"]=550,[\"EntryCount\"]=18,[\"AmountCount\"]=18,[\"SuggestedPrice\"]=495,},},},[3]={[200]={[-1]={[\"Avg\"]=1081.43,[\"Max\"]=1511,[\"Min\"]=400,[\"EntryCount\"]=7,[\"AmountCount\"]=7,},},},},[8]={[1]={[190]={[-1]={[\"Avg\"]=15,[\"Max\"]=15,[\"Min\"]=15,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},[170]={[6]={[\"Avg\"]=550,[\"Max\"]=600,[\"Min\"]=500,[\"EntryCount\"]=2,[\"AmountCount\"]=2,},[-1]={[\"Avg\"]=100,[\"Max\"]=100,[\"Min\"]=100,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},[2]={[160]={[0]={[\"Avg\"]=2680,[\"Max\"]=2680,[\"Min\"]=2680,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},[180]={[2]={[\"Avg\"]=141,[\"Max\"]=141,[\"Min\"]=141,[\"EntryCount\"]=1,[\"AmountCount\"]=1,},},},}";
StringBuilder stringBuilder = new StringBuilder();
int height = 0;
string otstup = "";

for (int i = 0; i < source.Length; i++)
{
    switch (source[i])
    {
        case '{':
            height++;
            Console.Write("\n*" + height + "*");
            // create child node
            // move to child node
            break;
        case '}':
            height--;
            Console.Write("\n*" + height + "*");
            break;
        case '[':
            stringBuilder.Clear();

            if (source[i + 2] == 'A')
            {
                do
                {
                    if (source[i] != '[' && source[i] != '"' && source[i] != ']')
                        stringBuilder.Append(source[i]);
                    i++;
                } while (source[i + 1] != '}');

                Console.Write(stringBuilder);
                break;
            }

            do
            {
                i++;
                stringBuilder.Append(source[i]);
            } while (source[i + 1] != ']');

            Console.Write(stringBuilder);
            break;
    }
}