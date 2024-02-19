using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    public Toggle toggle;
    [SerializeField]
    public AudioSource audioSource;
    
    /* public void Awake()
    {
        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            toggle.isOn = true;
            audioSource.enabled = true;
            PlayerPrefs.Save();
        }
        else{
            if(PlayerPrefs.GetInt ("music") ==0)
            {
                audioSource.enabled=false;
                toggle.isOn=false;
            }
            else
            {
                audioSource.enabled=true;
                toggle.isOn=true;
            }
        }
    }

    public void ToggleMusic()
    {
        if(toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            audioSource.enabled=true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            audioSource.enabled=false;
        }
        PlayerPrefs.Save();
    } */
}