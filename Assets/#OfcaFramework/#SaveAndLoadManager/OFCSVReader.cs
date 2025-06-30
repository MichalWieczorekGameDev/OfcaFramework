using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

namespace OfcaFramework.SaveAndLoad
{
    public static class OFCSVReader
    {
        public static List<List<string>> LoadFromOFCSV(string filePath, char separator = ',')
        {
            var rows = new List<List<string>>();

            var fileExtension = CSVHelper.GetCSVType(filePath);

            if (fileExtension == CSVHelper.CSVType.OFCSV)
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var parsedRow = ParseOFCSVLine(line, separator);
                    rows.Add(parsedRow);
                }
            }
            else
            {
                Debug.Log($"CSVHelper: file extension = {fileExtension.ToString()}");
            }
            return rows;
        }

        private static List<string> ParseOFCSVLine(string line, char separator)
        {
            var fields = new List<string>();
            bool inQuotes = false;
            var currentField = "";

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            currentField += '"';
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        currentField += c;
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == separator)
                    {
                        fields.Add(currentField);
                        currentField = "";
                    }
                    else
                    {
                        currentField += c;
                    }
                }
            }

            fields.Add(currentField);
            return fields;
        }
    }

    public static class CSVHelper
    {
        public enum CSVType
        {
            OFCSV,
            CSV,
            Unknown
        }

        public static CSVType GetCSVType(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return CSVType.Unknown;

            string lowerPath = filePath.ToLowerInvariant();

            if (lowerPath.EndsWith(".of.csv"))
                return CSVType.OFCSV;
            else if (lowerPath.EndsWith(".csv"))
                return CSVType.CSV;

            return CSVType.Unknown;
        }
    }

}
