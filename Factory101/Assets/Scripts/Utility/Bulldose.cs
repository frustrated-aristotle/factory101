using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldose : MonoBehaviour
{
    public Bulldose gm;
    FactoryResources fr;
    bool isBulldoseOn;
    Building b;
    void Start()
    {
        fr= GameObject.Find("Factory").GetComponent<FactoryResources>();
        b= GetComponent<Building>();
        gm = GameObject.Find("GameManager").GetComponent<Bulldose>();
    } 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !isBulldoseOn)
        {
            isBulldoseOn=true;
        }
        else if(Input.GetKeyDown(KeyCode.Z) && isBulldoseOn)
        {
            isBulldoseOn=false;
        }
    }
    void OnMouseDown()
    {
        if(gm.isBulldoseOn)
        {
            GetComponent<Building>().BulldoseIt();
            DestroyVehiclesAndGainTheirMoney();
            Destroy(this.gameObject);
        }
    } 
    
    void DestroyVehiclesAndGainTheirMoney()
    {
        foreach(GameObject vehicle in b.vehicles)
        {
            fr.money += vehicle.GetComponent<VehicleMovement>().cost;
            Destroy(vehicle);
        }
    }
}
