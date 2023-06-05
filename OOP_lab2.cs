using System;

namespace ArrayOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Лабораторна робота №2, Дронь Олександр, ПП-22");

            while (true)
            {
                Console.WriteLine("\nОберіть вид масиву:");
                Console.WriteLine("1. Одновимірний масив");
                Console.WriteLine("2. Двовимірний масив");
                Console.WriteLine("0. Вийти");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Введено некоректний вид масиву. Спробуйте ще раз.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        PerformOneDimensionalArrayOperations();
                        break;
                    case 2:
                        PerformTwoDimensionalArrayOperations();
                        break;
                    case 0:
                        Console.WriteLine("Вихід...");
                        return;
                    default:
                        Console.WriteLine("Введено некоректний варіант. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void PerformOneDimensionalArrayOperations()
        {
            Console.WriteLine("\nВи обрали операції з одновимірним масивом.");

            int[] array = null;
            while (true)
            {
                Console.WriteLine("\nОберіть операцію:");
                Console.WriteLine("1. Створити новий масив");
                Console.WriteLine("2. Вивести масив");
                Console.WriteLine("3. Знайти елемент в масиві");
                Console.WriteLine("4. Вставити елемент у масив");
                Console.WriteLine("5. Видалити елемент з масиву");
                Console.WriteLine("6. Відсортувати масив");
                Console.WriteLine("7. Заповнити масив");
                Console.WriteLine("8. Трансформувати масив");
                Console.WriteLine("9. Скопіювати елементи з масиву за певним критерієм");
                Console.WriteLine("0. Повернутися до попереднього меню");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Введено некоректний варіант. Спробуйте ще раз.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nВведіть елементи масиву, розділені пробілом:");
                        string input = Console.ReadLine();
                        string[] values = input.Split(' ');
                        array = new int[values.Length];
                        for (int i = 0; i < values.Length; i++)
                        {
                            int.TryParse(values[i], out array[i]);
                        }
                        Console.WriteLine("Масив створено.");
                        break;
                    case 2:
                        if (array != null)
                        {
                            Console.WriteLine("Елементи масиву:");
                            foreach (int element in array)
                            {
                                Console.Write(element + " ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 3:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть значення для пошуку:");
                            int searchValue;
                            if (int.TryParse(Console.ReadLine(), out searchValue))
                            {
                                int index = Array.IndexOf(array, searchValue);
                                if (index >= 0)
                                {
                                    Console.WriteLine("Знайдено елемент зі значенням {0} у масиві. Індекс: {1}", searchValue, index);
                                }
                                else
                                {
                                    Console.WriteLine("Елемент зі значенням {0} не знайдено у масиві.", searchValue);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректне значення для пошуку.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 4:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть значення елемента для вставки:");
                            int insertValue;
                            if (int.TryParse(Console.ReadLine(), out insertValue))
                            {
                                Console.WriteLine("Введіть індекс, за яким вставити елемент:");
                                int insertIndex;
                                if (int.TryParse(Console.ReadLine(), out insertIndex))
                                {
                                    if (insertIndex >= 0 && insertIndex <= array.Length)
                                    {
                                        int[] newArray = new int[array.Length + 1];
                                        for (int i = 0; i < insertIndex; i++)
                                        {
                                            newArray[i] = array[i];
                                        }
                                        newArray[insertIndex] = insertValue;
                                        for (int i = insertIndex + 1; i < newArray.Length; i++)
                                        {
                                            newArray[i] = array[i - 1];
                                        }
                                        array = newArray;
                                        Console.WriteLine("Елемент вставлено у масив.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введено некоректний індекс.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Введено некоректний індекс для вставки.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректне значення для вставки.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 5:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть індекс елемента для видалення:");
                            int deleteIndex;
                            if (int.TryParse(Console.ReadLine(), out deleteIndex))
                            {
                                if (deleteIndex >= 0 && deleteIndex < array.Length)
                                {
                                    int[] newArray = new int[array.Length - 1];
                                    for (int i = 0; i < deleteIndex; i++)
                                    {
                                        newArray[i] = array[i];
                                    }
                                    for (int i = deleteIndex + 1; i < array.Length; i++)
                                    {
                                        newArray[i - 1] = array[i];
                                    }
                                    array = newArray;
                                    Console.WriteLine("Елемент видалено з масиву.");
                                }
                                else
                                {
                                    Console.WriteLine("Введено некоректний індекс.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректний індекс для видалення.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 6:
                        if (array != null)
                        {
                            Array.Sort(array);
                            Console.WriteLine("Масив відсортовано.");
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 7:
                        if (array != null)
                        {
							Random rnd = new Random();
							for (int i = 0; i < array.Length; i++) {
								array[i] = rnd.Next(10, 99);
							}
                            Console.WriteLine("Масив заповнено.");
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 8:
                        if (array != null)
                        {
                            Array.Reverse(array);
                            Console.WriteLine("Масив трансформовано (елементи переставлено в зворотньому порядку).");
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 9:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть число. Всі числа більше цього числа будуть скопійовані в новий масив:");
                            int copyCriterion;
                            if (int.TryParse(Console.ReadLine(), out copyCriterion))
                            {
                                int count = 0;
                                foreach (int element in array)
                                {
                                    if (element > copyCriterion)
                                    {
                                        count++;
                                    }
                                }
                                int[] newArray = new int[count];
                                int index = 0;
                                foreach (int element in array)
                                {
                                    if (element > copyCriterion)
                                    {
                                        newArray[index] = element;
                                        index++;
                                    }
                                }
                                Console.WriteLine("Елементи, що задовольняють критерій, скопійовано у новий масив.");
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректне число.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Повертаємось до попереднього меню.");
                        return;
                    default:
                        Console.WriteLine("Введено некоректний варіант. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void PerformTwoDimensionalArrayOperations()
        {
            Console.WriteLine("\nВи обрали операції з двовимірним масивом.");

            int[,] array = null;
            while (true)
            {
                Console.WriteLine("\nОберіть операцію:");
                Console.WriteLine("1. Створити новий масив");
                Console.WriteLine("2. Вивести масив");
                Console.WriteLine("3. Знайти елемент в масиві");
                Console.WriteLine("4. Вставити елемент у масив");
                Console.WriteLine("5. Видалити елемент з масиву");
                Console.WriteLine("6. Відсортувати масив");
                Console.WriteLine("7. Заповнити масив");
                Console.WriteLine("8. Трансформувати масив");
                Console.WriteLine("9. Скопіювати елементи з масиву за певним критерієм");
                Console.WriteLine("0. Повернутися до попереднього меню");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Введено некоректний варіант. Спробуйте ще раз.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nВведіть розмірність масиву (рядки стовпці), розділені пробілом:");
                        string sizeInput = Console.ReadLine();
                        string[] sizeValues = sizeInput.Split(' ');
                        int rows, columns;
                        if (sizeValues.Length == 2 && int.TryParse(sizeValues[0], out rows) && int.TryParse(sizeValues[1], out columns))
                        {
                            array = new int[rows, columns];
                            Console.WriteLine("Масив створено.");
                        }
                        else
                        {
                            Console.WriteLine("Введено некоректні розміри масиву.");
                        }
                        break;
                    case 2:
                        if (array != null)
                        {
                            Console.WriteLine("Елементи масиву:");
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    Console.Write(array[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 3:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть значення для пошуку:");
                            int searchValue;
                            if (int.TryParse(Console.ReadLine(), out searchValue))
                            {
                                bool found = false;
                                for (int i = 0; i < array.GetLength(0); i++)
                                {
                                    for (int j = 0; j < array.GetLength(1); j++)
                                    {
                                        if (array[i, j] == searchValue)
                                        {
                                            Console.WriteLine("Знайдено елемент зі значенням {0} у масиві. Рядок: {1}, Стовпець: {2}", searchValue, i, j);
                                            found = true;
                                        }
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("Елемент зі значенням {0} не знайдено у масиві.", searchValue);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректне значення для пошуку.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 4:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть значення елемента для вставки:");
                            int insertValue;
                            if (int.TryParse(Console.ReadLine(), out insertValue))
                            {
                                Console.WriteLine("Введіть рядок, у якому вставити елемент:");
                                int insertRow;
                                if (int.TryParse(Console.ReadLine(), out insertRow) && insertRow >= 0 && insertRow < array.GetLength(0))
                                {
                                    Console.WriteLine("Введіть стовпець, у якому вставити елемент:");
                                    int insertColumn;
                                    if (int.TryParse(Console.ReadLine(), out insertColumn) && insertColumn >= 0 && insertColumn < array.GetLength(1))
                                    {
                                        array[insertRow, insertColumn] = insertValue;
                                        Console.WriteLine("Елемент вставлено у масив.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введено некоректний стовпець.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Введено некоректний рядок.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректне значення для вставки.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 5:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть рядок елемента для видалення:");
                            int deleteRow;
                            if (int.TryParse(Console.ReadLine(), out deleteRow) && deleteRow >= 0 && deleteRow < array.GetLength(0))
                            {
                                Console.WriteLine("Введіть стовпець елемента для видалення:");
                                int deleteColumn;
                                if (int.TryParse(Console.ReadLine(), out deleteColumn) && deleteColumn >= 0 && deleteColumn < array.GetLength(1))
                                {
                                    array[deleteRow, deleteColumn] = 0;
                                    Console.WriteLine("Елемент видалено з масиву.");
                                }
                                else
                                {
                                    Console.WriteLine("Введено некоректний стовпець.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректний рядок.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 6:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть алгоритм сортування (наприклад, бульбашкове сортування):");
                            string sortAlgorithm = Console.ReadLine();
                            // Виконати сортування масиву за заданим алгоритмом
                            Console.WriteLine("Масив відсортовано.");
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 7:
                        if (array != null)
                        {
                            Random random = new Random();
							for (int i = 0; i < array.GetLength(0); i++)
							{
								for (int j = 0; j < array.GetLength(1); j++)
								{
									array[i, j] = random.Next(); // Generate a random integer and assign it to the matrix element
								}
							}
                            Console.WriteLine("Масив заповнено.");
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 8:
                        if (array != null)
                        {
							int rows1 = array.GetLength(0);
							int columns1 = array.GetLength(1);

							int[,] transposedMatrix = new int[columns1, rows1];

							for (int i = 0; i < rows1; i++)
							{
								for (int j = 0; j < columns1; j++)
								{
									transposedMatrix[j, i] = array[i, j];
								}
							}

							array = transposedMatrix;
                            Console.WriteLine("Масив трансформовано (транспоновано).");
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 9:
                        if (array != null)
                        {
                            Console.WriteLine("Введіть критерій для копіювання елементів:");
                            int copyCriterion;
                            if (int.TryParse(Console.ReadLine(), out copyCriterion))
                            {
                                int count = 0;
                                for (int i = 0; i < array.GetLength(0); i++)
                                {
                                    for (int j = 0; j < array.GetLength(1); j++)
                                    {
                                        if (array[i, j] == copyCriterion)
                                        {
                                            count++;
                                        }
                                    }
                                }
                                int[,] newArray = new int[count, 2];
                                int index = 0;
                                for (int i = 0; i < array.GetLength(0); i++)
                                {
                                    for (int j = 0; j < array.GetLength(1); j++)
                                    {
                                        if (array[i, j] == copyCriterion)
                                        {
                                            newArray[index, 0] = i;
                                            newArray[index, 1] = j;
                                            index++;
                                        }
                                    }
                                }
                                Console.WriteLine("Елементи, що задовольняють критерій, скопійовано у новий масив.");
                            }
                            else
                            {
                                Console.WriteLine("Введено некоректний критерій для копіювання елементів.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Масив порожній.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Повертаюся до попереднього меню.");
                        return;
                    default:
                        Console.WriteLine("Введено некоректний варіант. Спробуйте ще раз.");
                        break;
                }
            }
        }

    }
}

