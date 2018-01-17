using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    public class Student
    {
        public string Surname, name;
        public double gpa;
        public int age;
        public int height;

        public Student()
        {
            Surname = "Tagayev";
            name = "Ilyas";
            age = 17;
            height = 175;
            gpa = 3.31d;
        }
        public Student(string Surname, string name, int age, int height, double gpa)
        {
            this.Surname = Surname;
            this.name = name;
            this.age = age;
            this.height = height;
            this.gpa = gpa;
        }
        public static void getgpa(double gpa)
        {
            Console.WriteLine(gpa);
        }

        public override string ToString()
        {
            return Surname + ' ' + name + ' ' + age + ' ' + height + ' ' + gpa;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            string Surname, name;
            int age, height;
            double gpa;
            Surname = Console.ReadLine();
            name = Console.ReadLine();
            age = int.Parse(Console.ReadLine());
            height = int.Parse(Console.ReadLine());
            gpa = double.Parse(Console.ReadLine());
           
            Student a = new Student(Surname, name, age, height, gpa);
            Student.getgpa(a.gpa);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}

