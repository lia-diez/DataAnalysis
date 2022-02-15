using System.Globalization;
using System.Text;
using Data2.tree;


// string connectionString = "server=localhost" +
//                           ";user=root;" +
//                           "database=data_analysis;" +
//                           "password=Elanor2002;";
// MySqlConnection connection = new MySqlConnection(connectionString);
// connection.Open();


StringBuilder stringBuilder = new StringBuilder();
using (var reader = new StreamReader(File.Open("..\\..\\..\\PriceTable.lua", FileMode.Open)))
{
    char symb;
    do
    {
        symb = (char) reader.Read();
    } while (symb != '{');

    stringBuilder.Append('{');
    stringBuilder.Append(reader.ReadToEnd());
    stringBuilder.Remove(stringBuilder.Length - 3, 3);
}

string source = stringBuilder.ToString();
Tree tree = new Tree();

CultureInfo ci = (CultureInfo) CultureInfo.CurrentCulture.Clone();
ci.NumberFormat.CurrencyDecimalSeparator = ".";

for (int i = 0; i < source.Length; i++)
{
    switch (source[i])
    {
        case '[':
            if (source[i + 2] == 'A')
            {
                LeafNode leafNode = new LeafNode(tree.Head);
                int k = 0;
                do
                {
                    if (source[i] == '=')
                    {
                        stringBuilder.Clear();
                        do
                        {
                            i++;
                            stringBuilder.Append(source[i]);
                        } while (source[i + 1] != ',');

                        switch (k)
                        {
                            case 0:
                                leafNode.Avg = float.Parse(stringBuilder.ToString());
                                break;
                            case 1:
                                leafNode.Max = float.Parse(stringBuilder.ToString());
                                break;
                            case 2:
                                leafNode.Min = float.Parse(stringBuilder.ToString());
                                break;
                            case 3:
                                leafNode.EntryCount = int.Parse(stringBuilder.ToString());
                                break;
                            case 4:
                                leafNode.Amount = int.Parse(stringBuilder.ToString());
                                break;
                            case 5:
                                leafNode.SuggestedPrice = float.Parse(stringBuilder.ToString());
                                break;
                        }

                        k++;
                    }

                    i++;
                } while (source[i + 1] != '}');

                tree.NextLevel(leafNode);
            }
            else
            {
                stringBuilder.Clear();
                do
                {
                    i++;
                    stringBuilder.Append(source[i]);
                } while (source[i + 1] != ']');

                tree.NextLevel(new TreeNode(stringBuilder.ToString(), tree.Head));
            }

            break;

        case '}':
            tree.PreviousLevel();
            break;
    }
}

if (true) ;