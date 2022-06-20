using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownV : MonoBehaviour
{
    [SerializeField]float addtVector3Val = 5;

    private Vector3 transformPos;

    public  GameObject vehicle;
    public  Road road;
    private GameObject GM;
    private FactoryResources fr;


    void Start()
    {
        GM=GameObject.Find("GameManager");
        fr=GameObject.Find("Factory").GetComponent<FactoryResources>();
        Debug.Log("Go: " + vehicle + " --- " +this.gameObject.name); 
    }
    void OnMouseDown()
    {
        if(CheckIfThePlayerCanBuy())
        {
            //Assign vehicle's target and home
    //        placeTheVehicle.AssignHomeAndTarget(gameObject.transform.parent.gameObject);
            vehicle.GetComponent<VehicleMovement>().realHome = road.home;
            vehicle.GetComponent<VehicleMovement>().realTarget = road.target;
            Instantiate(vehicle, TP(), Quaternion.identity);
            Debug.Log("Home: " + vehicle.GetComponent<VehicleMovement>().realHome);
            AddVehicle();
        }
    }

    bool CheckIfThePlayerCanBuy()
    {
        if(vehicle.GetComponent<VehicleMovement>().cost <= fr.money)
        {
            fr.money -= vehicle.GetComponent<VehicleMovement>().cost;
            return true;
        }
        return false;
    }
    Vector3 TP()
    {
        transformPos = vehicle.GetComponent<VehicleMovement>().realHome.transform.position;
        return transformPos;
    }
    public void AddVehicle()
    {
        vehicle.GetComponent<VehicleMovement>().realHome.GetComponent<Building>().AddVehicle(vehicle);
        vehicle.GetComponent<VehicleMovement>().realTarget.GetComponent<Building>().AddVehicle(vehicle);
    }
}