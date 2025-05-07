using System;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть номер завдання: ");
        int n = int.Parse(Console.ReadLine()!);
        switch (n)
        {
            case 1:
                // Прототип: Лабораторна робота №5, завдання 2
                Task_1.Task_1 myTask_1 = new Task_1.Task_1();
                myTask_1.main1();
                break;
            case 2:
                Task_2.Task_2 myTask_2 = new Task_2.Task_2();
                myTask_2.main2();
                break;
            case 3:
                // Прототип: Лабораторна робота №5, завдання 3
                // Виняток у класі Hyperbola
                Task_3.Task_3 myTask_3 = new Task_3.Task_3();
                myTask_3.main3();
                break;
            case 4:
                // Прототип: Лабораторна робота №5, завдання 1
                Task_4.Task_4 myTask_4 = new Task_4.Task_4();
                myTask_4.main4();
                break;
        }
        Main();
    }
}
