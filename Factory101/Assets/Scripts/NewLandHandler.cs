using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLandHandler  : MonoBehaviour
{

    FactoryResources fr;
    LandBaseScript[] lands;
    public GameObject UI;
    bool UIOpened;

    void Start()
    {
        UI.SetActive(false);
        fr = GameObject.Find("Factory").GetComponent<FactoryResources>();
    }


    public void BuyNewTile(LandBaseScript tileToPurchase)
    {
        if(tileToPurchase.isBought == false) 
        {
            if(CanAfford(tileToPurchase))
            {
                fr.money -= tileToPurchase.cost;
                tileToPurchase.isBought = true;
                tileToPurchase.MakeSomeTilesBuildable();
                tileToPurchase.textMoney.text="BOUGHT FOR " + tileToPurchase.cost + "!";
            }
        }
    }
    bool CanAfford(LandBaseScript l)
    {
        if((fr.money - l.cost) > 0)
        {
            return true;
        }
        return false;
    }
}
