using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTheVehicle : MonoBehaviour
{
    
    public bool isRoadBuildingNow;
    public GameObject vehicleToPlace;
    
    public void AssignHomeAndTarget(GameObject road)
    {
        // vehicleToPlace.GetComponent<VehicleMovement>().realHome   = road.GetComponent<Road>().home;
        // vehicleToPlace.GetComponent<VehicleMovement>().realTarget = road.GetComponent<Road>().target;
        Debug.Log("name of veh: "+vehicleToPlace.name);
        //vehicleToPlace.GetComponent<VehicleMovement>().CheckRealHomeAndTarget();
    }
}
