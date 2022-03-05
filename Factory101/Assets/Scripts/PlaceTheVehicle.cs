using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTheVehicle : MonoBehaviour
{
    /*
        We have to choose vahicle in shop menu.
        Player needs to choose the road that she will use the vehicle
        The road is basicly a line renderer. It has collider. When we click on it;
            Its real target and home will be asign as that vehichle's target and home and it will be instantiated at the home.
    */
    public GameObject roadToBuild;
    public void BuildARoad(GameObject vehicle)
    {
        GetComponent<OnMouseDownV>().isRoadBuildingNow=true;
        roadToBuild=vehicle;
    }
}
