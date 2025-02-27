namespace PruebaTecnicaDelosi.Services
{
    public class MatrizService : IMatrizService
    {
        public int[][] RotarAntihorario(int[][] matriz)
        {
            int n = matriz.Length;
            int[][] resultado = new int[n][];

            // Creamos una matriz de igual longitud para el resultado
            for (int i = 0; i < n; i++)
            {
                resultado[i] = new int[n];
            }

            // Llenar la matriz resultado
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultado[n - j - 1][i] = matriz[i][j];
                }
            }

            return resultado;
        }
    }
}
