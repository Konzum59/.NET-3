namespace Multi
{

    internal class Program
    {
        class Matrix
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
                int cell = 0;
                ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = threadsNumber };
                int[] threadUsed = new int[Environment.ProcessorCount];


                Parallel.For(0, first.Row, options, i =>
                {
                    for (int j = 0; j < second.Col; j++)
                    {
                        for (int k = 0; k < first.Col; k++)
                        {
                            cell += first.Content[i, k] * second.Content[k, j];
                        }
                        result.Content[i, j] = cell;
                        
                    }
                });
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
            Console.WriteLine($"Time 1: {watch.ElapsedMilliseconds}");
            Console.WriteLine($"Time 2: {watch1.ElapsedMilliseconds}");
            Console.WriteLine($"Time 3: {watch2.ElapsedMilliseconds}");
        }
    }
}