using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollide : MonoBehaviour
{
    public float canStore=20;
    public float stored;

    public bool isStoring=false;

    private Building b;
    private Collision2D lastCol;
    
    private VehicleMovement vehicleMovement;

    void Start()
    {
        b=GetComponent<Building>();
        vehicleMovement=GetComponent<VehicleMovement>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == vehicleMovement.realHome )
        {
            Fill(col);
        }
        else if(col.gameObject == vehicleMovement.realTarget)
        {
            if(vehicleMovement.realTarget.GetComponent<Produce>().producerType - 1== vehicleMovement.realHome.GetComponent<Produce>().producerType)
            {
                CheckIfItIsFirstCreated();
                Empty(col);
            }
            else
            Debug.Log("Else is working now");
        }
        if(col.gameObject.tag == "Building" || col.gameObject.tag == "Exporter")
        {
            ChangeTarget();       
        }
        col=lastCol;
    }

    private void CheckIfItIsFirstCreated()
    {
        if(vehicleMovement.isCreatedFirstTime)
        vehicleMovement.UnignoreTheCollider();
        vehicleMovement.isCreatedFirstTime = false;
    }

    public void ChangeTarget()
    {
        vehicleMovement.helder=vehicleMovement.target;
        vehicleMovement.target=vehicleMovement.home;
        vehicleMovement.home=vehicleMovement.helder;
    }

    private void Empty(Collision2D col)
    {
        col.gameObject.GetComponent<Storage>().input += stored;
        stored = 0;
    }
    private void Fill(Collision2D col)
    {
        if(col.gameObject.GetComponent<Storage>().output >= canStore)
        {
            col.gameObject.GetComponent<Storage>().output -= canStore;
            stored = canStore;
        }
        else
        {
            stored = col.gameObject.GetComponent<Storage>().output;
            col.gameObject.GetComponent<Storage>().output = 0;
        }
       /* if(col.gameObject.GetComponent<Storage>().resB > canStore)
        {
            stored=canStore;
            col.gameObject.GetComponent<Storage>().resB -= canStore;
        }
        else
        {
            stored+=col.gameObject.GetComponent<Storage>().resB;
            col.gameObject.GetComponent<Storage>().resB -= stored;
        }
        */      
    }
}
