using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Producer : MonoBehaviour, IPurchasable
{
    [SerializeField]
    protected int spendAmount;
    [SerializeField]
    protected int createAmount;
    [SerializeField]
    protected float produceTimeRate;

    protected Storage storage;

    [SerializeField]
    protected PurchasableType purchasableType;
    
    void Start()
    {  
        storage=GetComponent<Storage>();
        
        InvokeRepeating(nameof(ProduceTheOutcome), 0f, produceTimeRate);
    }

    protected virtual void ProduceTheOutcome() {}
   
    protected bool CanProduce()
    {
        if (spendAmount <= storage.Source)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public PurchasableType GetPurchasableType()
    {
        return purchasableType;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
}