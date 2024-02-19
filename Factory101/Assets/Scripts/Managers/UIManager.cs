using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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
}
