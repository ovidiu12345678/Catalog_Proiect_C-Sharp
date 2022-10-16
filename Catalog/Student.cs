using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Student
    {
        private static UInt16 idGenerator = 1;

        private UInt16 id=0;
        private string firstName;
        private string lastName;
        private UInt16 age;
        private Address address;
        private List<Mark> marks;

        public Student(string firstName, string lastName, UInt16 age, Address address, List<Mark> marks)
        {
            this.id = idGenerator++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.marks = marks;
        }

        public UInt16 Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public UInt16 Age { get => age; set => age = value; }
        public Address Address { get => address; set => address = value; }
        public List<Mark> Marks { get => marks; set => marks = value; }

        public override string ToString()
        {
            String studentAsString=String.Format("Id : {0}\nFirstName : {1}\nLastName : {2}\nAge : {3}\nAddress : {4}\nMarks : ",
                id, firstName, lastName, Age, address);

            marks.ForEach((mark) => studentAsString = String.Concat(studentAsString,mark));

            return String.Concat(studentAsString,"\n");
        }

        public void addMark()
        {
            Console.WriteLine("Introduceti nota:");
            Mark mark = ClassbookHelper.readMark();
            this.marks.Add(mark);
        }

        public void modifyStudentAddress()
        {
            Console.WriteLine("Introduceti noua adresa");
            Address address = ClassbookHelper.readAddress();
            this.address = address;
        }

        public float getStudentAverage()
        {
            int marksSum = 0;
            this.Marks.ForEach(mark => marksSum += mark.Value);
            return (float)marksSum / this.Marks.Count;
        }

        public Dictionary<Course, float> getStudentAverageOnEachSubject()
        {
            Dictionary<Course, float> averages = new Dictionary<Course, float>();
            Dictionary<Course, int> marksNr = new Dictionary<Course, int>();

            this.Marks.ForEach(mark =>
            {
                if (!averages.ContainsKey(mark.Course))
                    averages.Add(mark.Course, 0);
                averages[mark.Course] += mark.Value;

                if (!marksNr.ContainsKey(mark.Course))
                    marksNr.Add(mark.Course, 0);
                marksNr[mark.Course]++;

                foreach (var key in averages.Keys)
                {
                    averages[key] = (float)averages[key] / marksNr[key];
                }
            });
            return averages;
        }

        public void modifyStudentInfo()
        {
            Console.Write("Alegeti ce doriti sa modificati:\n" +
                      "1.Nume\n" +
                      "2.Prenume\n" +
                      "3.Varsta\n" +
                      "Optiune=");
            string studentInfoToModify = Console.ReadLine();
            switch (studentInfoToModify)
            {
                case "1":
                    Console.Write("Intoroduceti noul nume al studentului=");
                    string newLastName = Console.ReadLine();
                    this.LastName = newLastName;
                    break;
                case "2":
                    Console.Write("Intoroduceti noul prenume al studentului=");
                    string newFirstName = Console.ReadLine();
                    this.FirstName = newFirstName;
                    break;
                case "3":
                    Console.Write("Intoroduceti noul nume al studentului=");
                    UInt16 newAge = ClassbookHelper.readInt();
                    this.Age = newAge;
                    break;
                default:
                    Console.WriteLine("Optiunea aleasa nu este valida\n");
                    break;
            }
        }
    }
}
