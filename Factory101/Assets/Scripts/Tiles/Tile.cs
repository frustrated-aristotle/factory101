using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //* Tiles have this script. 
    public bool isBuildable;
    public bool haveBuilding= false;
    
    public Vector3 newTP;
    
    private Color orgColor;
    private Color buildableTileColor;
    public Material matOrg;
    public Material matHoverOver;
    public Material matBuildable;
    private Renderer rend;

    private BuyAndPlaceTheBuildings buyAndPlaceTheBuildings;


    private StateManager stateManager;
    private PurchaseManager purchaseManager;
    private ResourceManager resourceManager;

    public IPurchasable building;
    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        purchaseManager = FindObjectOfType<PurchaseManager>();
        stateManager = FindObjectOfType<StateManager>();
        rend = GetComponent<Renderer>();       
        buyAndPlaceTheBuildings = GameObject.FindObjectOfType<BuyAndPlaceTheBuildings>();
        if(isBuildable)
        {
            MakeBuildable();
        }

        //newTP = new Vector3(transform.position.x, transform.position.y, -3);
    }

    public void MakeBuildable()
    {
        rend.material = matBuildable;
        matOrg = matBuildable;
        isBuildable = true;
    }

    void OnMouseDown()
    {
        if (isPurchase() && isBuildable)
        {
            purchaseManager.OnTileClicked(transform, ref haveBuilding, ref isBuildable);
        }
        else if (isBulldoze()  && isBuildable)
        {
            Destroy(building.GetGameObject());
            resourceManager.MoneyGained(building.GetCost());
            building = null;
            haveBuilding = false;
        }
        else if (!isBuildable)
        {
            Debug.Log("Not buildable");
            purchaseManager.OnTileClicked(this);
        }
    }

    private bool isBulldoze()
    {
        return stateManager.currentState.type == StateType.Bulldoze;
    }

    private bool isPurchase()
    {
        return stateManager.currentState.type == StateType.Purchase;
    }

    void OnMouseEnter()
    {
        rend.material = matHoverOver;
    }

    void OnMouseExit()
    {
        rend.material = matOrg;
    }
}
