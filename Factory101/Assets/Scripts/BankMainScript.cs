using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMainScript : MonoBehaviour
{
    float remainingTime;
    public BankContractSO sellectedBCSO;
    public BankContractsDisplayer[] bCSOs = new BankContractsDisplayer[3];
    FactoryResources fr;

    //Displaying
    public GameObject bankUI;
    
    bool bankUIOpened=false;
    bool areThereAnySellectedBankContract;

    void Start()
    {
        fr = GameObject.Find("Factory").GetComponent<FactoryResources>();
    }
    public void Display()
    {
        foreach(BankContractsDisplayer b in bCSOs)
        {
            b.DisplayBank();
        }
    }
    void Update()
    {
        if(areThereAnySellectedBankContract)
        CountDownRemainingTime();
        //When the player wants to display bank contracts
        //By declaring it touching the right key
        //We need to display contracts.
    }
//***************************---Things With Button---**************************************\\
    public void SellectTheContract(BankContractSO _sellectedBCSO)
    {
        if(!areThereAnySellectedBankContract && _sellectedBCSO.canSellectable)
        {
            
            Debug.Log("SellectTheContract");
            areThereAnySellectedBankContract = true;
            sellectedBCSO = _sellectedBCSO;
            remainingTime = sellectedBCSO.timeToPay;
            TakeTheMoney();
        }
    }

    public void PayTheMoney()
    {  
        sellectedBCSO.CalculateValues();
        if(fr.money >= sellectedBCSO.moneyToPay)
        {
            fr.money -= sellectedBCSO.moneyToPay;
            sellectedBCSO.canSellectable = true;
            areThereAnySellectedBankContract = false;
        }
        else
            Debug.Log("You have not enough money to pay your debt.");
    }
    void TakeTheMoney()
    {
        fr.money += sellectedBCSO.moneyToTake;
        sellectedBCSO.canSellectable = false;
    }
    public void CountDownRemainingTime()
    {
        Debug.Log("aaaaaa");
        remainingTime -= Time.deltaTime;
        Debug.Log("Remaing time: " + remainingTime);
        if(remainingTime < 0 && areThereAnySellectedBankContract)
        Faul();
    }

    private void Faul()
    {
        sellectedBCSO.CalculateValues();
        fr.money -= sellectedBCSO.moneyToPay + sellectedBCSO.moneyToPay;
        areThereAnySellectedBankContract=false;
    }
}