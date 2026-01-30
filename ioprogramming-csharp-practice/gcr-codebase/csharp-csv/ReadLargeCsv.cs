using System;
using System.IO;

class ReadLargeCsv
{
    static void Main()
    {
        int totalCount = 0;
        int batchCount = 0;

        using (StreamReader reader = new StreamReader("largefile.csv"))
        {
            reader.ReadLine(); // skip header

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                batchCount++;
                totalCount++;

                // Process line here (if needed)

                if (batchCount == 100)
                {
                    Console.WriteLine("Processed records: " + totalCount);
                    batchCount = 0; // reset batch
                }
            }

            // Print remaining records if less than 100
            if (batchCount > 0)
            {
                Console.WriteLine("Processed records: " + totalCount);
            }
        }
    }
}
