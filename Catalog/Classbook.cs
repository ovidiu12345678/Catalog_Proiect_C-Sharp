using Catalog;
using System.Data;
using System.Runtime.CompilerServices;

class Classbook
{
    List<Student> students = ClassbookHelper.getStartupStudentsList();

    public void addStudent(Student student) { students.Add(student); }

    public void removeStudent(UInt16 studentId) {
        if (students.Find(student => student.Id == studentId) != null)
            students.Remove(getStudentById(studentId));
        else throw new Exception("Studentul cu ID-ul dat nu exista");
    }

    public Student getStudentById(UInt16 studentId)
    {
        Student student=students.Find(student => student.Id == studentId);
        if (student == null) throw new Exception("Studentul cu ID-ul dat nu exista");
        return student;
    }

   public List<Student> getStudentsOrderedByAverageDesc()
    {
        return students.OrderByDescending(student => student.getStudentAverage()).ToList();
    }

    public List<Student> Students { get => students; set => students = value; }
}