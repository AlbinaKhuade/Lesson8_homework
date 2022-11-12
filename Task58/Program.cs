// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


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

int[,] MultiplyTwoMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] resMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            resMatrix[i, j] = 0;
            for (int k = 0; k < matrix2.GetLength(0); k++)
            {
                resMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return resMatrix;
}



int[,] firstMatrix = CreateMatrixRndInt(2, 2, 1, 10);
Console.WriteLine("Первая матрица:");
PrintMatrix(firstMatrix);
Console.WriteLine();

int[,] secondMatrix = CreateMatrixRndInt(2, 2, 1, 10);
Console.WriteLine("Вторая матрица:");
PrintMatrix(secondMatrix);
Console.WriteLine();

if (firstMatrix.GetLength(1) == secondMatrix.GetLength(0))
{
    int[,] resultMatrix = MultiplyTwoMatrix(firstMatrix, secondMatrix);
    Console.WriteLine("Результирующая матрица:");
    PrintMatrix(resultMatrix);
}
else Console.WriteLine("Умножение матриц невозможно - количество столбцов первой матрицы должно быть равно количеству строк второй матрицы!");