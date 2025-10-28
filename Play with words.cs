using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'playWithWords' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int playWithWords(string s)
    {
         int n = s.Length;

        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++)
            dp[i, i] = 1;

        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                if (s[i] == s[j])
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                else
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
            }
        }

        int maxProduct = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int left = dp[0, i];     
            int right = dp[i + 1, n - 1]; 
            maxProduct = Math.Max(maxProduct, left * right);
        }

        return maxProduct;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.playWithWords(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
