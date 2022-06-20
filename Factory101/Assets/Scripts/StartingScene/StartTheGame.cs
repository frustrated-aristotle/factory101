using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
    GameObject gm;
    public bool isLoadingASave = false;
    public void LoadScene()
    {
        SceneManager.LoadScene("Scenes/GamesScene");
        isLoadingASave = false;
    }
    public void LoadASave()
    {
        SceneManager.LoadScene("Scenes/GamesScene");
        isLoadingASave = true;
    }
}
