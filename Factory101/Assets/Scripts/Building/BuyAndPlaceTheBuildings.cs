using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAndPlaceTheBuildings : MonoBehaviour
{
    public  bool isOnBuildingMode;
    public  bool isThereAnySellectedBuilding=false;

    private string gameMode = "Build";
    public  GameObject buildingUI;

    public  Building sellectedBuilding;
    private UIController uIController;
    private FactoryResources fr;
    void Start()
    {
        buildingUI.SetActive(false);
        fr = GameObject.Find("Factory").GetComponent<FactoryResources>();
        uIController = GameObject.FindObjectOfType<UIController>();
    }

    bool isThePlayerCanBuild(TileMainScript tile)
    {

        if(sellectedBuilding != null &&  GameModeCheck() &&
           tile.isBuildable  && !tile.haveBuilding)
        {
            if (fr.money > sellectedBuilding.cost )
            {
                fr.money -= sellectedBuilding.cost;
                fr.factoryWorth += sellectedBuilding.worth;
            
                return true;
            }
            else
            Debug.Log("There is no enough money for building.");
        }
        return false;
    }
    public bool GameModeCheck()
    {
        bool b;
        b= (gameMode == uIController.gameMode) ? true : false;
        return b;
    }
    public void SellectBuildingViaButton(Building _sellectedBuilding)
    {
        sellectedBuilding = _sellectedBuilding;
        isThereAnySellectedBuilding = true;
    }

    //This method will be called when the player clicked an buildable tile.
    public void BuyAndPlaceTheBuilding(TileMainScript tile)
    {
        //We are paying the money in this boolean isThePla...
        if(isThePlayerCanBuild(tile) && tile.isBuildable && !tile.haveBuilding)
        {

            Instantiate(sellectedBuilding, tile.newTP, Quaternion.identity);
            tile.haveBuilding = true;
        }
    }

}