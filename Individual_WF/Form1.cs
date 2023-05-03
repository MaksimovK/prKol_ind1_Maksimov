using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private List<Student> ReadStudentsFromFile(string filePath)
        {
            List<Student> students = new List<Student>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(';');
                    string lastName = parts[0];
                    string firstName = parts[1];
                    string middleName = parts[2];
                    string group = parts[3];
                    double[] grades = parts[4].Split(',').Select(s => double.Parse(s)).ToArray();
                    Student student = new Student(lastName, firstName, middleName, group, grades);
                    students.Add(student);
                }
            }

            return students;
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            // Открытие диалогового окна выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Чтение данных о студентах из файла
                List<Student> students = ReadStudentsFromFile(filePath);

                // Сортировка студентов по оценкам
                List<Student> passedStudents = students.Where(s => s.AverageGrade >= 3.6).ToList();
                List<Student> failedStudents = students.Where(s => s.AverageGrade < 3.6).ToList();

                // Отображение данных в textBox
                listBoxResult.Items.Clear();
                listBoxResult.Items.Add("Сдавшие сессию:");
                foreach (var student in passedStudents)
                {
                    listBoxResult.Items.Add(student.ToString());
                }

                listBoxResult.Items.Add("");
                listBoxResult.Items.Add("Не сдавшие сессию:");
                foreach (var student in failedStudents)
                {
                    listBoxResult.Items.Add(student.ToString());
                }
            }
        }
    }
}
