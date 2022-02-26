using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    //* to gameManager
    
    public GameObject home;
    public  GameObject target;

    public Vector3 addPos;
    public bool areRoadsCompleted;
    public LineRenderer lr;

    void Start()
    {
        
    }
    public void BuildRoads()
    {
        lr.SetPosition(0, home.transform.position);
        lr.SetPosition(1, target.transform.position);
    }
    /*
        +This script will run when the player sellected a node to build a road from it.
        +Assign the first node as home and the second as target.
        Instantiate roads from home to target. Their position will be next to the previous road until colliding with target.
        -combine all of the road pieces.
            make them one single road.
            Collided roads will be a part of new Road.
            To do so, player can easily sellect the road that he wants to place its own vehicles.
    */
}
