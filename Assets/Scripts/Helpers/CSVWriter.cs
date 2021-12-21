using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVWriter {

	public static bool writeStringToCSV(string content, string fName)
    {

        var csv = new StringBuilder();

        // var newLine = string.Format("{0},{1}", first, second);
        csv.Append(content);

        File.AppendAllText(Application.dataPath + "/" + fName, csv.ToString());
        
        return true;
    }

    public static bool overwriteStringToCSV(string content, string fName)
    {

        File.WriteAllText(Application.dataPath + "/" + fName, content);

        return true;
    }

}
