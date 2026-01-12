class Applicant
{
    private string name;
    private int creditScore;   // encapsulated
    private double income;
    private double loanAmount;

    public Applicant(string name, int creditScore, double income, double loanAmount)
    {
        this.name = name;
        this.creditScore = creditScore;
        this.income = income;
        this.loanAmount = loanAmount;
    }

    public string Name
    {
        get { return name; }
    }

    public double Income
    {
        get { return income; }
    }

    public double LoanAmount
    {
        get { return loanAmount; }
    }

    // Internal access only
    public bool IsCreditEligible(int minScore)
    {
        return creditScore >= minScore;
    }
}
