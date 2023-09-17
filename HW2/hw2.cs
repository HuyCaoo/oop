using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Person
    {
        private string name { get; set; }
        private string address { get; set; }
        private double salary { get; set; }
        private List<Person> list = new List<Person>();
        public  void  InputPersonInfo()
        {
            
            Console.WriteLine("Nhập số lượng sinh viên:");
            int soluong = int.Parse(Console.ReadLine());
            for (int i = 0; i <soluong; i++)
            {
                Person person = new Person();
                Console.Write("Nhập tên:");
                person.name = Console.ReadLine();
                Console.Write("Nhập địa chỉ:");
                person.address = Console.ReadLine();
                do
                {
                    Console.Write("Nhập lương: ");
                    person.salary = double.Parse(Console.ReadLine());

                    if (person.salary <= 0)
                    {
                        Console.WriteLine("Lương không hợp lệ, vui lòng nhập lại!");
                    }
                } while (person.salary <= 0);
                list.Add(person);    
            }



        }
        public void DisplayPersonInfo()
        {
            list.Sort((x, y) => x.salary.CompareTo(y.salary));
            Console.WriteLine("Thông tin sinh viên:");
            foreach (Person person in list)
            {
                Console.WriteLine($"Họ tên: {person.name}");
                Console.WriteLine($"Địa chỉ: {person.address}");
                Console.WriteLine($"Lương: {person.salary}");
            }
        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Person person = new Person();
            person.InputPersonInfo();
            person.DisplayPersonInfo();
            

            
        }
    }
}
