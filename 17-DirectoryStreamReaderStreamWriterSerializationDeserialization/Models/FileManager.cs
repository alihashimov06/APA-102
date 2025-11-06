using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _17_DirectoryStreamReaderStreamWriterSerializationDeserialization.Models
{
    internal class FileManager
    {
        public string FolderPath { get; set; }
        public string TextFilePath { get; set; }
        public string JsonFilePath { get; set; }

        public FileManager()
        {
            FolderPath = @"C:\Users\\RH\Desktop\StudentData";
            TextFilePath =Path.Combine(FolderPath, "students.txt");
            JsonFilePath = Path.Combine(FolderPath, "students.json");
        }
        public void CreatFolder()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                Console.WriteLine($"Folder yaradildi :{FolderPath}");
            }
            else
            {
                Console.WriteLine($"{FolderPath}, adinda folder artiq movcuddur ");
            }
        }
        public void DeletFolder()
        {
            if (Directory.Exists(FolderPath))
            {
                Console.WriteLine($"{FolderPath} : Folder silindi ");
                Directory.Delete(FolderPath,true);
                
            }
            else
            {
                Console.WriteLine($"{FolderPath}, adinda folder artiq movcud deyil ");
            }
        }
        public bool CheckFolder()
        {
            return Directory.Exists(FolderPath);
        }
        public void AddStudent(Student student)
        {
           
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            using (StreamWriter sw = new StreamWriter(TextFilePath, append: true))
            {
                sw.WriteLine(student.ToString());
            }
            Console.WriteLine($"Telebe fayla yazıldı: {student.Name}");
        }

        public void AddAllStudent(List<Student> students)
        {
            if (Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            File.WriteAllText(TextFilePath, string.Empty);
            using (StreamWriter sw = new StreamWriter(TextFilePath))
            {
                foreach (Student student in students)
                {
                    sw.WriteLine(student.ToString());
                }
            }
            Console.WriteLine($"Ümumi[{students.Count}] sayda telebe fayla yazıldı");
        }
        public List<Student> ReadStudent()
        {
            List<Student> students = new List<Student>();
            if (!Directory.Exists(FolderPath))
            {
                Console.WriteLine($"{FolderPath} adinda fayil tapilmadi");
                
                Console.WriteLine($"fayldan oxunan telebe sayi 0 - dir");
                return students;
            }
            using(StreamReader sr = new StreamReader(TextFilePath))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split(',');

                    if (!int.TryParse(parts[0], out int id)) continue;

                    string name = parts[1];

                    string surname = parts[2];

                    if (!int.TryParse(parts[3], out int age)) continue;

                    if (!double.TryParse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture, out double grade)) continue;

                    Student student = new Student(id, name, surname, age, grade);
                    students.Add(student);
                }
            }
            Console.WriteLine($"Fayldan {students.Count} telebe oxundu");
            return students;

        }
        public void SerializeToJson(List<Student> students)
        {
            
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(JsonFilePath, json);
            Console.WriteLine("Telebeler JSON formatında yadda saxlanıldı");
        }

        
        public List<Student> DeserializeFromJson()
        {
            List<Student> list = new List<Student>();

            if (!File.Exists(JsonFilePath))
            {
                Console.WriteLine($"JSON faylı tapılmadı: {JsonFilePath}");
                Console.WriteLine("JSON-dan 0 telebe yüklendi");
                return list;
            }

            string json = File.ReadAllText(JsonFilePath);
            try
            {
                var students = JsonSerializer.Deserialize<List<Student>>(json);
                if (students != null)
                {
                    list = students;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON oxunarken xeta: " + ex.Message);
            }

            Console.WriteLine($"JSON-dan {list.Count} telebə yüklendi");
            return list;
        }
    }
}
