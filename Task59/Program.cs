// Задача 59: Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец, на
// пересечении которых расположен наименьший элемент
// массива.


int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    var matrix = new int[rows, columns];
    var rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],5}, ");
            else Console.Write($"{matrix[i, j],5} ");
        }
        Console.WriteLine("|");
    }
}

int[] FindMin(int[,] matrix)
{
    int min = matrix[0, 0];
    int minRow = 0;
    int minColumn = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] <= min)
            {
                min = matrix[i, j];
                minRow = i;
                minColumn = j;
            }
        }
    }
    return new int[] { min, minRow, minColumn };
}

void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (i < arr.Length - 1) Console.Write($"{arr[i]}; ");
        else Console.Write($"{arr[i]}.");
    }
}

int[,] ChangeMatrix(int[,] matrix, int[] min)
{
    int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    for (int i = 0; i < min[1]; i++)
    {
        for (int j = 0; j < min[2]; j++)
        {
            newMatrix[i, j] = matrix[i, j];
        }
        for (int j = min[2]; j < newMatrix.GetLength(1); j++)
        {
            newMatrix[i, j] = matrix[i, j + 1];
        }
    }
    for (int i = min[1]; i < newMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < min[2]; j++)
        {
            newMatrix[i, j] = matrix[i + 1, j];
        }
        for (int j = min[2]; j < newMatrix.GetLength(1); j++)
        {
            newMatrix[i, j] = matrix[i + 1, j + 1];
        }
    }
    return newMatrix;
}

int[,] array2D = CreateMatrixRndInt(4, 4, 1, 10);
PrintMatrix(array2D);
Console.WriteLine();

int[] minElement = FindMin(array2D);
// PrintArray(minElement);
Console.WriteLine($"Минимальный элемент = {minElement[0]}, строка = {minElement[1] + 1}, столбец = {minElement[2] + 1}");
Console.WriteLine();

Console.WriteLine($"Матрица без строки {minElement[1] + 1} и столбца {minElement[2] + 1} выглядит так:");
int[,] newArray2D = ChangeMatrix(array2D, minElement);
PrintMatrix(newArray2D);