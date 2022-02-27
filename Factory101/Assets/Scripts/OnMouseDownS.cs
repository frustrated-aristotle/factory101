using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownS : MonoBehaviour
{
    public bool isRoadBuilding;
    public RoadBuilder rb;

    public GameObject[] pairs;
    public GameObject pair1;
    public GameObject pair2;
    public GameObject pair3;
    public GameObject pair4;

    public int pairIndex=0;

    void Start()
    {
        pairs = new GameObject[4];
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
       // if(isRoadBuilding)
        {
            //If it is for creating roads:
            if(rb.home==null)
            {
                rb.home=this.gameObject;
            }
            else if(rb.target==null /*&& this != rb.home*/)
            {
                rb.target=this.gameObject;
                rb.BuildRoads();
                ClearNodes();
            }
        }

    }
    void ClearNodes()
    {
        rb.home=null;
        rb.target=null;
    }
}
