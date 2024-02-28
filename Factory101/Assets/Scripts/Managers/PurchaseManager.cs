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
    private void Start()
    {
        roadManager = GetComponent<RoadManager>();
    }

    //Changes the buildable on Purchase Panel via buttons.
    public void ChangePurchasable(GameObject buildable)
    {
        selectedPurchasable = buildable.GetComponent<IPurchasable>();
    }

    //When the state is changed, selected buildable should be cleared instantly.
    public void ClearPurchasable()
    {
        selectedPurchasable = null;
    }

    public void OnTileClicked(Transform tr, ref bool hasBuilding)
    {
        Vector3 pos = tr.position;
        //Make it visible by changing its Z position.
        pos.z = -3;
        if (selectedPurchasable != null)
        {
            PurchasableType type = selectedPurchasable.GetPurchasableType();
            //We should check if the purchasable type is a building or not.
            if(type == PurchasableType.Road)
            {
                if (hasBuilding)
                {
                    roadManager.OnNodeSelected(tr);
                }
            }
            else if (type != PurchasableType.Vehicle && hasBuilding == false)
            {
                GameObject building =  Instantiate(selectedPurchasable.GetGameObject(), pos, quaternion.identity);
                tr.GetComponent<Tile>().building = building.GetComponent<IPurchasable>();
                hasBuilding = true;
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
                return Instantiate(selectedPurchasable.GetGameObject(), temp, quaternion.identity);
            }
        }
        return null;
    }
}
