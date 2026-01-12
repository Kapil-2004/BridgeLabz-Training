using System;

class Program
{
    static void Main()
    {
        Applicant applicant = new Applicant(
            "Rahul",
            700,
            60000,
            500000
        );

        LoanApplication loan = new HomeLoan(applicant, 240);

        Console.WriteLine("Applicant: " + applicant.Name);

        if (loan.ApproveLoan())
        {
            Console.WriteLine("Loan Approved!");
            Console.WriteLine("Monthly EMI: ₹" + loan.CalculateEMI());
        }
        else
        {
            Console.WriteLine("Loan Rejected.");
        }
    }
}
