using System;
using System.ComponentModel;

class PhoneManager
{  
    public static void display(string []firstname , string []lastname ,string[] phone_num , string []city , string[] gender )
    {
        int i=0;
        while(firstname[i]!= null)
        {
            Console.WriteLine($"ID: {i+1}" );
            Console.WriteLine("First Name: " + firstname[i]);
            Console.WriteLine("Last Name: " + lastname[i]);
            Console.WriteLine("Phone Number: " + phone_num[i]);
            Console.WriteLine("City: " + city[i]);
            Console.WriteLine("Gender: " + gender[i]);
            i++;
        }
    }
    public static void Main(string[] args)
    {
        int loop = 1;
        string []firstname = new string[10];
        string []lastname = new string[10];
        string []phone_num = new string[10];
        string []city = new string[10];
        string []gender = new string[10];
        Console.WriteLine("\nWelcome to Phone Manager\n");

        while (loop==1)
        {
        
        display(firstname, lastname, phone_num, city, gender);
        Console.WriteLine("1. Add Contact \n2. Search ByName");
        int choice = int.Parse(Console.ReadLine());

        if(choice == 1)
        {
            int i = 0;
            while(i < firstname.Length && firstname[i] != null)
            {
                i++;
            }
            Console.WriteLine("Enter First Name: ");
            firstname[i] = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            lastname[i] = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            phone_num[i] = Console.ReadLine();
            Console.WriteLine("Enter City: ");
            city[i] = Console.ReadLine();
            Console.WriteLine("Enter Gender: ");
            gender[i]= Console.ReadLine();
        }

        else
        {
            Console.WriteLine("Write name to search");
            string searched_name = Console.ReadLine();

            for(int i=0 ; i<10 ; i++)
            {
                if(i < firstname.Length && firstname[i] != null && (firstname[i].Contains(searched_name) || lastname[i].Contains(searched_name)))
                {
                    Console.WriteLine($"ID: {i+1}");
                    Console.WriteLine("First Name: " + firstname[i]);
                    Console.WriteLine("Last Name: " + lastname[i]);
                    Console.WriteLine("Phone Number: " + phone_num[i]);
                    Console.WriteLine("City: " + city[i]);
                    Console.WriteLine("Gender: " + gender[i]);
                }
            }

            Console.WriteLine("1. delete_number \n2. update_number \n3. exit");
            int num = int.Parse(Console.ReadLine());

            if(num == 1)
            {
                display(firstname, lastname, phone_num, city, gender);
                Console.WriteLine("Enter id to delete:");
                int idtodelete = int.Parse(Console.ReadLine());
                firstname[idtodelete-1] = null;
                lastname [idtodelete-1] = null;
                phone_num[idtodelete-1] = null;
                gender [idtodelete-1] = null;
                city[idtodelete-1] = null;
            }

            else if (num ==2)
            {
                Console.WriteLine("Enter id to update:");
                int idtoupdate = int.Parse(Console.ReadLine());
                firstname[idtoupdate-1] = null;
                lastname [idtoupdate-1] = null;
                phone_num[idtoupdate-1] = null;
                gender [idtoupdate-1] = null;
                city[idtoupdate-1] = null;


                Console.WriteLine("Enter First Name: ");
                firstname[idtoupdate-1] = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                lastname[idtoupdate-1] = Console.ReadLine();
                Console.WriteLine("Enter Phone Number: ");
                phone_num[idtoupdate-1] = Console.ReadLine();
                Console.WriteLine("Enter City: ");
                city[idtoupdate-1] = Console.ReadLine();
                Console.WriteLine("Enter Gender: ");
                gender[idtoupdate-1]= Console.ReadLine();
            }
            else{
                break;
            }

        }
        Console.WriteLine("Press 0 to end  AND press 1 to continue");
        string input = Console.ReadLine();
        int end = int.Parse(input);
        if(end == 0) loop = 0;

        }

    }
}