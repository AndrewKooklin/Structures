﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork7_2
{
    public static class Communication
    {
        /// <summary>
        /// Выбор пунктов основного меню
        /// </summary>
        public static void Operation(string[] allLinesRecords, string path)
        {
            char key;

            do
            {

                Console.WriteLine("\n Введите цифру :" +
                    "\n 1 - для просмотра всех записей" +
                    "\n 2 - для просмотра записи" +
                    "\n 3 - для создания записи" +
                    "\n 4 - для удаления записи" +
                    "\n 5 - для редактирования записи" +
                    "\n 6 - для чтения записей в выбранном доапазоне дат" +
                    "\n 7 - для сортировки записей по возрастанию и убыванию дат" +
                    "\n 8 - для записи всех изменений в файл" +
                    "\n 9 - для выхода из программы");

                char input = Console.ReadKey().KeyChar;

                key = input;

                Console.WriteLine();

                switch (input)
                {
                    case '1':
                        {
                            FileMethods.PrintAllLines(allLinesRecords);
                            break;
                        }
                    case '2':
                        {
                            FileMethods.PrintOneRecord(FileMethods.ReadRecord(allLinesRecords));
                            break;
                        }
                    case '3':
                        {   
                            if(allLinesRecords == null)
                            {
                                allLinesRecords = new string[1];

                                allLinesRecords[^1] = Communication.CreateRecord();
                            }
                            else
                            {
                                Array.Resize(ref allLinesRecords, allLinesRecords.Length + 1);

                                allLinesRecords[^1] = Communication.CreateRecord();
                            }
                            break;
                        }
                    case '4':
                        {
                            allLinesRecords = FileMethods.Delete(allLinesRecords);
                            break;
                        }
                    case '5':
                        {
                            allLinesRecords = FileMethods.Update(allLinesRecords);
                            break;
                        }
                    case '6':
                        {
                            FileMethods.SelectDate(allLinesRecords);
                            break;
                        }
                    case '7':
                        {
                            allLinesRecords = FileMethods.Sorted(allLinesRecords);
                            break;
                        }
                    case '8':
                        {
                            FileMethods.WriteAllLines(path, allLinesRecords);
                            break;
                        }
                    case '9':
                        {
                            Console.WriteLine("Программа завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введите цифру от 1 до 8");
                            break;
                        }
                }

            } while (key != '9');
        }

        /// <summary>
        /// Проверка вводимой строки на число
        /// </summary>
        /// <returns></returns>
        public static int Input()
        {
            Console.WriteLine("Введите номер записи");
            string numberRecord = Console.ReadLine();

            bool result = Int32.TryParse(numberRecord, out int control);

            if (control == 0 || !result)
            {
                return 0;
            }
            else if (result)
            {
                return control;
            }
            return 0;
        }

        /// <summary>
        /// Ввод данных о сотруднике
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string CreateRecord()
        {
            FileMethods.Employee emp = new FileMethods.Employee();

            do
            {
                Console.WriteLine("Введите ID сотрудника (целое число)");

                bool input = int.TryParse(Console.ReadLine(), out emp.id);

                if (input)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            while (true);

            emp.dateCreate = DateTime.Now;

            Console.WriteLine("Введите Ф.И.О.");
            emp.fullName = Console.ReadLine();

            do
            {
                Console.WriteLine("Введите возраст (целое число)");

                bool input = int.TryParse(Console.ReadLine(), out emp.age);

                if (input)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Введите рост в см (целое число)");

                bool input = int.TryParse(Console.ReadLine(), out emp.height);

                if (input)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            while (true);

            do
            {
                Console.WriteLine("Введите дату рождения в числовом формате dd.MM.yyyy");

                bool input = DateTime.TryParse(Console.ReadLine(), out emp.dateOfBirth);

                if (input)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный формат");
                }
            }
            while (true);

            Console.WriteLine("Введите место рождения");
            emp.placeOfBirth = "Город " + Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Запись в массиве создана");

            return emp.Record();            
        }
    }
}
