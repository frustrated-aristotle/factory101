using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownS : MonoBehaviour
{
    public RoadBuilder rb;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        //If it is for creating roads:
        if(rb.home==null)
        {
            rb.home=this.gameObject;
        }
        else if(rb.target==null)
        {
            rb.target=this.gameObject;
            rb.BuildRoads();
            ClearNodes();
        }
    }
    void ClearNodes()
    {
        rb.home=null;
        rb.target=null;
    }
}
