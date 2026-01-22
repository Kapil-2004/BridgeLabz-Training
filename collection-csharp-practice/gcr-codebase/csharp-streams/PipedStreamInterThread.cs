using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class PipedStreamInterThread
{
    static void Main()
    {
        try
        {
            // Create a pipe server stream for writing
            using (AnonymousPipeServerStream pipeServer =
                   new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                // Pass the client handle to the reader thread
                string clientHandle = pipeServer.GetClientHandleAsString();

                Thread writerThread = new Thread(() => Writer(pipeServer));
                Thread readerThread = new Thread(() => Reader(clientHandle));

                writerThread.Start();
                readerThread.Start();

                writerThread.Join();
                readerThread.Join();

                pipeServer.DisposeLocalCopyOfClientHandle();
            }

            Console.WriteLine("\nInter-thread communication completed.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred in main:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred in main:");
            Console.WriteLine(ex.Message);
        }
    }

    // Writer thread method
    static void Writer(AnonymousPipeServerStream pipeServer)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(pipeServer, Encoding.UTF8))
            {
                writer.AutoFlush = true;

                for (int i = 1; i <= 5; i++)
                {
                    string message = "Message " + i + " from Writer Thread";
                    Console.WriteLine("[Writer] Sending: " + message);

                    writer.WriteLine(message);

                    // Simulate processing delay
                    Thread.Sleep(500);
                }

                Console.WriteLine("[Writer] Finished sending data.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("[Writer] I/O error:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Writer] Unexpected error:");
            Console.WriteLine(ex.Message);
        }
    }

    // Reader thread method
    static void Reader(string clientHandle)
    {
        try
        {
            using (AnonymousPipeClientStream pipeClient =
                   new AnonymousPipeClientStream(PipeDirection.In, clientHandle))
            using (StreamReader reader = new StreamReader(pipeClient, Encoding.UTF8))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("    [Reader] Received: " + line);
                }

                Console.WriteLine("    [Reader] No more data to read.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("    [Reader] I/O error:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("    [Reader] Unexpected error:");
            Console.WriteLine(ex.Message);
        }
    }
}
