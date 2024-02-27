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
        Debug.Log("Purchasable has been changed!: " + selectedPurchasable.GetGameObject().name);
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
        pos.z = -1;
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
                Debug.Log("Huh?");
                GameObject building =  Instantiate(selectedPurchasable.GetGameObject(), pos, quaternion.identity);
                tr.GetComponent<Tile>().building = building.GetComponent<IPurchasable>();
                hasBuilding = true;
            }
        }
    }
}
