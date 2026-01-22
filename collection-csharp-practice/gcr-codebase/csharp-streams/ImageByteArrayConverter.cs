using System;
using System.IO;

class ImageByteArrayConverter
{
    static void Main()
    {
        string sourceImagePath = "sourceImage.jpg";       // Put your image here
        string destinationImagePath = "copiedImage.jpg";

        try
        {
            // Check if source image exists
            if (!File.Exists(sourceImagePath))
            {
                Console.WriteLine("Source image file does not exist: " + sourceImagePath);
                return;
            }

            // --------- Read Image into Byte Array using MemoryStream ---------
            byte[] imageBytes;

            using (FileStream fs = new FileStream(sourceImagePath, FileMode.Open, FileAccess.Read))
            using (MemoryStream ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                imageBytes = ms.ToArray();
            }

            Console.WriteLine("Image successfully converted to byte array.");
            Console.WriteLine("Byte array size: " + imageBytes.Length + " bytes");

            // --------- Write Byte Array back to Image File ---------
            using (FileStream fs = new FileStream(destinationImagePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(imageBytes, 0, imageBytes.Length);
            }

            Console.WriteLine("Byte array successfully written back to image file.");
            Console.WriteLine("New image created: " + destinationImagePath);

            // --------- Verify Both Files are Identical ---------
            bool isIdentical = CompareFiles(sourceImagePath, destinationImagePath);

            Console.WriteLine();
            if (isIdentical)
            {
                Console.WriteLine("Verification Successful: The new image is identical to the original.");
            }
            else
            {
                Console.WriteLine("Verification Failed: The new image is NOT identical to the original.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred:");
            Console.WriteLine(ex.Message);
        }
    }

    // Compare two files byte by byte
    static bool CompareFiles(string filePath1, string filePath2)
    {
        FileInfo fileInfo1 = new FileInfo(filePath1);
        FileInfo fileInfo2 = new FileInfo(filePath2);

        // If file sizes differ, files are not identical
        if (fileInfo1.Length != fileInfo2.Length)
            return false;

        const int bufferSize = 4096;
        byte[] buffer1 = new byte[bufferSize];
        byte[] buffer2 = new byte[bufferSize];

        using (FileStream fs1 = new FileStream(filePath1, FileMode.Open, FileAccess.Read))
        using (FileStream fs2 = new FileStream(filePath2, FileMode.Open, FileAccess.Read))
        {
            int bytesRead1;
            int bytesRead2;

            while ((bytesRead1 = fs1.Read(buffer1, 0, buffer1.Length)) > 0)
            {
                bytesRead2 = fs2.Read(buffer2, 0, buffer2.Length);

                if (bytesRead1 != bytesRead2)
                    return false;

                for (int i = 0; i < bytesRead1; i++)
                {
                    if (buffer1[i] != buffer2[i])
                        return false;
                }
            }
        }

        return true;
    }
}
