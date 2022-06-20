using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImprovementMainHandler : MonoBehaviour
{
    //0,1,2,3
    public Text[] texts;
    public GameObject skillTree;
    bool isUIOpened = false;
    public Improvement[] imps;
    public string[] b = {"Vehicle", "Excavator", "Processor", "Exporter"};
    
    public void Display()
    {
        int a = 0;
        foreach(Improvement i in imps)
        {
            i.Display(texts[a],b[a]);
            a++;
        }
    }
}