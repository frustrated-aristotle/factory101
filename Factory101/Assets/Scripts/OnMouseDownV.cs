using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownV : MonoBehaviour
{
    PlaceTheVehicle placeTheVehicle;
    public bool isRoadBuildingNow;
    void OnMouseDown()
    {
        if(isRoadBuildingNow)
        {
            Instantiate(placeTheVehicle.roadToBuild, GetComponent<Road>().home.transform.position, Quaternion.identity);
            placeTheVehicle.GetComponent<VehicleMovement>().realHome= GetComponent<Road>().home;
            placeTheVehicle.GetComponent<VehicleMovement>().realTarget=GetComponent<Road>().target;
        }
    }
}
