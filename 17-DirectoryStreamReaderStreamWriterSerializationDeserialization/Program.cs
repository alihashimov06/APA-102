
using System;
using System.Diagnostics;
using System.Xml.Linq;
using _17_DirectoryStreamReaderStreamWriterSerializationDeserialization.Models;

#region senari 1
Student student1 = new(1, "Ali", "Hashimov", 19, 92.0);
Student student2 = new(2, "Leyla", "Həsənova", 20, 85.5);
Student student3 = new(3, "Vüqar", "Əliyev", 21, 78.5);
Student student4 = new(4, "Nigar", "Əhmədova", 20, 88.0);
Student student5 = new(5, "Rəşad", "Quliyev", 22, 95.5);

List<Student> students = new List<Student>
{
    student1,
    student2,
    student3,
    student4,
    student5
};
foreach (Student student in students)
{
    student.DisplayInfo();
}
#endregion
Console.WriteLine("-------------------------- senari 2 e giris -----------------------");

#region senari 2
FileManager folder = new FileManager();
bool cheak = folder.CheckFolder();
if (cheak)
{
    folder.DeletFolder();
}
folder.CreatFolder();
Console.WriteLine($"folder movcuttur mu? : {folder.CheckFolder()}");
#endregion
Console.WriteLine("-------------------------- senari 3 e giris -----------------------");

#region senari 3
foreach (Student student in students)
{
    folder.AddStudent(student);
    Console.WriteLine($"{student.Name} adli sexs file elave olundu");
}
File.WriteAllText(folder.TextFilePath, string.Empty);
folder.AddAllStudent(students);

#endregion
Console.WriteLine("-------------------------- senari 4 e giris -----------------------");

#region senari 4
List<Student> readStuden = folder.ReadStudent();

Console.WriteLine($"oxunan telelbelerin sayi : {readStuden.Count}");

foreach (Student student in readStuden)
{
    student.DisplayInfo();
}
#endregion
Console.WriteLine("-------------------------- senari 5 e giris -----------------------");

#region senari 5
folder.SerializeToJson(students);
Console.WriteLine($"JSON fayl yolu: {folder.JsonFilePath}");
Console.WriteLine();
#endregion
Console.WriteLine("-------------------------- senari 6 s giris -----------------------");

#region senari 6
Console.WriteLine("---- JSON-dan deserializasiya ----");
List<Student> jsonStudents = folder.DeserializeFromJson();
Console.WriteLine($"JSON-dan oxunan tələbə sayı: {jsonStudents.Count}");
foreach (Student js in jsonStudents)
{
    js.DisplayInfo();
}
Console.WriteLine();
#endregion
Console.WriteLine("-------------------------- senari 7 s giris -----------------------");

#region senari 7
Console.WriteLine("---- students.txt ici ----");
if (File.Exists(folder.TextFilePath))
{
    string txtContent = File.ReadAllText(folder.TextFilePath);
    Console.WriteLine(txtContent);
}
else
{
    Console.WriteLine("students.txt tapılmadı.");
}

Console.WriteLine("---- students.json ici ----");
if (File.Exists(folder.JsonFilePath))
{
    string jsonContent = File.ReadAllText(folder.JsonFilePath);
    Console.WriteLine(jsonContent);
}
else
{
    Console.WriteLine("students.json tapılmadı.");
}
Console.WriteLine();
#endregion
Console.WriteLine("-------------------------- senari 8 s giris -----------------------");

Console.WriteLine($"umumi telebelerin sayi :{students.Count}");
double sum = 0;
foreach (Student student in students)
{
    sum += student.Grade;
}
Console.WriteLine($"orta bal{sum / students.Count}");
double max = student1.Grade;
double min = student1.Grade;
foreach (Student student in students)
{
    if (student.Grade < min)
        min = student.Grade;

    if (student.Grade > max)
        max = student.Grade;
}
int c = 0;
foreach (Student student in students)
{
    if (student.Grade > 90)
    {
        c += 1;
    }
}
Console.WriteLine(c);
if (File.Exists(folder.TextFilePath))
{
    FileInfo fiTxt = new FileInfo(folder.TextFilePath);
    Console.WriteLine($"students.txt ölçüsü: {fiTxt.Length} bayt");
}
else
{
    Console.WriteLine("students.txt tapılmadı");
}

if (File.Exists(folder.JsonFilePath))
{
    FileInfo fiJson = new FileInfo(folder.JsonFilePath);
    Console.WriteLine($"students.json ölçüsü: {fiJson.Length} bayt");
}
else
{
    Console.WriteLine("students.json tapılmadı ");
}