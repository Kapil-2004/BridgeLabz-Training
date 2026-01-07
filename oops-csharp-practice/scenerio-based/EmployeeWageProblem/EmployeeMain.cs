public class EmployeeMain
{
    public static void Start()
    {
        IEmployee emp = new EmployeeUtilityImpl();
        EmployeeMenu.ShowMenu(emp);
    }
}
