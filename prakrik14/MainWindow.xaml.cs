using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Math_practice14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 30; i++)
            {
                TaskSelector.Items.Add(new ComboBoxItem() { Content = $"Задание {i}" });
            }
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskSelector.SelectedIndex == -1) return;
            int taskNumber = TaskSelector.SelectedIndex + 1;
            ResultBox.Text = SolveTask(taskNumber);
        }

        private string SolveTask(int taskNumber)
        {
            try
            {
                switch (taskNumber)
                {
                    case 1: return SolveTask1();
                    case 2: return SolveTask2();
                    case 3: return SolveTask3();
                    case 4: return SolveTask4();
                    case 5: return SolveTask5();
                    case 6: return SolveTask6();
                    case 7: return SolveTask7();
                    case 8: return SolveTask8();
                    case 9: return SolveTask9();
                    case 10: return SolveTask10();
                    case 11: return SolveTask11();
                    case 12: return SolveTask12();
                    case 13: return SolveTask13();
                    case 14: return SolveTask14();
                    case 15: return SolveTask15();
                    case 16: return SolveTask16();
                    case 17: return SolveTask17();
                    case 18: return SolveTask18();
                    case 19: return SolveTask19();
                    case 20: return SolveTask20();
                    case 21: return SolveTask21();
                    case 22: return SolveTask22();
                    case 23: return SolveTask23();
                    case 24: return SolveTask24();
                    case 25: return SolveTask25();
                    case 26: return SolveTask26();
                    case 27: return SolveTask27();
                    case 28: return SolveTask28();
                    case 29: return SolveTask29();
                    case 30: return SolveTask30();
                    default: return "Задание не реализовано";
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        private int[,] GenerateIntMatrix(int rows, int cols, int min = -10, int max = 10)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rnd.Next(min, max);
            return matrix;
        }

        private double[,] GenerateDoubleMatrix(int size)
        {
            double[,] matrix = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = Math.Round(rnd.NextDouble() * 20 - 10, 2);
            return matrix;
        }

        private string MatrixToString(int[,] matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    result += $"{matrix[i, j],5}";
                result += "\n";
            }
            return result;
        }

        private string MatrixToString(double[,] matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    result += $"{matrix[i, j],8:F2}";
                result += "\n";
            }
            return result;
        }

        private string SolveTask1()
        {
            int[,] matrix = GenerateIntMatrix(3, 4);
            var sorted = Enumerable.Range(0, matrix.GetLength(1))
                .OrderBy(j => matrix[matrix.GetLength(0) - 1, j])
                .ToArray();

            string result = "Исходная матрица:\n" + MatrixToString(matrix) + "\n";
            result += "Отсортированные столбцы по последней строке:\n";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                foreach (var j in sorted)
                    result += $"{matrix[i, j],5}";
                result += "\n";
            }
            return result;
        }

        private string SolveTask2()
        {
            int[,] matrix = GenerateIntMatrix(7, 7);
            int sum = 0;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    if (matrix[i, j] < 0 && matrix[i, j] % 2 != 0)
                        sum += Math.Abs(matrix[i, j]);

            return $"Матрица:\n{MatrixToString(matrix)}\nСумма модулей отрицательных нечетных: {sum}";
        }

        private string SolveTask3()
        {
            int[,] matrix = GenerateIntMatrix(5, 6);
            string result = $"Матрица:\n{MatrixToString(matrix)}\n";
            for (int j = 0; j < 6; j++)
            {
                double sum = 0; int count = 0;
                for (int i = 0; i < 5; i++)
                    if (matrix[i, j] > 0) { sum += matrix[i, j]; count++; }
                result += $"Столбец {j + 1}: Среднее = {(count > 0 ? sum / count : 0):F2}\n";
            }
            return result;
        }

        private string SolveTask4()
        {
            double[,] matrix = GenerateDoubleMatrix(5);
            double min = double.MaxValue;
            for (int i = 0; i < 5; i++)
                if (matrix[i, 4 - i] < min) min = matrix[i, 4 - i];
            return $"Матрица:\n{MatrixToString(matrix)}\nМинимальный на побочной диагонали: {min:F2}";
        }

        private string SolveTask5()
        {
            int[,] matrix = GenerateIntMatrix(5, 4);
            var sorted = Enumerable.Range(0, matrix.GetLength(0))
                .OrderByDescending(i => matrix[i, matrix.GetLength(1) - 1])
                .ToArray();

            string result = "Исходная матрица:\n" + MatrixToString(matrix) + "\n";
            result += "Отсортированные строки по последнему столбцу:\n";

            foreach (var i in sorted)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    result += $"{matrix[i, j],5}";
                result += "\n";
            }
            return result;
        }

        private string SolveTask6()
        {
            int[,] matrix = GenerateIntMatrix(4, 3);
            int max1 = Enumerable.Range(0, 4).Max(i => matrix[i, 0]);
            int max3 = Enumerable.Range(0, 4).Max(i => matrix[i, 2]);

            for (int i = 0; i < 4; i++)
            {
                if (matrix[i, 0] == max1)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[i, 2];
                        matrix[i, 2] = temp;
                    }
                    break;
                }
            }

            return $"Исходная матрица:\n{MatrixToString(matrix)}\n" +
                   $"Поменяли местами max1={max1} и max3={max3}\n" +
                   $"Результат:\n{MatrixToString(matrix)}";
        }

        private string SolveTask7()
        {
            int[,] matrix = GenerateIntMatrix(3, 4);
            int min1 = Enumerable.Range(0, 4).Min(j => matrix[0, j]);
            int min3 = Enumerable.Range(0, 4).Min(j => matrix[2, j]);

            for (int j = 0; j < 4; j++)
            {
                if (matrix[0, j] == min1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[i, 2];
                        matrix[i, 2] = temp;
                    }
                    break;
                }
            }

            return $"Исходная матрица:\n{MatrixToString(matrix)}\n" +
                   $"Поменяли местами min1={min1} и min3={min3}\n" +
                   $"Результат:\n{MatrixToString(matrix)}";
        }

        private string SolveTask8()
        {
            double[,] matrix = GenerateDoubleMatrix(5);
            double product = 1;
            for (int j = 0; j < 5; j++)
            {
                double min = Enumerable.Range(0, 5).Min(i => matrix[i, j]);
                product *= min;
            }
            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Произведение минимальных элементов столбцов: {product:F2}";
        }

        private string SolveTask9()
        {
            int[,] matrix = GenerateIntMatrix(5, 6);
            string result = $"Матрица:\n{MatrixToString(matrix)}\n";

            result += "Среднее по столбцам:\n";
            for (int j = 0; j < 6; j++)
            {
                double sum = 0;
                for (int i = 0; i < 5; i++) sum += matrix[i, j];
                result += $"{sum / 5:F2} ";
            }

            result += "\n\nMin и max по строкам:\n";
            for (int i = 0; i < 5; i++)
            {
                int min = matrix[i, 0], max = matrix[i, 0];
                for (int j = 1; j < 6; j++)
                {
                    if (matrix[i, j] < min) min = matrix[i, j];
                    if (matrix[i, j] > max) max = matrix[i, j];
                }
                result += $"Строка {i + 1}: min={min}, max={max}\n";
            }

            return result;
        }

        private string SolveTask10()
        {
            int[,] matrix = GenerateIntMatrix(7, 8);
            string result = $"Матрица:\n{MatrixToString(matrix)}\n";
            result += "Количество нечетных по столбцам:\n";

            for (int j = 0; j < 8; j++)
            {
                int count = 0;
                for (int i = 0; i < 7; i++)
                    if (matrix[i, j] % 2 != 0) count++;
                result += $"{count} ";
            }

            return result;
        }

        private string SolveTask11()
        {
            int[,] matrix = GenerateIntMatrix(4, 5);
            int even = 0, odd = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] % 2 == 0) even++;
                    else odd++;
                }
            }

            return $"Матрица 4x5:\n{MatrixToString(matrix)}\n" +
                   $"Четных: {even}, Нечетных: {odd}";
        }

        private string SolveTask12()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int count = 0;

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (matrix[i, j] == 7) count++;

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Число 7 встречается {count} раз";
        }

        private string SolveTask13()
        {
            int[,] matrix = GenerateIntMatrix(4, 6);
            string result = $"Матрица:\n{MatrixToString(matrix)}\n" +
                           "Наибольшие элементы столбцов:\n";

            for (int j = 0; j < 6; j++)
            {
                int max = matrix[0, j];
                for (int i = 1; i < 4; i++)
                    if (matrix[i, j] > max) max = matrix[i, j];
                result += $"Столбец {j + 1}: {max}\n";
            }

            return result;
        }

        private string SolveTask14()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int min = matrix[0, 0];
            int minRow = 0, minCol = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
                }
            }

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Первый наименьший элемент: {min}\n" +
                   $"Позиция: строка {minRow + 1}, столбец {minCol + 1}";
        }

        private string SolveTask15()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int sum = 0;

            for (int i = 0; i < 5; i++)
                sum += matrix[i, 4];

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Сумма последнего столбца: {sum}";
        }

        private string SolveTask16()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int product = 1;

            for (int j = 0; j < 5; j++)
                product *= matrix[0, j];

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Произведение первой строки: {product}";
        }

        private string SolveTask17()
        {
            int[,] matrix = GenerateIntMatrix(10, 10);
            string result = $"Матрица 10x10:\n{MatrixToString(matrix)}\n" +
                           "Суммы строк:\n";

            for (int i = 0; i < 10; i++)
            {
                int sum = 0;
                for (int j = 0; j < 10; j++)
                    sum += matrix[i, j];
                result += $"Строка {i + 1}: {sum}\n";
            }

            return result;
        }

        private string SolveTask18()
        {
            int[,] matrix = GenerateIntMatrix(4, 4);
            int minSum = int.MaxValue;
            int minRow = 0;

            for (int i = 0; i < 4; i++)
            {
                int sum = 0;
                for (int j = 0; j < 4; j++)
                    sum += matrix[i, j];

                if (sum < minSum)
                {
                    minSum = sum;
                    minRow = i;
                }
            }

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Строка с наименьшей суммой: {minRow + 1}\n" +
                   $"Сумма: {minSum}";
        }

        private string SolveTask19()
        {
            int[,] matrix = GenerateIntMatrix(7, 7);
            int maxSum = int.MinValue;
            int maxRow = 0;

            for (int i = 0; i < 7; i++)
            {
                int sum = 0;
                for (int j = 0; j < 7; j++)
                    sum += matrix[i, j];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = i;
                }
            }

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Строка с наибольшей суммой: {maxRow + 1}\n" +
                   $"Сумма: {maxSum}";
        }

        private string SolveTask20()
        {
            int[,] matrix = GenerateIntMatrix(6, 8);
            int product = 1;

            for (int i = 0; i < 6; i++)
            {
                if (matrix[i, 0] > 0)
                    product *= matrix[i, 0];
            }

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Произведение положительных в первом столбце: {product}";
        }

        private string SolveTask21()
        {
            int[,] matrix = GenerateIntMatrix(4, 6);
            string result = $"Матрица 4x6:\n{MatrixToString(matrix)}\n" +
                           "Суммы столбцов:\n";

            for (int j = 0; j < 6; j++)
            {
                int sum = 0;
                for (int i = 0; i < 4; i++)
                    sum += matrix[i, j];
                result += $"{sum} ";
            }

            return result;
        }

        private string SolveTask22()
        {
            int[,] matrix = GenerateIntMatrix(5, 10);
            int minRowSum = int.MaxValue;

            for (int i = 0; i < 5; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < 10; j++)
                    rowSum += matrix[i, j];

                if (rowSum < minRowSum)
                    minRowSum = rowSum;
            }

            return $"Матрица 5x10:\n{MatrixToString(matrix)}\n" +
                   $"Минимальная сумма строки: {minRowSum}";
        }

        private string SolveTask23()
        {
            int[,] matrix = GenerateIntMatrix(4, 5);
            double average = matrix.Cast<int>().Average();
            int count = matrix.Cast<int>().Count(x => x > average);

            return $"Матрица 4x5:\n{MatrixToString(matrix)}\n" +
                   $"Среднее: {average:F2}\n" +
                   $"Элементов > среднего: {count}";
        }

        private string SolveTask24()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int sum = 0;

            for (int j = 0; j < 5; j++)
                sum += matrix[1, j];

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Сумма второй строки: {sum}";
        }

        private string SolveTask25()
        {
            int[,] matrix = GenerateIntMatrix(4, 4);
            int negativeCount = 0;

            for (int i = 0; i < 4; i++)
                if (matrix[i, 1] < 0)
                    negativeCount++;

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Отрицательных во 2-м столбце: {negativeCount}";
        }

        private string SolveTask26()
        {
            int[,] matrix = GenerateIntMatrix(3, 7);
            string result = $"Матрица 3x7:\n{MatrixToString(matrix)}\n" +
                           "Количество элементов в столбцах:\n";

            for (int j = 0; j < 7; j++)
            {
                int count = 0;
                for (int i = 0; i < 3; i++)
                    count++;
                result += $"{count} ";
            }

            return result;
        }

        private string SolveTask27()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int oddSum = 0;

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (matrix[i, j] % 2 != 0)
                        oddSum += matrix[i, j];

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Сумма нечетных элементов: {oddSum}";
        }

        private string SolveTask28()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);

            int[] row4 = new int[5];
            int[] row5 = new int[5];

            for (int j = 0; j < 5; j++)
            {
                row4[j] = matrix[3, j];
                row5[j] = matrix[4, j];
            }

            for (int j = 0; j < 5; j++)
            {
                matrix[3, j] = row5[j];
                matrix[4, j] = row4[j];
            }

            return $"Исходная матрица:\n{MatrixToString(matrix)}\n" +
                   "После замены 4 и 5 строк:\n" +
                   $"{MatrixToString(matrix)}";
        }

        private string SolveTask29()
        {
            int[,] matrix = GenerateIntMatrix(4, 4);
            int minColSum = int.MaxValue;
            int minColIndex = 0;

            for (int j = 0; j < 4; j++)
            {
                int colSum = 0;
                for (int i = 0; i < 4; i++)
                    colSum += matrix[i, j];

                if (colSum < minColSum)
                {
                    minColSum = colSum;
                    minColIndex = j;
                }
            }

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Столбец с наименьшей суммой: {minColIndex + 1}\n" +
                   $"Сумма: {minColSum}";
        }

        private string SolveTask30()
        {
            int[,] matrix = GenerateIntMatrix(5, 5);
            int count = 0;
            for (int i = 0; i < 5; i++)
                if (matrix[i, 1] >= 0) count++;

            return $"Матрица:\n{MatrixToString(matrix)}\n" +
                   $"Количество неотрицательных во 2-м столбце: {count}";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
    

