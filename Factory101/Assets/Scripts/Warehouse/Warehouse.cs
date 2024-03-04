using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour, IPurchasable
{
    [SerializeField] private float cost;

#region IPurchasable
    public PurchasableType GetPurchasableType()
    {
        return PurchasableType.Storage;
    }

    public float GetCost()
    {
        return cost;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }    
#endregion

}
