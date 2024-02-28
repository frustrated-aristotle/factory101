using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour, IPurchasable
{
    public PurchasableType GetPurchasableType()
    {
        return PurchasableType.Storage;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
}
