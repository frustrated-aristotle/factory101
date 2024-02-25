using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FactoryResources : MonoBehaviour
{
    public float money;
    public float factoryWorth;

    public int totalCompletedContract;
    //-Last level that a go reached:
    public int lvlExporter=1;    
    public int lvlExcavator=1;
    public int lvlVehicle=1;    
    public int lvlProcessor=1;    

    public Text moneyText;
    void Update()
    {
        DisplayMoney();
    }
    void DisplayMoney()
    {
        moneyText.text="Money: " + money.ToString();
    }

    public void FirstCreatedLevel(int type, Producer p)
    {/*
        switch(type)
        {
            case 1:
                p.producingCreateAmount *= lvlExcavator;
                p.producingSpendAmount *= lvlExcavator * 3/4;
                p.GetComponent<Building>().lvl = lvlExcavator;
                break;
            case 2:
                p.producingCreateAmount *= lvlProcessor;
                p.producingSpendAmount *= lvlProcessor * 3/4;
                p.GetComponent<Building>().lvl = lvlProcessor;
                break;
            case 3:
                p.producingCreateAmount *= lvlExporter;
                p.producingSpendAmount *= lvlExporter * 3/4;
                p.GetComponent<Building>().lvl = lvlExporter;
                break;
            case 4:
                p.producingCreateAmount *= lvlVehicle;
                p.producingSpendAmount *= lvlVehicle * 3/4;
                p.GetComponent<Building>().lvl = lvlVehicle;
                break;
        }
        */
    }
}