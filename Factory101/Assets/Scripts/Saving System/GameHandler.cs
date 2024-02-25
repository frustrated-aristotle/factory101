using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{   
    private Contract c1,c2,c3;
    private FactoryResources fr;
    private LandBaseScript[] lands;
    private GameObject[] vehicles;
    public  GameObject expPref, excPref, proPref, vehPref;
    private void Awake()
    {
        SaveSystem.Init();
    }
    private void Start()
    {
    }
    private void Get()
    {
        fr = GameObject.Find("Factory").GetComponent<FactoryResources>();
        c1 = GameObject.Find("Contract1").GetComponent<Contract>(); 
        c2 = GameObject.Find("Contract2").GetComponent<Contract>();
        c3 = GameObject.Find("Contract2").GetComponent<Contract>();
    }
    public void Save(){
        Get();
        SaveObject saveObject = new SaveObject
        {
            money = fr.money,
            orderedGoods1 = c1.orderedGoods,
            orderedGoods2 = c2.orderedGoods,
            orderedGoods3 = c3.orderedGoods,
            deliverTime1 = c1.deliverTime,
            deliverTime2 = c2.deliverTime,
            deliverTime3 = c3.deliverTime,
            deliveredGoods1 = c1.deliveredGoods,
            deliveredGoods2 = c2.deliveredGoods,
            deliveredGoods3 = c3.deliveredGoods,
            gain1 = c1.gain,
            gain2 = c2.gain,
            gain3 = c3.gain,
            faul1 = c1.faul,
            faul2 = c2.faul,
            faul3 = c3.faul,
            contractsCmpltd1 = c1.contractsCmpltd,
            contractsCmpltd2 = c2.contractsCmpltd,
            contractsCmpltd3 = c3.contractsCmpltd,
            isSellected1 = c1.isSellected,
            isSellected2 = c2.isSellected,
            isSellected3 = c3.isSellected, 
            excavatorAmount = 0, 
            processorAmount = 0,
            exporterAmount = 0, 
            vehicleAmount = 0
        };
        SaveLands(saveObject);
        SaveBuildings(saveObject);
        SaveVehicles(saveObject);

        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        Debug.Log("Saved!");
    }

    private void SaveLands(SaveObject saveObject)
    {
        lands = GameObject.FindObjectsOfType<LandBaseScript>();
        saveObject.index=0;//*Lands
        for(int i = 0; i < lands.Length; i++)
        {
            if(lands[i].isBought)
            {
                saveObject.indices[saveObject.index] = i; 
                saveObject.index++;
            }            
        }   
    }
    
    private void SaveBuildings(SaveObject saveObject)
    {
        //*Buildings
        /*{
            Producer[] prd = GameObject.FindObjectsOfType<Producer>();
            int a=0;
            int b=a;
            int c=a;
            if(prd != null)
            {
                foreach (var p in prd)
                {
                    if(p.producerType == 0)
                    {
                        Array.Resize(ref saveObject.excPos, prd.Length);
                        saveObject.excavatorAmount++;
                        saveObject.excPos[a] = p.transform.position;
                        a++;
                        saveObject.buildingAmount++;
                    }
                    else if(p.producerType == 1)
                    {

                        Array.Resize(ref saveObject.proPos, prd.Length);
                        saveObject.processorAmount++;
                        saveObject.proPos[b] = p.transform.position;
                        b++;
                        saveObject.buildingAmount++;
                    }
                    else if(p.producerType == 2)
                    {
                        Array.Resize(ref saveObject.expPos, prd.Length);
                        saveObject.exporterAmount++;
                        saveObject.expPos[c] = p.transform.position;
                        c++;
                        saveObject.buildingAmount++;
                    }
                }
            }           
        }*/
    }

    private void SaveVehicles(SaveObject saveObject)
    {
        //Find all of existing vehicles. Assign them as the member of an array of gameObjects.
        //Foreach member of that array, save their positions to the vehPos array.
        int i=0;
        vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        saveObject.vehicleAmount = vehicles.Length; 
        foreach (var v in vehicles)
        {
            Array.Resize(ref saveObject.vehPos, saveObject.vehicleAmount);
            Array.Resize(ref saveObject.realHome, saveObject.vehicleAmount);
            Array.Resize(ref saveObject.realTarget, saveObject.vehicleAmount);
            saveObject.vehPos[i]=v.transform.position;
            //saveObject.realHome[i]=v.GetComponent<VehicleMovement>().realHome.GetComponent<Producer>().id;
            //saveObject.realTarget[i]=v.GetComponent<VehicleMovement>().realTarget.GetComponent<Producer>().id;
            i++;
            Debug.Log("sdss");
        }
    }

    private void Load() {
        // Load
        string saveString = SaveSystem.Load();
        if (saveString != null) {

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            //Setting Values
            fr.money = saveObject.money;

            //* For areas
            {
                foreach(int i in saveObject.indices)
                {
                    lands = GameObject.FindObjectsOfType<LandBaseScript>();
                    lands[i].isBought=true;
                }
            }
            //*For Contracts
            LoadBuildings(saveObject);
            LoadContract(saveObject);
            LoadVehicles(saveObject);
            Debug.Log("end of load");
        } 
        else 
        {
            Debug.Log("No Save!");
        }
    }
    
    private void LoadVehicles(SaveObject saveObject)
    {
        GameObject[] vehicle = GameObject.FindGameObjectsWithTag("Vehicle");
        if(vehicle != null)
        {
            foreach (var v in vehicle)
            {
                Destroy(v);
            }

            for (int i = 0; i < saveObject.buildingAmount; i++)
            {
                //vehPref = GameObject.Find("Game").GetComponent<Holder>().v;
                Producer[] prdc = GameObject.FindObjectsOfType<Producer>();
                /*foreach (var p in prdc)
                {
                    Debug.Log("p : " + p.name + "p's id: " + p.id);
                    if(p.id==saveObject.realHome[i])
                    {
                        Debug.Log("f1");
                        vehPref.GetComponent<VehicleMovement>().realHome=p.gameObject;
                    }
                    if(p.id==saveObject.realTarget[i])
                    {
                        Debug.Log("f2");
                        vehPref.GetComponent<VehicleMovement>().realTarget=p.gameObject;
                    }

                }*/
                vehPref.GetComponent<VehicleMovement>().isLoaded = true;
                Instantiate(vehPref, saveObject.vehPos[i], Quaternion.identity);
            }
        }
    }

    private void  LoadBuildings(SaveObject saveObject)
    {
        int a=0;
        int b=0;
        int c=0;
        Producer[] producer = GameObject.FindObjectsOfType<Producer>();
        
        if(producer != null)
        {
            Debug.Log("nnot null");
            foreach (var p in producer)
            {
                Destroy(p.gameObject);
            }
            Holder hold = GameObject.Find("Game").GetComponent<Holder>();
            excPref = hold.a;
            proPref = hold.b;
            expPref = hold.c;
            Array.Resize(ref saveObject.excPos, saveObject.buildingAmount);
            Array.Resize(ref saveObject.proPos, saveObject.buildingAmount);
            Array.Resize(ref saveObject.expPos, saveObject.buildingAmount);

            for(int i=0; i< saveObject.buildingAmount; i++)
            {
                if(saveObject.excPos[a]!= Vector3.zero)
                {
                    Instantiate(excPref,saveObject.excPos[a], Quaternion.identity);
                    if(a != saveObject.excPos.Length - 1)
                    a++;
                }
                else if(saveObject.proPos[b] != Vector3.zero)
                {
                    Instantiate(proPref,saveObject.proPos[b], Quaternion.identity);
                    if(b != saveObject.excPos.Length - 1)
                    b++;
                } 
                else if(saveObject.expPos[c] != Vector3.zero)
                {
                    Instantiate(expPref,saveObject.expPos[c], Quaternion.identity);
                    if(c != saveObject.excPos.Length - 1)
                    c++;
                }
            }
        }
        else
    {
        Debug.Log("null");
    }
    }

    private void LoadContract(SaveObject saveObject)
    {
        c1.contractName =  saveObject.cName1; 
        c2.contractName = saveObject.cName2;
        c3.contractName = saveObject.cName3;
        c1.orderedGoods = saveObject.orderedGoods1;
        c2.orderedGoods = saveObject.orderedGoods2;
        c3.orderedGoods = saveObject.orderedGoods3;
        c1.deliverTime = saveObject.deliverTime1;
        c2.deliverTime = saveObject.deliverTime2;
        c3.deliverTime = saveObject.deliverTime3;
        c1.deliveredGoods = saveObject.deliveredGoods1;
        c2.deliveredGoods = saveObject.deliveredGoods2;
        c3.deliveredGoods = saveObject.deliveredGoods3;
        c1.gain=saveObject.gain1;
        c2.gain=saveObject.gain2;
        c3.gain=saveObject.gain3;
        c1.faul=saveObject.faul1;
        c2.faul=saveObject.faul2;
        c3.faul=saveObject.faul3;
        c1.contractsCmpltd=saveObject.contractsCmpltd1;
        c2.contractsCmpltd=saveObject.contractsCmpltd2;
        c3.contractsCmpltd=saveObject.contractsCmpltd3;
        c1.isSellected=saveObject.isSellected1;
        c2.isSellected=saveObject.isSellected2;
        c3.isSellected=saveObject.isSellected3;
    }

    private class SaveObject
    {
        public float money;
        public int[] indices = new int[6];
        public int index=0;

        public float orderedGoods1, orderedGoods2, orderedGoods3;
        public float deliverTime1, deliverTime2,deliverTime3;
      
        public float gain1, gain2, gain3, faul1, faul2, faul3;
        public float deliveredGoods1,deliveredGoods2,deliveredGoods3;
      
        public int contractsCmpltd1, contractsCmpltd2, contractsCmpltd3;
      
        public string cName1, cName2, cName3;
      
        public bool isSellected1,isSellected2,isSellected3;
   
        public int excavatorAmount, processorAmount, exporterAmount, vehicleAmount, buildingAmount; 

        public Vector3[] excPos, proPos, expPos, vehPos;

        public int[] realHome, realTarget;
    }
}
