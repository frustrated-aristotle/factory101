using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produce : MonoBehaviour
{
    Storage str;
    public float producingSpendAmount;
    public float producingCreateAmount;
    float resA;
    float resB;

    public int producerType;
    public FactoryResources fr;
    //0= excavator, 1= processor, 2= exporter
    
    public ContractArranger contractArranger;
    void Start()
    {
        fr=GameObject.Find("Factory").GetComponent<FactoryResources>();
        contractArranger=GameObject.FindGameObjectWithTag("Contract Arranger").GetComponent<ContractArranger>();
        str=GetComponent<Storage>();
        InvokeRepeating("ProduceThings", 0f, 1f);
    }
    public void ProduceThings()
    {
        if (str.resA >= producingSpendAmount)
        {
            str.resA-= producingSpendAmount;
            if (producerType==2)
            {
                fr.money += producingCreateAmount;
                //If goods is exported, we need to say here that we exported that much goods.
                contractArranger.sellectedContract.deliveredGoods += producingCreateAmount;

                if(contractArranger.sellectedContract.deliveredGoods >= contractArranger.sellectedContract.orderedGoods)
                {
                    Debug.Log("Contract is completed.");
                    contractArranger.sellectedContract=null;
                }
            }
            else
            {
                str.resB+= producingCreateAmount;
            }
        }
    }
}
