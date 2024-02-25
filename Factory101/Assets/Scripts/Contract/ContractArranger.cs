using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ContractArranger : MonoBehaviour
{
    //* To the GameManager
    //There must be at least 3 contracts.
    public Contract sellectedContract;
    public Contract lastSellectedContract;

    public Contract[] cs = new Contract[3];

    public bool haveContract;
    public bool isContractFulfilled;
    bool isContractSellected=false;
    public bool areContractsArranged=false;

    //--------- TMPRO ----------\\
    public TextMeshProUGUI genBehTxt;
    public TextMeshProUGUI remainingTimeTxt;
    public TextMeshProUGUI deliveredGoodsTxt;

    
    //--------- Other Classes ----------\\

    
    private Randomizer randomizer;
    private GameObject gm;
    [SerializeField]GameObject contractUI;
    public float remainingTime;

    void Start()
    {
//        genBehTxt = GameObject.Find("General Case Text").GetComponent<TextMeshProUGUI>();
       // remainingTimeTxt = GameObject.Find("DeliverTimeCounter").GetComponent<TextMeshProUGUI>();
     //   deliveredGoodsTxt = GameObject.Find("DVTXT").GetComponent<TextMeshProUGUI>();
        sellectedContract = null;
        lastSellectedContract = null;
        gm= GameObject.Find("GameManager");
        randomizer = gm.GetComponent<Randomizer>();
    }

    void Update()
    {
        if(haveContract)
            CountDownRemainingTime();
        
        if(haveContract && remainingTime <= 0)
            IsItDeliveredOnTime();
    }
    public void SetAndDisplayTheConract()
    {
        foreach(Contract c in cs)
        {
            randomizer.RandomContractValues(c);
            c.Show();
            areContractsArranged=true;
        }
    }
    //---------------When We Sellect The Contract---------------\\
    public void SellectTheContract(Contract contractSellected)
    {   
        isContractSellected=false;
       //We need to make it just about having any of the contracts
        if(!isContractSellected)
        {
            sellectedContract = contractSellected;
            lastSellectedContract=sellectedContract;
            remainingTime = sellectedContract.deliverTime;
            isContractSellected = true;
            Debug.Log("ContractSellectedBefore");
            GameObject.Find("Contract UI").SetActive(false);
            Debug.Log("Sellected Contract's deliver time: " + sellectedContract.deliverTime);
            //Invoke("IsItDeliveredOnTime", sellectedContract.deliverTime);
            //We need to count down when we arrange the remaining time.
        }
    }
  
    public void CountDownRemainingTime()
    {
        remainingTime -= Time.deltaTime;
        remainingTimeTxt.text = "Remaining time is: " + ((int)remainingTime).ToString();
    }

    //--------------When The Contract Is Finished---------------\\

    //When a contract is fulfilled, we need to randomize the contract that is fulfilled.
    public void DoFulfillThings()
    {
        sellectedContract.ContractIsDelivered(); 
        Debug.Log("Contract is fulfillled.");
        contractUI.SetActive(true);
        randomizer.RandomContractValues(sellectedContract);
        sellectedContract.Show();
        genBehTxt.text="Contract is fulfilled. You need to chose a new contract.";
        sellectedContract=null;
        haveContract=false;
        isContractFulfilled =true;
        sellectedContract.isDelivered =false;
    }

    void IsItDeliveredOnTime()
    {
        Debug.Log("Is it delivered on time");
        if(!sellectedContract.isDelivered && lastSellectedContract == sellectedContract)
        {
            Debug.Log("You can not delivered your contract at the right time.");
            sellectedContract.ContractIsntDelivered();
            randomizer.RandomContractValues(sellectedContract);
            sellectedContract.Show();
            contractUI.SetActive(true);
            sellectedContract=null;
            haveContract=false;
            //Contract is expired.
        }
    }

    //-------------About Other Things-------------\\
    public void DisplayDeliveredGoods()
    {
        deliveredGoodsTxt.text = sellectedContract.deliveredGoods.ToString();
    }

}  