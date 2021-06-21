using FirewallRuleManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirewallRuleManagement.Helpers
{
    public class FilterHelper
    {

        public IEnumerable<SelectListItem> InterfaceItems(List<string> names)
        {
            yield return new SelectListItem { Text = "", Value = "" };
            foreach (string name in names)
                yield return new SelectListItem { Text = name, Value = name };

        }
        public IEnumerable<SelectListItem> GetNames(string result)
        {
            List<string> names= new List<string>();
            string[] lines = result.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Contains("name=\""))
                {
                    line = line.Substring(line.IndexOf("name=\"") + 6);
                    names.Add(line.Substring(0, line.IndexOf("\"")));
                }

            }
            return InterfaceItems(names);
        }
        public List<Filter> GetFilters(string result)
        {
            List<Filter> filters = new List<Filter>();
            string[] lines = result.Split('\n');
            int f_id = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                Dictionary<string, string> tempData = new Dictionary<string, string>();
                string line = lines[i];
                if (line != "" && line!="\r")
                {
                    if(line.Contains(" X "))
                    {
                        tempData["Disabled"] = "True";
                        line=line.Replace(" X ", "");
                    }
                    line = line.TrimEnd('\r').TrimStart(' ');
                    if (line.Contains(";;;"))
                    {
                        string comment = line.Substring(line.IndexOf(";;;") + 4);
                        tempData["Comment"] = comment;
                    }
                    else
                    {
                        tempData = GetStatements(line, tempData);
                    }
                    while (i + 1 < lines.Length && lines[i + 1].Length > 1 && lines[i + 1][1] == ' ')
                    {
                        i++;
                        line = lines[i];
                        tempData = GetStatements(line, tempData);
                    }
                    var json = JsonConvert.SerializeObject(tempData, Formatting.Indented);
                    var filter = JsonConvert.DeserializeObject<Filter>(json);
                    filter.Id= f_id;
                    f_id++;
                    filters.Add(filter);
                }
            }
            return filters;
        }
        private Dictionary<string, string> GetStatements(string line, Dictionary<string, string> tempData)
        {
            line = line.TrimStart(' ');
            if (Regex.IsMatch(line, @"^\d+"))
            {
                line = new Regex(@"^\d+").Replace(line, "");
            }
                string[] statements = line.Split(' ');

            foreach (string statement in statements)
            {
                if (statement != "" && statement != "\r")
                {
                    string key = statement.Split('=')[0];
                    string val = statement.Split('=')[1];
                    tempData[key] = val;
                }
            }
            return tempData;
        }

    }
}
