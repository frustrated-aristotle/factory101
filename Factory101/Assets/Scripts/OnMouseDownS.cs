using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownS : MonoBehaviour
{
    public int pairIndex=0;
    public bool isRoadBuilding;

    public GameObject[] pairs;
    public GameObject pair1;
    public GameObject pair2;
    public GameObject pair3;
    public GameObject pair4;
    private GameObject gm;
    public RoadBuilder rb;
    private UIController ui;
    void Start()
    {
        pairs = new GameObject[4];
        gm=GameObject.Find("GameManager"); 
        rb=gm.GetComponent<RoadBuilder>();
        ui = gm.GetComponent<UIController>();
    }
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if(ui.gameMode == "Road")
        {
            //If it is for creating roads:
            if(rb.home==null)
            {
                rb.home=this.gameObject;
            }
            else if(rb.target==null && this.gameObject != rb.home)
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
