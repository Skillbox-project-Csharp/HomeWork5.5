using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5._5
{
    class Program
    {
        /// <summary>
        /// Вывод ноиера задания
        /// </summary>
        /// <param name="task"></param>
        static void PrintLabelTask(int task)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ЗАДАНИЕ {task}");
            Console.ResetColor();
        }

        static int InsertInt(int min, int max)
        {
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                    if (number >= min && number <= max)
                        break;
            }
            return number;
        }

        ////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Вывод матрцы на консоль
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],15} ");
                Console.WriteLine();
            }

        }
        /// <summary>
        /// Изменить размерность мптрицы
        /// </summary>
        /// <param name="matrix"></param>
        static void ResizeMatrix(ref int[,] matrix)
        {
            Console.Write(" Кол-во строк: ");
            int matrixRow = InsertInt(0, 1000);
            Console.SetCursorPosition(30, Console.CursorTop - 1);
            Console.Write(" Кол-во столбцов: ");
            int matrixCol = InsertInt(0, 1000);
            matrix = new int[matrixRow, matrixCol];
        }
        /// <summary>
        /// Заполнение матрицы рандомными значениями
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="rand"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        static void GenerateRandomMatrixElements(ref int[,] matrix, Random rand, int begin, int end)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rand.Next(begin, end);

        }
        /// <summary>
        /// Ввод данных матрицы с клавиатуры
        /// </summary>
        /// <param name="matrix"></param>
        static void EnteringValuesMatrix(ref int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int paddingLeft = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = InsertInt(int.MinValue, int.MaxValue);
                    paddingLeft += 15;
                    Console.SetCursorPosition(paddingLeft, Console.CursorTop - 1);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            if (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
                for (int i = 0; i < matrix1.GetLength(0); i++)
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                        matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
            return matrix3;
        }
        /// <summary>
        /// Вычетание матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixSubtraction(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            if (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
                for (int i = 0; i < matrix1.GetLength(0); i++)
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                        matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
            return matrix3;
        }
        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
                for (int i = 0; i < matrix1.GetLength(0); i++)
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                        for (int r = 0; r < matrix1.GetLength(1); r++)
                            matrix3[i, j] += matrix1[i, r] * matrix2[r, j];
            return matrix3;
        }
        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static int[,] MatrixMultiplicationNumber(int[,] matrix, int number)
        {
            int[,] matrix3 = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix3[i, j] = matrix[i, j] * number;
            return matrix3;
        }
        ////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Возврощает слово с минмальной длиной строки
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string MinStrLength(string text)
        {
            if (text.Length == 0) return "";
            string[] strs = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int min = strs.Min(s => s.Length);

            string strOut = "";
            foreach (var str in strs)
                if (str.Length == min)
                {
                    strOut = str;
                    break;
                }
            return strOut;
        }
        /// <summary>
        /// Возврощает список слов с максимальной длиноой строки
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static List<string> MaxStrLength(string text)
        {
            if (text.Length == 0) return new List<string>();

            string[] strs = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int max = strs.Max(s => s.Length);

            List<string> listOut = new List<string>();
            foreach (var str in strs)
                if (str.Length == max)
                {
                    listOut.Add(str);
                }
            return listOut;
        }
        ////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Удоляет дублирующиеся подряд символы
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string RemoveDuplicateSymbol(string text)
        {
            if (text.Length == 0) return "";

            text = text.ToLower();
            char unicumSymbol = text[0];
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == unicumSymbol)
                {
                    text = text.Remove(i, 1);
                    i--;
                }
                else unicumSymbol = text[i];
            }
            return text;
        }
        ////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Проверка прогрессии
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static string CheckProgresiv(params int[] array)
        {

            if (array.Length >= 2)
            {
                int d;
                d = array[0 + 1] - array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    int trueNextElement = array[0] + d * i;
                    if (array[i] == trueNextElement)
                    {
                        if (array.Length - 1 == i)
                            return "Арифметическая прогрессия";
                    }
                    else break;
                }

                double q;
                try
                {
                    q = array[0 + 1] / array[0] * 1.0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        double trueNextElement = array[0] * Math.Pow(q, i);
                        if (array[i] == trueNextElement)
                        {
                            if (array.Length - 1 == i)
                                return "Геометрическая прогрессия";
                        }
                        else break;
                    }
                }
                catch (DivideByZeroException)
                { }
            }

            return "не является прогрессией ";
        }
        /// <summary>
        /// Ввод ряда чисел
        /// </summary>
        /// <returns></returns>
        static int[] InsertProgression()
        {
            string strProgression;
            int[] progressionArr = new int[0];
            bool checkInt = true;
            while (checkInt)
            {
            Begin:
                strProgression = Console.ReadLine();
                string[] strProgressionArr = strProgression.Split(new String[] { " ", ",", ";", "-", ", " }, StringSplitOptions.RemoveEmptyEntries);
                progressionArr = new int[strProgressionArr.Length];
                for (int i = 0; i < strProgressionArr.Length; i++)
                    if (!int.TryParse(strProgressionArr[i], out progressionArr[i]))
                        goto Begin;

                break;
            }
            return progressionArr;
        }
        ////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Рекурсивная функ-ия Акермана
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Acerman(int m, int n)
        {
            if (m == 0)
                return n + 1;
            if (m > 0 && n == 0)
                return Acerman(m - 1, 1);
            return Acerman(m - 1, Acerman(m, n - 1));
        }

        static void Main(string[] args)
        {
            #region ЗАДАНИЕ 1

            int[,] matrixA = new int[0, 0];
            int[,] matrixB = new int[0, 0];
            bool pravilo = false;
            bool exit = false;
            Random rand = new Random();

            while (!exit)
            {
                PrintLabelTask(1);
                Console.Write("Матрица1: \n");
                PrintMatrix(matrixA);
                Console.Write("Матрица2: \n");
                PrintMatrix(matrixB);
                Console.WriteLine("1.Ввести размерность матрицы 1 и 2");
                Console.WriteLine("2.Ввести матрицу 1 и 2");
                Console.WriteLine("3.Ввести рандомные значения в матрицу 1 и 2");
                Console.WriteLine("4.Вывести матрицу 1 и 2");
                Console.WriteLine("5.Умножить матрицу 1 на на число");
                Console.WriteLine("6.Сложить матрицу 1 и 2");
                Console.WriteLine("7.Вычесть матрицу 2 из матрицы 1");
                Console.WriteLine("8.Умножить матрицу 1 на матрицу 2");
                Console.WriteLine("9.Продолжить");
                switch (InsertInt(1, 9))
                {
                    case 1:
                        Console.Write("Матрица1: \n");
                        ResizeMatrix(ref matrixA);
                        Console.Write("Матрица2: \n");
                        ResizeMatrix(ref matrixB);
                        break;
                    case 2:
                        Console.Write("Матрица1: \n");
                        EnteringValuesMatrix(ref matrixA);
                        Console.Write("Матрица2: \n");
                        EnteringValuesMatrix(ref matrixB);
                        break;
                    case 3:
                        GenerateRandomMatrixElements(ref matrixA, rand, 0, 101);
                        GenerateRandomMatrixElements(ref matrixB, rand, 0, 101);
                        break;
                    case 4:
                        Console.Write("Матрица1: \n");
                        PrintMatrix(matrixA);
                        Console.Write("Матрица2: \n");
                        PrintMatrix(matrixB);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Умножить матрицу1 на число ");
                        int number = InsertInt(int.MinValue, int.MaxValue);
                        PrintMatrix(MatrixMultiplicationNumber(matrixA, number));
                        Console.ReadKey();
                        break;
                    case 6:
                        pravilo = (matrixA.GetLength(0) == matrixB.GetLength(0)) && (matrixA.GetLength(1) == matrixB.GetLength(1));
                        if (pravilo)
                            PrintMatrix(MatrixAddition(matrixA, matrixB));
                        else
                            Console.WriteLine("Матрицы несовместимы для суммы");
                        Console.ReadKey();
                        break;
                    case 7:
                        pravilo = (matrixA.GetLength(0) == matrixB.GetLength(0)) && (matrixA.GetLength(1) == matrixB.GetLength(1));
                        if (pravilo)
                            PrintMatrix(MatrixSubtraction(matrixA, matrixB));
                        else
                            Console.WriteLine("Матрицы несовместимы для разности");
                        Console.ReadKey();
                        break;
                    case 8:
                        pravilo = matrixA.GetLength(1) == matrixB.GetLength(0);
                        if (pravilo)
                            PrintMatrix(MatrixMultiplication(matrixA, matrixB));
                        else
                            Console.WriteLine("Матрицы несовместимы для умножения");
                        Console.ReadKey();
                        break;
                    case 9:
                        exit = true;
                        break;
                }

                Console.Clear();
            }

            #endregion
            #region ЗАДАНИЕ 2
            PrintLabelTask(2);
            Console.WriteLine("Введите строку: ");

            string str = Console.ReadLine();
            Console.WriteLine($"Строка: {str}");
            Console.WriteLine($"Слово с минимальной длиной : {MinStrLength(str)}");
            Console.Write($"Слова с максимальной длиной : ");
            foreach (var element in MaxStrLength(str))
                Console.Write(element + " ");

            Console.ReadKey();
            Console.Clear();
            #endregion
            #region ЗАДАНИЕ 3
            PrintLabelTask(3);

            Console.WriteLine("Введите строку: ");
            str = Console.ReadLine();
            Console.WriteLine($"Строка: {str}");
            Console.WriteLine($"Строка без дубликатов символов: {RemoveDuplicateSymbol(str)}");
            Console.ReadKey();
            Console.Clear();
            #endregion
            #region ЗАДАНИЕ 4
            PrintLabelTask(4);

            Console.WriteLine("Введите числовую последовательность для проверки : ");
            int[] progressionArr = InsertProgression();
            foreach (var element in progressionArr)
                Console.Write(element + " ");

            Console.WriteLine();
            Console.WriteLine(CheckProgresiv(progressionArr));
            Console.ReadKey();
            Console.Clear();
            #endregion
            #region ЗАДАНИЕ 5
            PrintLabelTask(5);

            Console.Write("Введите m: ");
            int m = InsertInt(0, int.MaxValue);
            Console.Write("Введите n: ");
            int n = InsertInt(0, int.MaxValue);
            Console.WriteLine($"Акерман({m},{n}) = {Acerman(m, n)}");

            Console.ReadKey();
            Console.Clear();
            #endregion
        }
    }
}
