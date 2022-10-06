using System;
using System.Collections;
using System.Collections.Generic;

namespace lab1
{

    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Создать два объекта типа Person с совпадающими данными и проверить, что ссылки на объекты не равны, а объекты равны, вывести значения хэш - кодов для объектов");
            Person person1 = new Person();
            person1.FirstName = "Екатерина";
            person1.LastName = "Афонина";
            person1.Date = new DateTime(2003, 12, 13);
            Person person2 = new Person();
            person2.FirstName = "Екатерина";
            person2.LastName = "Афонина";
            person2.Date = new DateTime(2003, 12, 13);
            Console.WriteLine("Объект person1: "+ person1.ToString());
            Console.WriteLine("Объект person2: "+ person2.ToString());
            Console.WriteLine("Сравнение ссылок: " + object.ReferenceEquals(person1, person2));
            Console.WriteLine("Сравнение значений объектов через Equals: " + person1.Equals(person2));
            Console.Write("Сравнение значений объектов через ==: ");
            Console.WriteLine(person1 == person2);
            Console.WriteLine(string.Format("Сравнение хэш-кодов: \nperson1: {0}, person2: {1} ", person1.GetHashCode(), person2.GetHashCode()));

            //2
            Console.WriteLine("\nСоздать объект типа Student, добавить элементы в список экзаменов и зачетов, вывести данные объекта Student");
            Student student1 = new Student();
            Exam exam = new Exam("Математика", 4, new DateTime(2022, 6, 18));
            student1.AddExams(exam);
            exam = new Exam("Физика", 1, new DateTime(2022, 6, 12));
            student1.AddExams(exam);
            exam = new Exam("Иностранный язык", 5, new DateTime(2022, 6, 11));
            student1.AddExams(exam);
            exam = new Exam("ПрЧМИ", 5, new DateTime(2022, 6, 24));
            student1.AddExams(exam);
            Test test = new Test("Физ-ра", true);
            student1.AddTests(test);
            test = new Test("Физика", true);
            student1.AddTests(test);
            test = new Test("Иностранный язык", true);
            student1.AddTests(test);
            test = new Test("ПрЧМИ", false);
            student1.AddTests(test);
            Console.WriteLine(student1.ToString());

            //3
            Console.WriteLine("\nВывечти значение свойства типа Person для объекта Student");
            Console.WriteLine(student1.StudentData.ToString());

            //4
            Console.WriteLine("\nС помощью метода DeepCopy() создать полную копию объекта Student. Изменить данные в исходном объекте Student и вывести копию и исходный объект, полная копия исходного объекта должна остаться без изменений.");
            Student student1copy = (Student)student1.DeepCopy();
            student1.StudentData.FirstName ="Мельпомена";
            student1.FirstName = "Мельпомена";
            student1.StudentData.LastName = "Сурана";
            student1.LastName = "Сурана";
            Console.WriteLine("\nОригинал:" + student1.ToString());
            Console.WriteLine("\nКопия:" + student1copy.ToString());

            //5
            Console.WriteLine("\nВ блоке try/catch присвоить свойству с номером группы некорректное значение, в обработчике исключения вывести сообщение, переданное через объект - исключение");
            try
            {
                //int gn = Convert.ToInt32(Console.ReadLine());
                student1.GroupNumber = 4;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //6
            Console.WriteLine("\nС помощью оператора foreach для итератора, определенного в классе Student, вывести список всех зачетов и экзаменов");
            foreach (Object obj in student1.AllExamsAndTests()) { }

            //7
            Console.WriteLine("\nС помощью оператора foreach для итератора с параметром, определенного в классе Student, вывести список всех экзаменов с оценкой выше 3.");
            foreach (Exam exam1 in student1.ExamsWithMark(3)) { }

            //8


            //9
            Console.WriteLine("\nС помощью оператора foreach для итератора, определенного в классе Student, вывести список всех сданных зачетов и сданных экзаменов.");
            foreach (Object obj in student1.PassedExamsAndTests()) { }

            //10
            Console.WriteLine("\nС помощью оператора foreach для итератора, определенного в классе Student, вывести список сданных зачетов, для которых сдан и экзамен.");
            foreach (Test test1 in student1.PassedTests()) { }
        }
    }
}
