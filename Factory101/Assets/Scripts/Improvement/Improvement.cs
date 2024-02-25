using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Improvement", fileName = "Improvement")]
public class Improvement : ScriptableObject , IPayment
{
    public int type;

    private float a;
    public float mainImpCost=5000;
    public float impCost;

    public bool isThisABuilding;
    

    //Buildings
    Building[] buildings;
    ImprovementMainHandler impMH;
    VehicleMovement[] vehicles;
    Producer p;
    public FactoryResources fr;

    public void IncreaseCar()
    {
        vehicles = FindObjectsOfType<VehicleMovement>();
        if (vehicles != null)
        {
            foreach(VehicleMovement vehicle in vehicles)
            {
                ArrangeTheCost(vehicle.level);
                vehicle.IncreaseImprovement();
            }
        }
    
    }
    public void Increase()
    {
        buildings = FindObjectsOfType<Building>();
        foreach(Building b in buildings)
        {
            if(b.imp.type == type)
            {
                ArrangeTheCost(b.lvl);
                b.IncreaseImprovement(this);
            }
            else
            {
                Debug.Log("Aptal");
            }
        }
    }

    private void ArrangeTheCost(int lvl)
    {
        impCost = mainImpCost * lvl;
    }

    public void Display(Text costText, string s)
    {
        impMH = GameObject.Find("GameManager").GetComponent<ImprovementMainHandler>();
        Debug.Log("cost text1: " + costText.text);
        costText = impMH.texts[type-1];
        costText.text= s+ "\n" +((int)impCost).ToString();;
        Debug.Log("cost text2: " + costText.text);
    }
}
