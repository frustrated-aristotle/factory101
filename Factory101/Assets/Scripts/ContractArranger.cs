using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractArranger : MonoBehaviour
{
    //* To the GameManager
    //There must be at least 3 contract.
    public Contract c1;
    public Contract c2;
    public Contract c3;
    public Contract sellectedContract;

    void Start()
    {
        SellectTheContract();
        SetContracts();
    }
    void SetContracts()
    {
        c1.type=1;
        c1.orderedGoods = c1.baseOrderedGoods * c1.type; 
        c1.baseGain *= c1.type;
        c1.deliverTime = c1.baseDeliverTime * c1.type;
        
        c2.type=2;
        c2.orderedGoods = c2.baseOrderedGoods * c2.type;
        c2.baseGain *= c2.type;  
        c2.deliverTime = c2.baseDeliverTime * c2.type;
        
        c3.type=3;
        c3.orderedGoods = c3.baseOrderedGoods * c3.type;
        c3.baseGain *= c3.type;
        c3.deliverTime = c3.baseDeliverTime * c3.type;
        //We need to define their additional amount.
    }

    void SellectTheContract()
    {
        sellectedContract=c1;
        Debug.Log("sellected contract is: "+sellectedContract);
    }
}
