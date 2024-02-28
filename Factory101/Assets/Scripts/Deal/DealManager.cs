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
    [SerializeField] 
    private TextMeshProUGUI remainedTimeTxt;

    public List<TextMeshProUGUI> quantityTxts;
    public List<TextMeshProUGUI> dueTimeTxts;
    public List<TextMeshProUGUI> profitTxts;
    public List<TextMeshProUGUI> lossTxts;

    private UIManager uiManager;
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        resourceManager = GetComponent<ResourceManager>();
        remainedTimes.Add(3);
        remainedTimes.Add(5);
        remainedTimes.Add(7);
        ShowDeals();
        //Just for try
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
        remainedTimeTxt.text = remainedTime.ToString();
        uiManager.UpdateTimer(remainedTime.ToString());
        if (remainedTime <= 0)
        {
            if (!currentDeal.isDone && !IsStorageEnough())
            {
                FailDeal();
            }  
            else if (IsStorageEnough())
            {
                DoneDeal();
            }
            else
            {
                currentDeal = null;
            }
        }
        /*
        foreach (DealSO deal in currentDeals)
        {
            if (deal)
            {
                int index = (int)deal.type;
                remainedTimes[index] -= Time.deltaTime;
                remainedTimeTxts[index].text = remainedTimes[index].ToString();
                if ( remainedTimes[index] <= 0)
                {
                    if (!deal.isDone)
                    {
                        FailDeal(index);
                    }
                }
            }
        }*/
    }

    private bool IsStorageEnough()
    {
        if (resourceManager.resourceAmount >= currentDeal.orderedQuantity)
        {
            resourceManager.ResourceRemoved(currentDeal.orderedQuantity);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeDeal(DealSO deal)
    {
        if (currentDeal == null)
        {
            currentDeal = deal;
            remainedTime = currentDeal.dueTime;
            Debug.Log("New Deal Sellected!");
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
        currentDeal = null;
    }
    
    //This function will be triggered!
    public void DoneDeal()
    {
        Debug.Log("Done Deal!");
        float addition = currentDeal.profit;
        resourceManager.MoneyGained(addition);
        currentDeal = null;
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
                dueTimeTxts[i].text = deals[i].dueTime.ToString();
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
