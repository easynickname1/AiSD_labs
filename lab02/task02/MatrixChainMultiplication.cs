using System.Numerics;

namespace lab02.task02;

public class MatrixChainMultiplication
{
    public static int DynamicSolve(int[] arr)
    {
        int n = arr.Length - 1;
        int[,] resultMatrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            resultMatrix[i, i] = 0;
        }

        for (int l = 1; l < n; l++)
        {
            for (int i = 0; i < n - l; i++)
            {
                int j = i + l;
                resultMatrix[i, j] = int.MaxValue;
                for (int k = i; k < j; k++)
                {
                    resultMatrix[i, j] = Math.Min(resultMatrix[i, j], resultMatrix[i, k] + resultMatrix[k + 1, j] + arr[i] * arr[k + 1] * arr[j + 1]);
                }
            }
        }

        return resultMatrix[0, n - 1];
    }
}
