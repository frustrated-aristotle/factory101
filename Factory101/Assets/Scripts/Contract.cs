using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    public float orderedGoods;
    public float deliveredGoods=0;
    public float deliverTime;
    
    public float baseOrderedGoods;
    public float baseDeliverTime;

    public float baseGain;

    //We need to define additional amount randomly, we want to make game more enjoyable with random events.
    public float additionalAmount;
    
    public int type;
    public bool isSellected;
    //We need to multiply those values by their type's index.
}