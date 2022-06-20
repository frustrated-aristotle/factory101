using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Produce : MonoBehaviour
{
    public  Storage str;
    public  float spendAmount;
    public  float createAmount;
    private float input;
    private float output;

    public  int producerType;
    public  int type;
    public  int id;
 
    public  bool isContractFulfilled;
    public  bool haveContract;
    
    //0= excavator, 1= processor, 2= exporter

    public  GameObject gm;
     
    public  TextMeshProUGUI genBehTxt;
 
 
    public  FactoryResources fr;
    public  ContractManager cm;
    public  Holder hold;

    void Start()
    {
        str=GetComponent<Storage>();
        hold = GameObject.Find("Game").GetComponent<Holder>();
        id=hold.id;
        hold.id++;
        genBehTxt = GameObject.Find("General Case Text").GetComponent<TextMeshProUGUI>();
        fr = GameObject.Find("Factory").GetComponent<FactoryResources>();
        gm = GameObject.Find("GameManager");
        
        cm=gm.GetComponent<ContractManager>();
        
        ArrangeCreateAndSpendAmount();
        InvokeRepeating("ProduceMethod", 0f, 1f);
    }

    public void ArrangeCreateAndSpendAmount()
    {
        fr.FirstCreatedLevel(type, this);

    }

    void ProduceMethod()
    {
        if(str.input >= spendAmount && producerType != 0)
        {
            //Destroy the input as much as the spendAmount
            switch (producerType)
            {
                case 1:
                    str.input -= spendAmount;
                    str.output += createAmount;
                    break;
                case 2:
                    if(str.output >= createAmount)
                        str.output -= createAmount;
                    else
                    str.input -= spendAmount;
                    DeliverGoods();
                    break;
            }
        }
        else if(producerType==0)
        {
            str.output += createAmount;
        }
        else if(str.input < spendAmount && producerType == 2 &&
                str.output >= spendAmount )
        {
            str.output -= createAmount;
            DeliverGoods();   
        }
    }
    void DeliverGoods()
    {
        //If there is a contract to fulfill, add the created amount of goods to the deliveredGoods of it. Gain Money.
        if(cm.isContractSellected)
        {
            if (!cm.sellectedContract.isDelivered)
            {
                cm.sellectedContract.deliveredGoods += createAmount;
                Debug.Log("de: "+cm.sellectedContract.deliveredGoods + "ord: " + cm.sellectedContract.orderedGoods);
                fr.money += createAmount;
                cm.DisplayDeliveredGoods();
                if(cm.sellectedContract.deliveredGoods >= cm.sellectedContract.orderedGoods)
                {
                    //Contract is fulfilled;
                    cm.Fulfilled();
                }
            }
            else
            {
                Debug.Log("ekse");
                cm.Fulfilled();
            }
        }
        //If there is no contract to fulfill, store them in the storage of exporter. To do so, you can not make money.
        else
        {
            str.output=createAmount;
        }
    }
}