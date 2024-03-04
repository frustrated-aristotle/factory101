using UnityEngine;

public interface IPurchasable
{
    public PurchasableType GetPurchasableType();

    public float GetCost();
    public GameObject GetGameObject();
    
}
