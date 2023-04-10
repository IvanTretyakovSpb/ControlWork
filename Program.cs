/* Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, 
длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, 
либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, 
лучше обойтись исключительно массивами.
Примеры:
[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
[“Russia”, “Denmark”, “Kazan”] → [] */
/////////////////////////////////////////////////////////////////////////////////////////////////
Console.Clear();
int arraySize = GetNumberFromUser("Укажите количество элементов массива для ввода строк: ", "Ошибка ввода!");
string[] stringArray = GetArray(arraySize);
string[] newStringArray = GetNewStringArray(stringArray);
Console.WriteLine($"[{String.Join(", ", stringArray)}] -> [{String.Join(", ", newStringArray)}]");
//////////////////////////////////////////////////////////////////////////////////
// Описание используемых методов
// Метод запрашивает у пользователя целое положительное число
int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 0)
        {
            return userNumber;
        }
        Console.WriteLine(errorMessage);
    }
}
// Метод создает одномерный массив строк из size элементов, вводимых пользователем с клавиатуры
string[] GetArray(int size)
{
    string[] res = new string[size];
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Введите {i + 1}-ю строку: ");
        res[i] = Console.ReadLine();
    }
    return res;
}
// Метод формирует из имеющегося массива строк новый, элементами которого являются непустые строки, 
// длина которых меньше, либо равна 3 символам.
string[] GetNewStringArray(string[] inArray)
{
    int count = 0;
    foreach (string value in inArray)
    {
        if (value.Length <= 3 && !String.IsNullOrWhiteSpace(value))
        {
            count++;
        }
    }
    string[] newArr = new string[count];
    int j = 0;
    for (int i = 0; i < inArray.Length; i++)
    {
        if (inArray[i].Length <= 3 && !String.IsNullOrWhiteSpace(inArray[i]))
        {
            newArr[j] = inArray[i];
            j++;
        }
    }
    return newArr;
}