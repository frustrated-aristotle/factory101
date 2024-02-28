using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] private TextMeshProUGUI resourceTxt;
    
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
        Debug.Log(timeStr[0]);
        timerTxt.text = timeStr[0]+","+timeStr[1][0]+timeStr[1][0];
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
