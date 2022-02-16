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
    void Start()
    {
        str=GetComponent<Storage>();
        InvokeRepeating("ProduceThings", 0f, 1f);
    }
    public void ProduceThings()
    {

        Debug.Log("P1 works");
        if (str.resA >= producingSpendAmount)
        {
            Debug.Log("P2 works");

            str.resA-= producingSpendAmount;
            str.resB+= producingCreateAmount;

            Debug.Log("resA:" + str.resA);

        }
    }
}
