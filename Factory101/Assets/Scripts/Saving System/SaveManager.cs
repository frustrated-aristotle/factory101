using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string level = "LEVEL";


    public int Level
    {
        get => PlayerPrefs.GetInt(level);
        set => PlayerPrefs.SetInt(level, value);
    }
}
