using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaZProg_1
{
    class Field
    {
        // This program take variable type and lenght of side of figure and calculate the filed of this figure according to the selected type of figure


        // Declarate of variable using global
        public double field,a,b,h,r;
        public string type;

        // This method allows to chose type betwee rectangle and triangle and call suitable method to calculate field
        public void Choose_Type()
        {
            Console.WriteLine("Enter type \"r\" for rectangle or type \"t\" for triangle or \"c\" for circle\n");
        TYPECHOOSE:
            Console.Write("Chose a type for calculations: ");
            type = Console.ReadLine();
            if (type == "r")
            {
                Console.Write("Enter a: ");
                a = double.Parse(Console.ReadLine().Replace('.', ','));
                Console.Write("Enter b: ");
                b = double.Parse(Console.ReadLine().Replace('.', ','));
                field = Process_for_Rectangle(a,b);
            }
            else if (type == "t")
            {
                Console.Write("Enter a: ");
                a = double.Parse(Console.ReadLine().Replace('.', ','));
                Console.Write("Enter h: ");
                h = double.Parse(Console.ReadLine().Replace('.', ','));
                field = Proces_for_Triangle(a,h);
            }
            else if (type == "c")
            {
                Console.Write("Enter r: ");
                r = double.Parse(Console.ReadLine().Replace('.', ','));
                field = Proces_for_Circle(r);
            }
            else
            {
                Console.WriteLine("Wrong type ! \nEnter type \"r\" for rectangle or type \"t\" for triangle or \"c\" for circle \n");
                goto TYPECHOOSE;       
            }
        }

        // Calculate field of Rectangle and Triangle
        public double Process_for_Rectangle(double a, double b)
        {
            double fieldRectangle = a * b;
            return fieldRectangle;
        }
        public double Proces_for_Triangle(double a, double h)
        {
            double fieldTriangle = (a * h) / 2;
            return fieldTriangle;
        }
        public double Proces_for_Circle(double r)
        {
            double fieldCircle= Math.PI * Math.Pow(r, 2);
            return fieldCircle;
        }

        // Shows result and ask for recalculations
        public void Show_result()
        {
            Console.WriteLine($"Field is: {field:#.##}");
            
            RECALCULATION:
            Console.WriteLine("Would You like to recalculations? (y/n)");
            string recalculationsChose = Console.ReadLine();
            if (recalculationsChose == "y")
            {
                Field field2 = new Field();
                field2.Choose_Type();
                field2.Show_result();
            }
            else if (recalculationsChose == "n") Console.WriteLine("Press any key to exit");
            else
            {
                Console.WriteLine("Chose \"y\" or \"n\" to continue");
                goto RECALCULATION;
            }
        }

        // Create new object in class and triggers suitable method
        static void Main(string[] args)
        {
            Field field1 = new Field();
            field1.Choose_Type();
            field1.Show_result();
            Console.ReadKey();
        }
    }
}
