using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMainScript : MonoBehaviour
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
    
    void Start()
    {
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
        if(buyAndPlaceTheBuildings.GameModeCheck())
        buyAndPlaceTheBuildings.BuyAndPlaceTheBuilding(this);
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
