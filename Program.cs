class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        int[] population = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int maxCustomers = GetMaxCustomers(N, K, population);
        Console.WriteLine(maxCustomers);
    }

    static int GetMaxCustomers(int N, int K, int[] population)
    {
        int[] prefixSum = new int[N + 1];
        prefixSum[0] = 0;

        for (int i = 1; i <= N; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + population[i - 1];
        }

        int maxCustomers = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j <= Math.Min(i + K + 1, N); j++)
            {
                int customers = prefixSum[j] - prefixSum[i];
                if (customers > maxCustomers)
                {
                    maxCustomers = customers;
                }
            }
        }

        return maxCustomers;
    }
}