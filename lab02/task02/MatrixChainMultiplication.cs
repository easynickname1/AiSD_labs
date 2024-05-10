using System.Numerics;

namespace lab02.task02;

public class MatrixChainMultiplication
{
    public static int DynamicSolve(int[] arr)
    {
        int n = arr.Length - 1;
        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = 0;
        }

        for (int l = 1; l < n; l++)
        {
            for (int i = 0; i < n - l; i++)
            {
                int j = i + l;
                dp[i, j] = int.MaxValue;
                for (int k = i; k < j; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + arr[i] * arr[k + 1] * arr[j + 1]);
                }
            }
        }
        return dp[0, n - 1];
    }
}
