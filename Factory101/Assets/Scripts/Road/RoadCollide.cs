using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCollide : MonoBehaviour
{
    //*to roads
    public GameObject home;
    public GameObject target;
    public RoadBuilder roadBuilder;
    bool isUsed;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == target && !isUsed)
        {
            roadBuilder.areRoadsCompleted=true;
        }
    }
}
