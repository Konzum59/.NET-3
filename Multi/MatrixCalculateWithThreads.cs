using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Multi.Program;
namespace Multi
{
    class MatrixCalculateWithThreads
    {
        public Matrix result { get; }
        public int threadsNumber { get; }

        public MatrixCalculateWithThreads(Matrix first, Matrix second, int threads)
        {
            threadsNumber = threads;
            result = new Matrix(first.Row, second.Col);
            Thread[] threadsArray = new Thread[threadsNumber];

            int rowsPerThread = first.Row / threadsNumber;
            int remainingRows = first.Row % threadsNumber;

            for (int t = 0; t < threadsNumber; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow = (t == threadsNumber - 1) ? (startRow + rowsPerThread + remainingRows) : (startRow + rowsPerThread);

                threadsArray[t] = new Thread(() =>
                {
                    for (int i = startRow; i < endRow; i++)
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
                    }
                });
                threadsArray[t].Start();
            }

            foreach (Thread thread in threadsArray)
            {
                thread.Join();
            }
        }
    }

}
