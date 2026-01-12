class HomeLoan : LoanApplication
{
    public HomeLoan(Applicant applicant, int term)
        : base(applicant, term, 8.5) { }

    public override bool ApproveLoan()
    {
        return applicant.IsCreditEligible(650) &&
               applicant.Income >= applicant.LoanAmount / 60;
    }

    public override double CalculateEMI()
    {
        return base.CalculateEMI(); // lower interest already applied
    }
}
