using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactoryResources : MonoBehaviour
{
    public float money;
    //public TextMesh moneyTexta;
    public TextMeshProUGUI moneyText;
    
    void Update()
    {
        DisplayMoney();
    }
    void DisplayMoney()
    {
        moneyText.text="Money: " + money.ToString();
    }
}