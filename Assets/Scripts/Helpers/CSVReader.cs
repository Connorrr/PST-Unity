using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System;
using UnityEngine;

public class CSVReader {

    static List<string> angry;
    static List<string> calm;
    static List<string> good;
    static List<string> happy;
    static List<string> mild;
    static List<string> negative;
    static List<string> positive;
    static List<string> severe;

    static List<string> angryShuffled;
    static List<string> calmShuffled;
    static List<string> goodShuffled;
    static List<string> happyShuffled;
    static List<string> mildShuffled;
    static List<string> negativeShuffled;
    static List<string> positiveShuffled;
    static List<string> severeShuffled;

    public static bool haveFilenamesBeenPulled()
    {
        //Debug.Log(angry.Count);
        if (angry != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //  This function pulls the filenames from the CSV and then stores it locally so the file only has to be read once.
    //  Be sure to call this fuction beofre any of the others and only call it once.
    public static void PullFilenames(TextAsset csvFile)
    {
        angry = new List<string>();
        calm = new List<string>();
        good = new List<string>();
        happy = new List<string>();
        mild = new List<string>();
        negative = new List<string>();
        positive = new List<string>();
        severe = new List<string>();
        angryShuffled = new List<string>();
        calmShuffled = new List<string>();
        goodShuffled = new List<string>();
        happyShuffled = new List<string>();
        mildShuffled = new List<string>();
        negativeShuffled = new List<string>();
        positiveShuffled = new List<string>();
        severeShuffled = new List<string>();

        string fullText = csvFile.text;

        string[] lines = Regex.Split(fullText, "\n");
        for ( int i = 1; i < lines.Length; i++ )
        {
            string[] cols = Regex.Split(lines[i], ",");
            if (cols.Length > 7)
            {
                appendList(angry, removeInvalidPathChars(cols[0]));
                appendList(angryShuffled, removeInvalidPathChars(cols[0]));
                appendList(calm, removeInvalidPathChars(cols[1]));
                appendList(calmShuffled, removeInvalidPathChars(cols[1]));
                appendList(good, removeInvalidPathChars(cols[2]));
                appendList(goodShuffled, removeInvalidPathChars(cols[2]));
                appendList(happy, removeInvalidPathChars(cols[3]));
                appendList(happyShuffled, removeInvalidPathChars(cols[3]));
                appendList(mild, removeInvalidPathChars(cols[4]));
                appendList(mildShuffled, removeInvalidPathChars(cols[4]));
                appendList(negative, removeInvalidPathChars(cols[5]));
                appendList(negativeShuffled, removeInvalidPathChars(cols[5]));
                appendList(positive, removeInvalidPathChars(cols[6]));
                appendList(positiveShuffled, removeInvalidPathChars(cols[6]));
                appendList(severe, removeInvalidPathChars(cols[7]));
                appendList(severeShuffled, removeInvalidPathChars(cols[7]));
            }
        }

        angryShuffled.Shuffle();
        calmShuffled.Shuffle();
        goodShuffled.Shuffle();
        happyShuffled.Shuffle();
        mildShuffled.Shuffle();
        negativeShuffled.Shuffle();
        positiveShuffled.Shuffle();
        severeShuffled.Shuffle();

        Debug.Log("angryShuffled Count:  " + angryShuffled.Count);
        Debug.Log("calmShuffled Count:  " + calmShuffled.Count);
        Debug.Log("goodShuffled Count:  " + goodShuffled.Count);
        Debug.Log("happyShuffled Count:  " + happyShuffled.Count);
        Debug.Log("mildShuffled Count:  " + mildShuffled.Count);
        Debug.Log("negativeShuffled Count:  " + negativeShuffled.Count);
        Debug.Log("positiveShuffled Count:  " + positiveShuffled.Count);
        Debug.Log("severeShuffled Count:  " + severeShuffled.Count);
    }

    //  This function parses the Images.csv file and pulls the a random element excluding the excluded string
    //  fromColumn:     1 = Angry
    //                  2 = Calm
    //                  3 = Good
    //                  4 = Happy 
    //                  5 = Mild
    //                  6 = Negative
    //                  7 = Positive
    //                  8 = Severe
    //  ignoring:  This string is a filename that we don't want to pull from the asset list in the specified column
    public static string GetImageFileName(List<string> excluding, int fromColumn = 0) {
        string rtrnString = "";

        checkForTopUp();

        if (fromColumn == 1)
        {
            rtrnString = "Images/angry/" + getFilteredFileName(excluding, angryShuffled);
        }
        else if (fromColumn == 2)
        {
            rtrnString = "Images/Calm/" + getFilteredFileName(excluding, calmShuffled);
        }
        else if (fromColumn == 3)
        {
            rtrnString = "Images/Good/" + getFilteredFileName(excluding, goodShuffled);
        }
        else if (fromColumn == 4)
        {
            rtrnString = "Images/happy/" + getFilteredFileName(excluding, happyShuffled);
        }
        else if (fromColumn == 5)
        {
            rtrnString = "Images/Mild/" + getFilteredFileName(excluding, mildShuffled);
        }
        else if (fromColumn == 6)
        {
            rtrnString = "Images/Negative/" + getFilteredFileName(excluding, negativeShuffled);
        }
        else if (fromColumn == 7)
        {
            rtrnString = "Images/Positive/" + getFilteredFileName(excluding, positiveShuffled);
        }
        else if (fromColumn == 8)
        {
            rtrnString = "Images/Severe/" + getFilteredFileName(excluding, severeShuffled);
        }
        else
        {
            Debug.Log("Please set the forColumn value between 1 - 8");
        }
        
        return rtrnString;
    }

    //  Append the string into the list if there is at least 1 character
    private static void appendList(List<string> list, string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            list.Add(name);
        }
    }

    //  Returns a random value from the list wihich will exclude results that match the excluded name
    private static string getFilteredFileName(List<string> excludedNames, List<string> fNames)
    {
        List<int> excludedIndexs = new List<int>();
        //int index = getRandomNumberExcluding(0, fNames.Count, excludedIndexs);


        int i = 0;
        string fileName = Path.GetFileNameWithoutExtension(fNames[i]);
        while (excludedNames.Contains(fileName))
        {
            i++;
            fileName = Path.GetFileNameWithoutExtension(fNames[i]);
        }
        fNames.RemoveAt(i);

        //while (excludedNames.Contains(fileName))
        //{
        //    excludedIndexs.Add(index);
        //    index = getRandomNumberExcluding(0, fNames.Count, excludedIndexs);
        //    fileName = Path.GetFileNameWithoutExtension(fNames[index]);
        //}
        //Debug.Log(fileName);
        return fileName;
    }

    //  This function checks the shuffled lists and if one is empty it will fill it again and reshuffle
    private static void checkForTopUp()
    {
        if (angryShuffled.Count == 0)
        {
            Debug.Log("Topped up Angry");
            Debug.Log("angryShuffled Count:  " + angryShuffled.Count);
            Debug.Log("angry Count:  " + angry.Count);
            for (int i = 0; i < angry.Count; i++)
            {
                angryShuffled.Add(angry[i]);
            }
            angryShuffled.Shuffle();
        }

        if (calmShuffled.Count == 0)
        {
            Debug.Log("Topped up Calm");
            for (int i = 0; i < calm.Count; i++)
            {
                calmShuffled.Add(calm[i]);
            }
            calmShuffled.Shuffle();
        }

        if (goodShuffled.Count == 0)
        {
            Debug.Log("Topped up Good");
            for (int i = 0; i < good.Count; i++)
            {
                goodShuffled.Add(good[i]);
            }
            goodShuffled.Shuffle();
        }

        if (happyShuffled.Count == 0)
        {
            Debug.Log("Topped up Happy");
            for (int i = 0; i < happy.Count; i++)
            {
                happyShuffled.Add(happy[i]);
            }
            happyShuffled.Shuffle();
        }

        if (mildShuffled.Count == 0)
        {
            Debug.Log("Topped up Mild");
            for (int i = 0; i < mild.Count; i++)
            {
                mildShuffled.Add(mild[i]);
            }
            mildShuffled.Shuffle();
        }

        if (negativeShuffled.Count == 0)
        {
            Debug.Log("Topped up Negative");
            for (int i = 0; i < negative.Count; i++)
            {
                negativeShuffled.Add(negative[i]);
            }
            negativeShuffled.Shuffle();
        }

        if (positiveShuffled.Count == 0)
        {
            Debug.Log("Topped up Positive");
            for (int i = 0; i < positive.Count; i++)
            {
                positiveShuffled.Add(positive[i]);
            }
            positiveShuffled.Shuffle();
        }

        if (severeShuffled.Count == 0)
        {
            Debug.Log("Topped up Severe");
            for (int i = 0; i < severe.Count; i++)
            {
                severeShuffled.Add(severe[i]);
            }
            severeShuffled.Shuffle();
        }
    }

    private static string removeInvalidPathChars(string fname)
    {
        string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
        return r.Replace(fname, "");
    }

    //  Returns a random value between the lower range and the upper range excluing the specified number.
    //  If you want to just use this as a regular random number generator simply put the excding value outside the range.
    private static int getRandomNumberExcluding(int lowerRange, int upperRange, List<int> excluding)
    {
        int value = 0;

        System.Random rnd = new System.Random();
        value = rnd.Next(lowerRange, upperRange);

        while (excluding.Contains(value))
        {
            if (value == lowerRange)
            {
                value = rnd.Next(lowerRange + 1, upperRange);
            }
            else if (value == upperRange)
            {
                value = rnd.Next(lowerRange, upperRange - 1);
            }
            else
            {
                if (rnd.Next(0, 1) == 0)
                {
                    value = rnd.Next(lowerRange, value - 1);
                }
                else
                {
                    value = rnd.Next(value + 1, upperRange);
                }
            }
        }

        return value;
    }

}
