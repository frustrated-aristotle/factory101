using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollide : MonoBehaviour
{
    public float canStore=20;
    public float stored;

    private Collision2D lastCol;
    
    private VehicleMovement vehicleMovement;
    void Start()
    {
        vehicleMovement=GetComponent<VehicleMovement>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == vehicleMovement.realHome)
        {
            Fill(col);
        }
        else if(col.gameObject == vehicleMovement.realTarget)
        {
            Empty(col);
        }
        if(col.gameObject.tag == "Building" /*&& col != lastCol*/)
        {
            ChangeTarget();       
        }
        col=lastCol;
    }

    public void ChangeTarget()
    {
        //transform.localRotation= new Quaternion(0,180,0, 0);
        vehicleMovement.helder=vehicleMovement.target;
        vehicleMovement.target=vehicleMovement.home;
        vehicleMovement.home=vehicleMovement.helder;
    }

    private void Empty(Collision2D col)
    {
        //If we want an unlimited storage, then this is okay but if is not, we need to change it.
        col.gameObject.GetComponent<Storage>().resA += stored;
        stored = 0;
    }
    private void Fill(Collision2D col)
    {
        /*
            We need to store all the produced things in vehicle.
                If there is more resB than the amount of vehicle can store
                    the vehicle stores as its maximum storage cappacity
                    Decrease that exact amount from producer.
                If there is less resB than the amoun to vehicle can store
                    the vehilce stores that certain amount.
                    Decrease that exact amount from producer.
        */
        if(col.gameObject.GetComponent<Storage>().resB > canStore)
        {
            stored=canStore;
            col.gameObject.GetComponent<Storage>().resB -= canStore;  
            //There is some shit corpes.
            {/*
            //col.gameObject.GetComponent<Storage>().resB -= stored;
            if(canStore >= col.gameObject.GetComponent<Storage>().resB)
            {
                stored= col.gameObject.GetComponent<Storage>().resB;
            }
            else
            {
                //It stores the maximum amount of thing that a vehicle can store.
                stored=canStore;
            }
            */}
        }
        else
        {
            stored+=col.gameObject.GetComponent<Storage>().resB;
            col.gameObject.GetComponent<Storage>().resB -= stored;
        }
    }
}
