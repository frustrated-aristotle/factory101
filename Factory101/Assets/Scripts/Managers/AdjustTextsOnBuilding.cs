using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdjustTextsOnBuilding : MonoBehaviour
{
    public Transform targetObject;
    public TextMeshProUGUI displayText;

    private void Start()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetObject.position);
        displayText.transform.position = new Vector3(screenPosition.x, screenPosition.y, 0);
    }
/*
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetObject.position);
        displayText.transform.position = new Vector3(screenPosition.x, screenPosition.y, 0);
    }
*/
}
