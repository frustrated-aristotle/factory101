using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PurchaseManager : MonoBehaviour
{
    //This script is responsible for validation of purchase process.
    public IPurchasable selectedPurchasable = null;

    private RoadManager roadManager;
    private ResourceManager resourceManager;
    [SerializeField] private float buildableCost = 5000f;

    private void Start()
    {
        roadManager = GetComponent<RoadManager>();
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    
    //Changes the buildable on Purchase Panel via buttons.
    public void ChangePurchasable(GameObject buildable)
    {
        selectedPurchasable = buildable.GetComponent<IPurchasable>();
    }

    public void ChangePurchasable(BuildableMaker a)
    {
        selectedPurchasable = a;
        Debug.Log("SelectedPurchasable");
    }

    //When the state is changed, selected buildable should be cleared instantly.
    public void ClearPurchasable()
    {
        selectedPurchasable = null;
    }

    public void OnTileClicked(Transform tr, ref bool hasBuilding, ref bool isBuildable)
    {
        Vector3 pos = tr.position;
        //Make it visible by changing its Z position.
        pos.z = -3;
        if (selectedPurchasable != null)
        {
            PurchasableType type = selectedPurchasable.GetPurchasableType();
            //We should check if the purchasable type is a building or not.
            float cost = selectedPurchasable.GetCost();
            if(type == PurchasableType.Road)
            {
                if (hasBuilding)
                {
                    roadManager.OnNodeSelected(tr);
                }
            }
            else if (type != PurchasableType.Vehicle && hasBuilding == false)
            {
                if (resourceManager.Money >= cost)
                {
                    resourceManager.MoneyLoosed(cost);
                    GameObject building =  Instantiate(selectedPurchasable.GetGameObject(), pos, quaternion.identity);
                    tr.GetComponent<Tile>().building = building.GetComponent<IPurchasable>();
                    hasBuilding = true;
                }
               
            }
           
        }
    }

    public void OnTileClicked(Tile tile)
    {
        float cost = selectedPurchasable.GetCost();
        // if (resourceManager.Money >= cost)
        if (true)
        {
            resourceManager.MoneyLoosed(cost);
            tile.MakeBuildable();
        }
    }

    public void OnTileClicked(ref Tile tile)
    {
        if (!tile.isBuildable)
        {
            if (resourceManager.Money >= buildableCost)
            {
                resourceManager.MoneyLoosed(buildableCost);
                tile.MakeBuildable();
            }
        }
    }

    public GameObject OnTileClicked(Vector3 start)
    {
        Vector3 temp = start;
        temp.z = -3;
        if (selectedPurchasable != null)
        {
            PurchasableType type = selectedPurchasable.GetPurchasableType();
            if (type == PurchasableType.Vehicle)
            {
                if (resourceManager.Money >= selectedPurchasable.GetCost())
                {
                    resourceManager.MoneyLoosed(selectedPurchasable.GetCost());
                    return Instantiate(selectedPurchasable.GetGameObject(), temp, quaternion.identity);
                }
                else
                    return null;
            }
        }
        return null;
    }
}
