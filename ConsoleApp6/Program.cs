using ConsoleApp6;

var matrix = new Matrix<int>(3, 3);

Console.WriteLine("Matrix filled with 5:");
Console.WriteLine(matrix);

matrix[1, 1] = 10;
Console.WriteLine("\nAfter setting matrix[1, 1] = 10:");
Console.WriteLine(matrix);

matrix.RotateX();
Console.WriteLine("\nAfter RotateX (flip over X-axis):");
Console.WriteLine(matrix);

matrix.RotateY();
Console.WriteLine("\nAfter RotateY (flip over Y-axis):");
Console.WriteLine(matrix);

var matrixB = new Matrix<int>(3, 3);
matrixB.Fill(3);
var sumMatrix = Matrix<int>.Add(matrix, matrixB);
Console.WriteLine("\nSum of two matrices:");
Console.WriteLine(sumMatrix);