using System;

namespace AmbulanceRoute
{
    public class AmbulanceRouteUtility : IAmbulanceRoute
    {
        private CustomCircularLinkedList units;

        public AmbulanceRouteUtility()
        {
            units = new CustomCircularLinkedList();
            LoadUnits();
        }

        private void LoadUnits()
        {
            units.Add(new HospitalUnit("Emergency", true));
            units.Add(new HospitalUnit("Radiology", false));
            units.Add(new HospitalUnit("Surgery", true));
            units.Add(new HospitalUnit("ICU", false));
        }

        public void AddUnit()
        {
            Console.Write("Enter unit name: ");
            string name = Console.ReadLine();

            Console.Write("Is unit available? (true/false): ");
            bool available = bool.Parse(Console.ReadLine());

            units.Add(new HospitalUnit(name, available));
            Console.WriteLine("Unit added.");
        }

        public void RemoveUnit()
        {
            Console.Write("Enter unit name to remove: ");
            string name = Console.ReadLine();

            units.Remove(name);
        }

        public void RedirectPatient()
        {
            HospitalUnit unit = units.FindNextAvailable();

            if (unit == null)
            {
                Console.WriteLine("No available units. Please wait.");
                return;
            }

            Console.WriteLine("Patient redirected to: " + unit.Name);

            units.Rotate();
        }

        public void ShowUnits()
        {
            units.Display();
        }
    }
}
