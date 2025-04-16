using static Multi.MatrixCalculateWithThreads;
namespace Multi
{

    internal class Program
    {
        public class Matrix
        {
            public int[,] Content { get; }
            public int Row => Content.GetLength(0);
            public int Col => Content.GetLength(1);
            public Matrix(int row, int col)
            {
                Content = new int[row, col];
                Random random = new Random();
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Content[i, j] = random.Next(1, 10);
                    }
                }
                // Console.WriteLine(Content[3,4]);
            }
        }
        class MatrixCalculate
        {
            //public Matrix first { get; }
            //public Matrix second { get; }
            public int threadsNumber { get; }
            public Matrix result { get; }


            public MatrixCalculate(Matrix first, Matrix second, int threads)
            {
                threadsNumber = threads;

                result = new Matrix(first.Row, second.Col);
                ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = threadsNumber };
                int[] threadUsed = new int[Environment.ProcessorCount];


                Parallel.For(0, first.Row, options, i =>
                {
                    for (int j = 0; j < second.Col; j++)
                    {
                        int cell = 0;
                        for (int k = 0; k < first.Col; k++)
                        {
                            cell += first.Content[i, k] * second.Content[k, j];
                        }
                        result.Content[i, j] = cell;
                        
                    }
                });
            }
        }
        static bool CompareMatrices(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Col != m2.Col)
                return false;

            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    if (m1.Content[i, j] != m2.Content[i, j])
                        return false;
                }
            }

            return true;
        }
        static void PrintMatrix(Matrix m)
        {
            for (int i = 0; i < m.Row; i++)
            {
                for (int j = 0; j < m.Col; j++)
                {
                    Console.Write($"{m.Content[i, j],4} "); 
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("First matrix row");
            int aRow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Second matrix column");
            int bCol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("First column, second row!");
            int aColBRow = Convert.ToInt32(Console.ReadLine());
           
            Matrix a = new Matrix(aRow, aColBRow);
            Matrix b = new Matrix(aColBRow, bCol);
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MatrixCalculate solve1 = new MatrixCalculate(a, b, 1);
            watch.Stop();
            

            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            MatrixCalculate solve2 = new MatrixCalculate(a, b, 4);
            watch1.Stop();


            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            MatrixCalculate solve3 = new MatrixCalculate(a, b, 8);
            watch2.Stop();


            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            MatrixCalculateWithThreads solve4 = new MatrixCalculateWithThreads(a, b, 1);
            watch3.Stop();

            var watch4 = System.Diagnostics.Stopwatch.StartNew();
            MatrixCalculateWithThreads solve5 = new MatrixCalculateWithThreads(a, b, 4);
            watch3.Stop();

            var watch5 = System.Diagnostics.Stopwatch.StartNew();
            MatrixCalculateWithThreads solve6 = new MatrixCalculateWithThreads(a, b, 8);
            watch3.Stop();

            //Console.WriteLine($"1 vs 4 threads (Parallel): {CompareMatrices(solve1.result, solve2.result)}");
            //Console.WriteLine($"1 vs 8 threads (Parallel): {CompareMatrices(solve1.result, solve3.result)}");
            //Console.WriteLine($"1 vs 4 threads (Thread): {CompareMatrices(solve1.result, solve4.result)}");
            //PrintMatrix(solve1.result);
            //PrintMatrix(solve2.result);
            //PrintMatrix(solve3.result);
            //PrintMatrix(solve4.result);
            //PrintMatrix(solve5.result);
            //PrintMatrix(solve6.result);


            Console.WriteLine($"Time 1: {watch.ElapsedMilliseconds}");
            Console.WriteLine($"Time 2: {watch1.ElapsedMilliseconds}");
            Console.WriteLine($"Time 3: {watch2.ElapsedMilliseconds}");
            Console.WriteLine($"Time 4: {watch3.ElapsedMilliseconds}");
            Console.WriteLine($"Time 5: {watch4.ElapsedMilliseconds}");
            Console.WriteLine($"Time 6: {watch5.ElapsedMilliseconds}");
        }
    }
}