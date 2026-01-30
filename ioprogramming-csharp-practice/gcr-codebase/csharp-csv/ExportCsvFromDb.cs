using System;
using System.Data.SqlClient;
using System.IO;

class ExportCsvFromDb
{
    static void Main()
    {
        string connectionString = @"Server=YOUR_SERVER_NAME;Database=YOUR_DB_NAME;Trusted_Connection=True;";
        string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";

        string filePath = "employee_report.csv";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Write CSV header
                sw.WriteLine("Employee ID,Name,Department,Salary");

                while (reader.Read())
                {
                    string id = reader["EmployeeID"].ToString();
                    string name = reader["Name"].ToString();
                    string dept = reader["Department"].ToString();
                    string salary = reader["Salary"].ToString();

                    sw.WriteLine($"{id},{name},{dept},{salary}");
                }
            }

            reader.Close();
        }

        Console.WriteLine("CSV report generated successfully.");
    }
}
