using System.Text;
using UnityEngine;
using System.IO;

namespace OfcaFramework.SaveAndLoad
{
    public static class OFCSVWriter
    {
        public static void SaveToOFCSV(string[,] data, string filePath)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            var sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                var row = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    string cell = data[i, j] ?? "";
                    if (cell.Contains("\""))
                    {
                        cell = cell.Replace("\"", "\"\"");
                    }
                    if (cell.Contains(",") || cell.Contains("\"") || cell.Contains("\n"))
                    {
                        cell = $"\"{cell}\"";
                    }
                    row[j] = cell;
                }
                sb.AppendLine(string.Join(",", row));
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            Debug.Log($"Created save at: {filePath}.");
        }
    }
}