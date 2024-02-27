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

    public IPurchasable building;
    void Start()
    {
        purchaseManager = FindObjectOfType<PurchaseManager>();
        stateManager = FindObjectOfType<StateManager>();
        rend = GetComponent<Renderer>();       
        buyAndPlaceTheBuildings = GameObject.FindObjectOfType<BuyAndPlaceTheBuildings>();
        if(isBuildable)
        {
            MakeBuildable();
        }

        newTP = new Vector3(transform.position.x, transform.position.y, -3);
    }

    public void MakeBuildable()
    {
        rend.material = matBuildable;
        matOrg = matBuildable;
    }

    void OnMouseDown()
    {
        if (isPurchase() && isBuildable)
        {
            purchaseManager.OnTileClicked(transform, ref haveBuilding);
        }
        else
        {
            Debug.Log("Else working for onmousedown in tile script");
        }
        /*if(buyAndPlaceTheBuildings.GameModeCheck())
            
            buyAndPlaceTheBuildings.BuyAndPlaceTheBuilding(this);*/
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
