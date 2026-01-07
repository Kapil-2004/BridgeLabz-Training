public class Employee
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public bool IsPresent { get; set; }

    public Employee(int empId, string name)
    {
        EmpId = empId;
        Name = name;
        IsPresent = false;
    }
}
