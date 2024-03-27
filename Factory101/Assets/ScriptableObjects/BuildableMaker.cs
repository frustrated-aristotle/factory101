using UnityEngine;

[CreateAssetMenu(menuName = "Buildable", fileName = "Buildable")]
public class BuildableMaker : ScriptableObject, IPurchasable
{
    [SerializeField] private float cost;
    public PurchasableType GetPurchasableType()
    {
        return PurchasableType.Buildable;
    }

    public float GetCost()
    {
        return cost;
    }

    public GameObject GetGameObject()
    {
        return null;
    }
}
