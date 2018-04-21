using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    class Matrix
    {
        public int[,] matrix;
        public int Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }
        private int element;


        public int Number_of_lines
        {
            get
            {
                return numb_lines;
            }
            set
            {
                numb_lines = value;
            }

        }
        private int numb_lines;

        public int Number_of_columns
        {
            get
            {
                return numb_colums;
            }
            set
            {
                numb_colums = value;
            }
        }
        private int numb_colums;


        private int num;
        public Matrix(int a, int b)
        {
            numb_lines = a;
            numb_colums = b;
            matrix = new int[numb_lines, numb_colums];
        }

        public Matrix()
        {

            while (true)
            {
                Console.WriteLine("Введите количество строк");
                string str = Console.ReadLine();
                if ((!Int32.TryParse(str, out int p)))
                {
                    Console.WriteLine("Введите целое число");
                }
                else
                {
                    num = Convert.ToInt32(str);
                    if (num < 1)
                    {
                        Console.WriteLine("Количество строк должно быть не меньше одной");
                    }
                    else
                    {
                        numb_lines = num;
                        break;
                    }
                }
                
            }


            while (true)
            { Console.WriteLine("Введите количество столбцов");

                string str = Console.ReadLine();
                if ((!Int32.TryParse(str, out int p)))
                {
                    Console.WriteLine("Введите целое число");
                }
                else
                {
                    num = Convert.ToInt32(str);
                         if (num < 1)
                    {
                        Console.WriteLine("Количество столбцов должно быть не меньше одного");
                    }
                    else
                    {
                        Number_of_columns = num;
                        break;
                    }
                }
               
            }
            matrix = new int[numb_lines, numb_colums];
            Console.WriteLine("Введите элементы матрицы");
            for (int i = 0; i < numb_lines; i++)

            {

                for (int j = 0; j < numb_colums; j++)
                {

                    while (true)
                    {
                        string str = Console.ReadLine();
                        if ((!Int32.TryParse(str, out int p)))
                        {
                            Console.WriteLine("Введите целое число");
                            
                        }
                        else
                        {
                            num = Convert.ToInt32(str);
                            if (num % 1 != 0)
                                Console.WriteLine("Введите целое число");
                            else
                                element = num;
                            matrix[i, j] = element;
                            break;

                        }
                        
                    }

                        

                }

            }
        }

        public override string ToString()
        { string result = $"\n";

            for (int i = 0; i < numb_lines; i++)
            {
                for (int j = 0; j < numb_colums; j++)
                {
                    result += $"{matrix[i, j]}\t";
                }
                result += $"\n";

            }
            return result;
        }


        public static Matrix operator *(Matrix a, int b)
        {
            Matrix result = new Matrix(a.numb_lines, a.numb_colums);
            for (int i = 0; i < a.numb_lines; i++)
            {
                for (int j = 0; j < a.numb_colums; j++)
                {
                    result.matrix[i, j] = a.matrix[i, j] * b;
                }
            }
            return result;
        }

        public static Matrix operator *(int b, Matrix a)
        {
            Matrix result = new Matrix(a.numb_lines, a.numb_colums);
            result = a * b;
            return a;
        }

        public void Transportir_Matrix()
        {

            for (int i = 0; i < numb_lines; i++)
            {
                for (int j = 0; j < numb_colums; j++)
                {
                    int u = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = u;

                }
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.numb_lines, a.numb_colums);
            if (a.numb_colums != b.numb_colums & a.numb_lines != b.numb_lines)
            {
                Console.WriteLine("Матрицы имеют разный размер,сложить матрицы невозможно");
            }
            else
            {
                for (int i = 0; i < a.numb_lines; i++)
                {
                    for (int j = 0; j < a.numb_colums; j++)
                    {
                        int c = a.matrix[i, j] + b.matrix[i, j];
                        result.matrix[i, j] = c;
                    }
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.numb_lines, a.numb_colums);
            if (a.numb_colums != b.numb_colums & a.numb_lines != b.numb_lines)
            {
                Console.WriteLine("Матрицы имеют разный размер,сложить матрицы невозможно");
            }
            else
            {

                for (int i = 0; i < a.numb_lines; i++)
                {
                    for (int j = 0; j < a.numb_colums; j++)
                    {
                        result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            int sum ;
            int[] sum1 = new int[a.numb_colums];
            int[] sum2 = new int[a.numb_colums];
            Matrix result = new Matrix(a.numb_lines, b.numb_colums);
            if (a.numb_colums == b.Number_of_lines)
            {

                for (int i = 0; i < a.numb_lines; i++)
                {
                    for (int j = 0; j < b.numb_colums; j++)
                    {
                        sum = 0;
                        {
                            for (int u = 0; u < a.numb_colums; u++)
                                sum1[u] = a.matrix[i, u];
                            for (int u = 0; u < b.numb_lines; u++)
                                sum2[u] = b.matrix[u, j];
                            for (int u = 0; u < a.numb_colums; u++)
                                sum = sum + (sum1[u] * sum2[u]);
                        }
                        result.matrix[i, j] = sum;
                    }
                }

            }
            else
            {
                Console.WriteLine("Матрицы умножить невозможно");
            }
            return result;
        }

        public static Matrix operator ^(Matrix a, int n)
        {
            Matrix result = new Matrix(a.numb_lines, a.numb_colums);

            if (a.numb_lines == a.numb_colums )
            {
                if (n > 0)
                {


                    for (int i = 1; i < n; i++)
                    {
                        result = a * a;
                    }
                }
                else
                    Console.WriteLine("Степень должна быть положительным числом");
            }
            else
            {
                Console.WriteLine("В степень можно возвоить только квадратную матрицу");
            }


            return result;
        }

    }
    }




           




