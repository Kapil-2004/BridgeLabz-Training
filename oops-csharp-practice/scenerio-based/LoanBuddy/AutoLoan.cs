class AutoLoan : LoanApplication
{
    public AutoLoan(Applicant applicant, int term)
        : base(applicant, term, 10.5) { }

    public override bool ApproveLoan()
    {
        return applicant.IsCreditEligible(600) &&
               applicant.Income >= applicant.LoanAmount / 48;
    }

    public override double CalculateEMI()
    {
        return base.CalculateEMI() * 1.02; // processing adjustment
    }
}
