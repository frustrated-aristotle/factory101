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
    void Start()
    {
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
            }
            else
            {
                Debug.Log("Else must be working");
                str.resB+= producingCreateAmount;
            }
        }
    }
}
