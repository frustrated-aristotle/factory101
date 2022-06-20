using System.IO;    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    //private const string SAVE_EXTENSION = "txt";

    public static int savesNumber = 1;
    public static void Init()
    {
            if(!Directory.Exists(SAVE_FOLDER))
            {
                Directory.CreateDirectory(SAVE_FOLDER);
            }
    }

    public static void Save(string saveString)
    {
        while(File.Exists(SAVE_FOLDER + "save_" + savesNumber + ".txt"))
        {
            savesNumber++;
        }
        File.WriteAllText(SAVE_FOLDER + "save_" + savesNumber + "." + "txt", saveString);
    }

    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        //Getting all save files
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.txt");
        FileInfo mostRecentFile=null;
        foreach(FileInfo fileInfo in saveFiles)
        {
            if(mostRecentFile == null)
            {
                mostRecentFile= fileInfo;
            }
            else
            {
                if(fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        if(mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else
        {
            return null; 
        }
    }
}
