using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Producer : MonoBehaviour
{
    [SerializeField]
    protected int spendAmount;
    [SerializeField]
    protected int createAmount;
    [SerializeField]
    protected float produceTimeRate;

    protected Storage storage;
    
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
}