using Microsoft.AspNetCore.Mvc;
using Myexam200.Models; // Reemplaza con tu espacio de nombres real
using System.Collections.Generic;
using System.Linq;

public class StudentController : Controller
{
    // Static list of students in memory
    private static List<Student> students = new List<Student>
    {
        new Student { StudentId = 1, FirstName = "Alison", LastName = "Segura", EmailAddress = "alison.segura@example.com" },
        new Student { StudentId = 2, FirstName = "Leo", LastName = "Becerra", EmailAddress = "leo.becerra@example.com" },
        new Student { StudentId = 3, FirstName = "Marco", LastName = "Antonio", EmailAddress = "marco.antonio@example.com" }
    };

    // Action to display the list of students
    public IActionResult Index()
    {
        return View(students);
    }

    // Action to create a new student
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.StudentId = students.Count + 1; // Assign a new ID
            students.Add(student); // Add the student to the list
            return RedirectToAction("Index");
        }
        return View(student);
    }

    // Action to edit a student
    public IActionResult Edit(int id)
    {
        var student = students.FirstOrDefault(s => s.StudentId == id);
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.EmailAddress = student.EmailAddress;
            }
            return RedirectToAction("Index");
        }
        return View(student);
    }

    // Action to display the delete confirmation page
    public IActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.StudentId == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: /Student/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = students.FirstOrDefault(s => s.StudentId == id);
        if (student != null)
        {
            students.Remove(student); // Remove the student from the list
        }
        return RedirectToAction("Index");
    }
}

