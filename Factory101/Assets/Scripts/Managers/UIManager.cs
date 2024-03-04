using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] private TextMeshProUGUI resourceTxt;

    public List<TextMeshProUGUI> takeButtons;
    
    [Serializable]
    public struct Panel
    {
        public GameObject panel;
        public StateType type;
    }

    public List<Panel> panels = new List<Panel>();

    public GameObject GetPanel(StateType type)
    {
        foreach (var panel in panels)
        {
            if (panel.type == type)
            {
                return panel.panel;
            }
        }

        return null;
    }

    public void UpdateTimer(string time)
    {
        string[] timeStr = time.Split(",");
        string i;
        if (timeStr[0].Length==1)
        {
            i = "0" + timeStr[0];
        }
        else
        {
            i = timeStr[0];
        }

        if (timeStr.Length > 1 )
        {
            timerTxt.text = i + ":" + timeStr[1][0] + "0"; //timeStr[1][1];
        }
    }

    public void UpdateMoney(string money)
    {
        moneyTxt.text = money;
    }

    public void UpdateResource(string resource)
    {
        resourceTxt.text = resource;
    }
}
