namespace TechVille.Modules
{
    /// <summary>
    /// Module 6: Citizen Class with Encapsulation
    /// Demonstrates: Classes, Objects, Private Attributes, Public Methods, Constructors
    /// </summary>
    public class Citizen
    {
        // ===== PRIVATE ATTRIBUTES (Encapsulation) =====
        private int id;
        private string name;
        private int age;
        private double income;
        private int residencyYears;
        private string registrationDate;

        // ===== CONSTRUCTORS =====
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Citizen()
        {
            this.id = 0;
            this.name = "";
            this.age = 0;
            this.income = 0;
            this.residencyYears = 0;
            this.registrationDate = DateTime.Now.ToString();
        }

        /// <summary>
        /// Parameterized Constructor
        /// Demonstrates: Constructor overloading
        /// </summary>
        public Citizen(int id, string name, int age, double income, int residencyYears)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.income = income;
            this.residencyYears = residencyYears;
            this.registrationDate = DateTime.Now.ToString();
        }

        // ===== PUBLIC PROPERTIES (Getters & Setters) =====

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        public int ResidencyYears
        {
            get { return residencyYears; }
            set { residencyYears = value; }
        }

        public string RegistrationDate
        {
            get { return registrationDate; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Display citizen information
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"\n--- Citizen Information ---");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Income: ₹{income:F2}");
            Console.WriteLine($"Residency Years: {residencyYears}");
            Console.WriteLine($"Registered: {registrationDate}");
        }

        /// <summary>
        /// Check if citizen is eligible for senior benefits
        /// </summary>
        public bool IsEligibleForSeniorBenefits()
        {
            return age >= 60;
        }

        /// <summary>
        /// Check if citizen is eligible for low-income support
        /// </summary>
        public bool IsEligibleForLowIncomeSupport()
        {
            return income < 25000;
        }

        /// <summary>
        /// Check if citizen is eligible for vote
        /// </summary>
        public bool IsEligibleToVote()
        {
            return age >= 18;
        }

        public override string ToString()
        {
            return $"{name} (ID: {id}, Age: {age}, Income: ₹{income})";
        }
    }
}
