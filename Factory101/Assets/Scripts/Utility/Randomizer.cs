using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    float f1, f2, f3, f4;
    
    public float addGain, addDT,addOG, addFaul;
    float frManipulator;
    GameObject gm;
    FactoryResources fr;
    ContractArranger ca;
    

    void Start()
    {   
        f1 = 300;
        f2 = 1200;
        f3= 20;
        f4= 1500;
        gm = GameObject.Find("GameManager");
        fr = GameObject.Find("Factory").GetComponent<FactoryResources>();
        ca= gm.GetComponent<ContractArranger>();
    }
    //Random Contract Values
    public void RandomContractValues(Contract c)
    {
        //Manipulate things by worth
            ChangeByWorth();
            RndByCompeletedContracts(c);
            c.orderedGoods = c.baseOrderedGoods + addOG; 
            c.gain = c.baseGain + addGain;
            c.deliverTime = c.baseDeliverTime + addDT;
            c.faul = c.baseFaul + addFaul;
    }

    private void ChangeByWorth()
    {
        if(fr.factoryWorth >= 0 && fr.factoryWorth <= 3)
        {
            frManipulator = 1;
        } 
        else if(fr.factoryWorth > 3 && fr.factoryWorth <= 7)
        {
            frManipulator = 3/2;
        }
        else if(fr.factoryWorth > 7 && fr.factoryWorth <= 10)
        {
            frManipulator = 6/2;
        }        
        else if(fr.factoryWorth >10 && fr.factoryWorth <= 12)
        {
            frManipulator = 9/2;
        }
    }

    private void RndByCompeletedContracts(Contract _c)
    {
        if(fr.totalCompletedContract >= 0 && fr.totalCompletedContract <= 1)
        {
            addGain = Random.Range(f1,f2);            
            addOG = Random.Range(f1/2*frManipulator, f4/4*frManipulator);
            addDT = Random.Range(10,f3);         
            addFaul = Random.Range(f1, f4);
        }
        else if(fr.totalCompletedContract > 1 && fr.totalCompletedContract <= 3)
        {
            Debug.Log("1");
            addGain = Random.Range(f1,f2);            
            addOG = Random.Range(f1/4*frManipulator, f4/4*frManipulator);
            addDT = Random.Range(10,f3);         
            addFaul = Random.Range(f1, f4);
        }
        else if(fr.totalCompletedContract > 3 && fr.totalCompletedContract <= 6)
        {
            Debug.Log("2");
            addGain = Random.Range(f1*1.5f, f2*1.5f);            
            addOG = Random.Range(f1*4.5f*frManipulator, f4*4.5f*frManipulator);
            addDT = Random.Range(10,f3*1.5f);
            addFaul = Random.Range(f1*3, f4*3);   
        }
        else if(fr.totalCompletedContract > 6 && fr.totalCompletedContract <= 9)
        {
            Debug.Log("3");
            addGain = Random.Range(f1*3,f2*3);        
            addOG = Random.Range(f1*7.5f*frManipulator, f4*7.5f*frManipulator);
            addDT = Random.Range(10,f3*1.5f);         
            addFaul = Random.Range(f1*7.5f, f4*7.5f);  
        }
        else if(fr.totalCompletedContract > 9)
        {
            Debug.Log("4");
            addGain = Random.Range(f1*3,f2*5);        
            addOG = Random.Range(f1*20*frManipulator, f4*10f*frManipulator);
            addDT = Random.Range(10,f3*1.5f);         
            addFaul = Random.Range(f1*20, f4* 20f);  
        }
    }
}
