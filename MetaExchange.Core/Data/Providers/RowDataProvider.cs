﻿using System.Text.Json;
using MetaExchange.Core.Data.Providers.Interfaces;
using MetaExchange.Core.Utility;

namespace MetaExchange.Core.Data.Providers
{
    public class RowDataProvider<T> : IDataProvider<T>
    {
        public IEnumerable<T> GetData(string fileName)
        {
            var pathToFile = PathUtility.FindFilePath(fileName);
            var jsonData = ExtractJsonRows(pathToFile);
            
            var entities = new List<T>();
            foreach (var row in jsonData)
            {
                var entity = JsonSerializer.Deserialize<T>(row);
                entities.Add(entity);
            }

            return entities;
        }

        public List<string> ExtractJsonRows(string pathToFile)
        {
            var jsonRows = new List<string>();
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        int tabIndex = line.IndexOf('\t');
                        if (tabIndex != -1)
                        {
                            string jsonPart = line.Substring(tabIndex + 1);
                            jsonRows.Add(jsonPart);
                        }
                    }
                }
            }

            return jsonRows;
        }
    }
}
