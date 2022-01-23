using SystemIO.Helpers;
using System;
using SystemIO.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SystemIO.Data;

namespace SystemIO.Workflows
{
    public class EditStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit Student");

            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            ConsoleIO.PrintPickListOfStudents(students);
            Console.WriteLine();

            int index = ConsoleIO.GetStudentIndexFromUser("Which student would you like to edit?", students.Count());
            index--;

            Console.WriteLine("");

            students[index].GPA = ConsoleIO.GetRequiredDecimalFromUser(
                string.Format("Enter new GPA for {0} {1}: ", students[index].FirstName, students[index].LastName));
            repo.Edit(students[index], index);
            Console.WriteLine("GPA updated!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
