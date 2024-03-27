using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DealManager : MonoBehaviour
{
    /// <summary>
    /// Deal manager is responsible for all deal related things.
    /// Validation of Gain and Loose states:
    ///     Loose:
    ///         If the due time is over,
    ///             There is a current deal
    ///                 Deal has not done
    ///                     Loose.
    ///     Gain:
    ///         If the DoneDeal() triggered
    ///             Gain.
    /// </summary>
    // Start is called before the first frame update

    //public List<DealSO> currentDeals;
    public DealSO currentDeal;

    public DealSO lastDeal;
    public List<DealSO> deals;
    public List<TextMeshProUGUI> remainedTimeTxts;

    //This should be given when the deal is selected first.
    private List<float> remainedTimes = new List<float>();

    private ResourceManager resourceManager;

    private float remainedTime;
    [SerializeField] private TextMeshProUGUI remainedTimeTxt;

    public List<TextMeshProUGUI> quantityTxts;
    public List<TextMeshProUGUI> dueTimeTxts;
    public List<TextMeshProUGUI> profitTxts;
    public List<TextMeshProUGUI> lossTxts;

    private UIManager uiManager;

    private int completedContracts;

    [SerializeField] private DealTemplate dealTemplate;

    private void Start()
    {
        PlayerPrefs.SetInt("CompletedLevel", 0);        
        uiManager = FindObjectOfType<UIManager>();
        resourceManager = GetComponent<ResourceManager>();
        remainedTimes.Add(3);
        remainedTimes.Add(5);
        remainedTimes.Add(7);
        completedContracts = FindObjectOfType<SaveManager>().Level;
        if (completedContracts == 0)
        {
            completedContracts++;
        }
        RestoreValuesForDeals();
        InitDeals();       
        ShowDeals();

    }

    private void InitDeals()
    {
        Debug.Log("Completed Contract count : " + PlayerPrefs.GetInt("CompletedLevel"));
        foreach (var deal in deals)
        {
            deal.profit = dealTemplate.deals[PlayerPrefs.GetInt("CompletedLevel")].profit;
            deal.loss = dealTemplate.deals[PlayerPrefs.GetInt("CompletedLevel")].loss;
            deal.orderedQuantity = dealTemplate.deals[PlayerPrefs.GetInt("CompletedLevel")].orderedQuantity;
            deal.dueTime = dealTemplate.deals[PlayerPrefs.GetInt("CompletedLevel")].dueTime;
        }
        ShowDeals();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDeal != null)
            CountDown();
    }

    void CountDown()
    {
        remainedTime -= Time.deltaTime;

        if (remainedTime <= 0)
        {
            if (IsStorageEnough())
            {
                DoneDeal();
            }
            else if (!currentDeal.isDone && !IsStorageEnough())
            {
                Debug.Log("False fail deal");
                FailDeal();
                remainedTime = 0;
            }
            else
            {
                currentDeal = null;
                remainedTime = 0;
            }
        }

        uiManager.UpdateTimer(remainedTime.ToString());
    }

    private bool IsStorageEnough()
    {
        if (resourceManager.resourceAmount >= currentDeal.orderedQuantity)
        {
            resourceManager.ResourceRemoved(currentDeal.orderedQuantity);
            Debug.Log("False true");
            return true;
        }
        else
        {
            Debug.Log("False: " + resourceManager.resourceAmount + " ordered quantity" + currentDeal.orderedQuantity);
            return false;
        }
    }

    public void TakeDeal(DealSO deal)
    {
        if (currentDeal == null)
        {
            currentDeal = deal;
            remainedTime = currentDeal.dueTime;
            int index = deal.dealLevel;
            uiManager.takeButtons[index].text = "Send";
        }
        else if (currentDeal == deal)
        {
            //Out player is trying to send his goods to dealer.
            //If there is enough goods in his warehouse, then it is good to go.
            if (IsStorageEnough())
            {
                DoneDeal();
            }
        }
        else
        {
            Debug.Log("There is already a deal, first try to complete it.");
        }
    }

    private void FailDeal()
    {
        Debug.Log("Failed");
        float addition = currentDeal.loss;
        resourceManager.MoneyLoosed(addition);
        int index = currentDeal.dealLevel;
        uiManager.takeButtons[index].text = "Take";
        currentDeal = null;
        ChangeDeals(0);
    }

    private void RestoreValuesForDeals()
    {
        deals[0].profit = 400;
        deals[0].dueTime = 3;
        deals[0].loss = 500;
        deals[0].orderedQuantity = 15;

        deals[1].profit = 800;
        deals[1].dueTime = 5;
        deals[1].loss = 900;
        deals[1].orderedQuantity = 30;
        
        deals[2].profit = 1200;
        deals[2].dueTime = 7;
        deals[2].loss = 1300;
        deals[2].orderedQuantity = 60;
    }

    private void ChangeDeals(int i)
    {
        completedContracts += i;
        foreach (var deal in deals)
        {
            deal.profit += deal.profit * 30 / 100;
            deal.loss += deal.loss * 3 / 10;
            deal.orderedQuantity += deal.orderedQuantity * 3 / 10;
            deal.dueTime += deal.dueTime * 3 / 10;
        }

        ShowDeals();
    }

    //This function will be triggered!
    public void DoneDeal()
    {
        int level = PlayerPrefs.GetInt("CompletedLevel");
        level++;
        PlayerPrefs.SetInt("CompletedLevel", level);        
        float addition = currentDeal.profit;
        resourceManager.MoneyGained(addition);
        int index = currentDeal.dealLevel;
        uiManager.takeButtons[index].text = "Take";
        currentDeal = null;
        //ChangeDeals(1);
        InitDeals();
        //Gain money
        //Make the delivered quantity equals to zero
        //Destroy the deal?????
    }

    public void ShowDeals()
    {
        for (int i = 0; i < 3; i++)
        {
            if (deals[i])
            {
                quantityTxts[i].text = deals[i].orderedQuantity.ToString();
                dueTimeTxts[i].text = deals[i].dueTime.ToString() + " sec.";
                profitTxts[i].text = deals[i].profit.ToString();
                lossTxts[i].text = deals[i].loss.ToString();
            }
        }
    }

    private void FailDeal(int index)
    {
        //float addition = currentDeals[index].loss;
        //resourceManager.MoneyLoosed(addition);
        //currentDeals[index] = null;
        //Loose Money
        //Make the delivered good count equals to zero
        //Destroy the deal?
    }
}