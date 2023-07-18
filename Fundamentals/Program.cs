// See https://aka.ms/new-console-template for more information

using System.Collections;
internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int[]>> students = new Dictionary<string, Dictionary<string, int[]>>();
        const int numberOfStudentScores = 5;
        const int numberOfStudents = 4;

        students = llenarNombres(numberOfStudents, numberOfStudentScores);

        students = asignarNotas(students, numberOfStudentScores);

        foreach (var student in students)
        {
            Console.WriteLine($"El estudiante {student.Key} tuvo las siguientes notas: ");
            for (int j = 0; j < numberOfStudentScores; j++)
            {
                Console.WriteLine(student.Value["notas"][j]);
            }
        }

        foreach (var student in students)
        {
            var avgScorePerStudent = student.Value["notas"].Average();

            switch (avgScorePerStudent)
            {
                case >= 97:
                    Console.WriteLine($"Puntaje {avgScorePerStudent} A+");
                    break;
                case >= 93 and <= 96:
                    Console.WriteLine($"Puntaje {avgScorePerStudent} A");
                    break;
                case >= 90 and <= 92:
                    Console.WriteLine($"Puntaje {avgScorePerStudent} A-");
                    break;
                case >= 87 and <= 89:
                    Console.WriteLine($"Puntaje {avgScorePerStudent} B+");
                    break;
                case >= 83 and <= 86:
                    Console.WriteLine($"Puntaje {avgScorePerStudent} B");
                    break;
            }
        }

    }

    public static Dictionary<string, Dictionary<string, int[]>> llenarNombres(int numberOfStudents, int numberOfStudentScores)
    {
        var students = new Dictionary<string, Dictionary<string, int[]>>();

        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.Write($"Ingrese el nombre del estudiante {i + 1}: ");
            string studentName = Console.ReadLine();
            students.Add(studentName, new Dictionary<string, int[]>());
            students[studentName].Add("notas", new int[numberOfStudentScores]);
            students[studentName].Add("nota final", new int[1]);
        }

        return students;
    }

    public static Dictionary<string, Dictionary<string, int[]>> asignarNotas(Dictionary<string, Dictionary<string, int[]>> target, int scoresStudents)
    {
        foreach (var student in target)
        {
            Console.WriteLine($"Ingrese la nota de {student.Key}");
            for (int j = 0; j < scoresStudents; j++)
            {
                do
                {
                    try
                    {
                        student.Value["notas"][j] = Convert.ToInt16(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ingresa un numero en formato entero entre el 0 y 100");
                        student.Value["notas"][j] = -1;
                    }

                    Console.WriteLine(student.Value["notas"][j]);
                    if (student.Value["notas"][j] < 0 || student.Value["notas"][j] > 100)
                    {
                        Console.WriteLine("Número inválido. Inténtelo nuevamente.");
                    }
                } while (student.Value["notas"][j] < 0 || student.Value["notas"][j] > 100);
            }
        }
        return target;
    }
}
