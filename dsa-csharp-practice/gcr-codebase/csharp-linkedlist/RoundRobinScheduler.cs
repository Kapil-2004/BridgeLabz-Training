using System;

class ProcessNode
{
    public int pid;
    public int burst;
    public int remaining;
    public int priority;
    public int waiting;
    public int turnaround;
    public ProcessNode next;

    public ProcessNode(int pid, int burst, int priority)
    {
        this.pid = pid;
        this.burst = burst;
        this.remaining = burst;
        this.priority = priority;
        waiting = 0;
        turnaround = 0;
        next = null;
    }
}

class RoundRobinScheduler
{
    private ProcessNode head;

    // Add process at end
    public void AddProcess(int pid, int burst, int priority)
    {
        ProcessNode newNode = new ProcessNode(pid, burst, priority);

        if (head == null)
        {
            head = newNode;
            newNode.next = head;
            return;
        }

        ProcessNode temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = newNode;
        newNode.next = head;
    }

    // Display processes
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in queue.");
            return;
        }

        ProcessNode temp = head;
        do
        {
            Console.WriteLine($"PID: {temp.pid}, Remaining: {temp.remaining}");
            temp = temp.next;
        } while (temp != head);
    }

    // Round Robin Scheduling
    public void Schedule(int timeQuantum)
    {
        if (head == null)
            return;

        int time = 0;
        int completed = 0;
        int totalProcesses = CountProcesses();

        ProcessNode curr = head;

        while (completed < totalProcesses)
        {
            if (curr.remaining > 0)
            {
                Console.WriteLine($"\nExecuting Process {curr.pid}");

                int execTime = Math.Min(timeQuantum, curr.remaining);
                curr.remaining -= execTime;
                time += execTime;

                // Update waiting time for others
                UpdateWaiting(curr, execTime);

                if (curr.remaining == 0)
                {
                    curr.turnaround = time;
                    completed++;
                    Console.WriteLine($"Process {curr.pid} completed.");
                }

                DisplayProcesses();
            }

            curr = curr.next;
        }

        CalculateAverageTimes();
    }

    private void UpdateWaiting(ProcessNode running, int execTime)
    {
        ProcessNode temp = head;
        do
        {
            if (temp != running && temp.remaining > 0)
                temp.waiting += execTime;

            temp = temp.next;
        } while (temp != head);
    }

    private int CountProcesses()
    {
        int count = 0;
        ProcessNode temp = head;
        do
        {
            count++;
            temp = temp.next;
        } while (temp != head);
        return count;
    }

    private void CalculateAverageTimes()
    {
        double totalWT = 0, totalTAT = 0;
        ProcessNode temp = head;

        Console.WriteLine("\n--- Final Process Details ---");
        do
        {
            totalWT += temp.waiting;
            totalTAT += temp.turnaround;

            Console.WriteLine(
                $"PID: {temp.pid}, Waiting Time: {temp.waiting}, Turnaround Time: {temp.turnaround}");

            temp = temp.next;
        } while (temp != head);

        int n = CountProcesses();
        Console.WriteLine($"\nAverage Waiting Time: {totalWT / n}");
        Console.WriteLine($"Average Turnaround Time: {totalTAT / n}");
    }
}

class Program
{
    static void Main()
    {
        RoundRobinScheduler rr = new RoundRobinScheduler();
        int choice;

        Console.Write("Enter Time Quantum: ");
        int tq = int.Parse(Console.ReadLine());

        do
        {
            Console.WriteLine("\n--- Round Robin Scheduler ---");
            Console.WriteLine("1. Add Process");
            Console.WriteLine("2. Start Scheduling");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            int pid, burst, priority;

            switch (choice)
            {
                case 1:
                    Console.Write("Process ID: ");
                    pid = int.Parse(Console.ReadLine());
                    Console.Write("Burst Time: ");
                    burst = int.Parse(Console.ReadLine());
                    Console.Write("Priority: ");
                    priority = int.Parse(Console.ReadLine());
                    rr.AddProcess(pid, burst, priority);
                    break;

                case 2:
                    rr.Schedule(tq);
                    break;
            }

        } while (choice != 0);
    }
}
