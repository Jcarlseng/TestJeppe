
using System.Data.SqlClient;
using System.Runtime.InteropServices;

internal class TestJeppe
{
    public static void Main(string[] args)
    {
        string choice = "check";
        Console.WriteLine("Do you want to insert, insert multiple or delete data?");

        while (choice != "insert" && choice != "delete" && choice != "insert multiple")
        {
            Console.Clear();
            Console.WriteLine("Do you want to insert, insert multiple or delete data?");
            choice = Console.ReadLine();
        }
        
        
        
        Butterfly butterfly = new Butterfly();

        if (choice == "insert") 
        {
            Console.WriteLine("Write your insert");
            butterfly.InsertDelete("insert", Console.ReadLine());
        }
        else if (choice == "insert multiple")
        {
            butterfly.TwoToFive();
        }
        else if (choice == "delete")
        {
            Console.WriteLine("Write what you want to delete");
            butterfly.InsertDelete("delete", Console.ReadLine());
        }
      
    }
}


public interface IButterfly
{
    public void InsertDelete(string choice, string data);
    public void TwoToFive();
}


public class Butterfly : Animal, IButterfly
{


    private readonly Random random = new Random();

    public void InsertDelete(string choice, string data)
    {
        string connectionString = "Data Source=LAPTOP-HL0TDAP9\\TEW_SQLEXPRESS;Initial Catalog=Butterdly_DB;Integrated Security=True";
              
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            string property = random.Next(2) == 0 ? "Ugly" : "Sweet";
            if (choice == "insert")
            {
                if (property == "Ugly")
                {
                    Console.WriteLine("Butterflies with 'Ugly' property cannot be inserted.");
                    return;
                }

                string insertQuery = $"INSERT INTO Table1 (Butterfly) VALUES (@Data)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Data", data);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Data inserted: " + data);
            }
            else if (choice == "delete")
            {
                
                string deleteQuery = $"DELETE FROM Table1 WHERE Butterfly = @Data";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Data", data);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Data deleted: " + data);
            }
            else
            {
                Console.WriteLine("Invalid choice: " + choice);
            }
        }
    }


    public void TwoToFive()
    {
        string connectionString = "Data Source=LAPTOP-HL0TDAP9\\TEW_SQLEXPRESS;Initial Catalog=Butterdly_DB;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string count = "0";
            while (count != "2" && count != "3" && count != "4" && count != "5")
            {
                Console.Clear();
                Console.WriteLine("Hvor mange navne hvil du skrive? (mindst 2 og max 5)");
                count = Console.ReadLine();

            }


            int queryCount = Convert.ToInt32(count);

            for (int i = 0; i < queryCount; i++)
            {
                Console.WriteLine("Skriv et navn");
                string insertQuery = $"INSERT INTO Table1 (Butterfly) VALUES ('{Console.ReadLine()}')";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"{queryCount} insert queries executed.");
        }
    }
}

public class Animal
{
   
}

 