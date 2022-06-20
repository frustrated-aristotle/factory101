using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int lvl=1;
    private int vehIndex=0;
    public int type;


    public float cost;
    public float upkeepCost;
    public float worth;
    float bulldoseGain;

    public bool canCreateARoad;
    public bool isFullingAVehicle=false;

    public  Building b1, b2, b3, b4;
    public  Building[] connectedBuildings = new Building[5]; 
    private Produce p;
    public  Improvement imp;
    private ImprovementMainHandler impmh;
    public  FactoryResources playerAsFactory;
    public  GameObject vehicleStoring;
    public  GameObject[] vehicles;
    

    void Start()
    {
        imp.isThisABuilding=true;
        imp.fr=playerAsFactory;
        playerAsFactory = GameObject.Find("Factory").GetComponent<FactoryResources>();
        InvokeRepeating("Upkeep", 60f, 60f);
        p = GetComponent<Produce>();
    }

    public void forText()
    {
        Debug.Log("Its Woking and the name: " + name);
    }

    private void IncreaseFactoryResourcesLevel()
    {
        switch(type)
        {
            case 1:
            playerAsFactory.lvlExcavator++;
            lvl=playerAsFactory.lvlExcavator;
                break;
            case 2:
            playerAsFactory.lvlProcessor++;           
            lvl=playerAsFactory.lvlProcessor;
                break;
            case 3:
            playerAsFactory.lvlExporter++;
            lvl=playerAsFactory.lvlExporter;
                break;
        }
        
    }

    public bool CostDeal()
    {
        if((playerAsFactory.money - imp.impCost) >=0)
        {
            Debug.Log("aa");
            playerAsFactory.money -= imp.impCost;
            return true;
        }
        else
        {
            Debug.Log("Money is not enough");
        }
        return false;
    }
    float BulldoseGain()
    {
        bulldoseGain = cost * 3 / 4;
        return bulldoseGain;
    }
    
    void Upkeep()
    {
        playerAsFactory.money -= upkeepCost;
    }

    public void BulldoseIt()
    {
        playerAsFactory.money += BulldoseGain();
    }

    public void AddVehicle(GameObject vehicle)
    {
        vehicles[vehIndex]=vehicle;
        vehIndex++;
    }

    public bool CheckIfThereIsTheObject(GameObject toCompare)
    {
        foreach(Building b in connectedBuildings)
        {

            if(b == toCompare.GetComponent<Building>())
            return false;
        }
        return true;
    }

    public void IncreaseImprovement(Improvement i)
    {
        int a = 0;
        Debug.Log("A level thing is working");
        if(CostDeal())
        {
            //i.Display(impmh.texts[a], impmh.b[a]);
            Debug.Log("Arkadaşım improvement gerçekleşti.");
            p= GetComponent<Produce>();
            //FactoryRes level thing
            IncreaseFactoryResourcesLevel();
            a++;
            p.spendAmount  *= lvl * 3 / 4;  
            p.createAmount *= lvl;
        }
    }
}