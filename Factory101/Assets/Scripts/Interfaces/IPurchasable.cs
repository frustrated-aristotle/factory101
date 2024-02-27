using UnityEngine;

public interface IPurchasable
{
    public PurchasableType GetPurchasableType();
    public GameObject GetGameObject();
}
