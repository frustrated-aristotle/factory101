using System;
using System.Collections;
using System.Collections.Generic;
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

    public List<DealSO> currentDeals;
    public List<TextMeshProUGUI> remainedTimeTxts;

    public DealSO lastDeal;

    //This should be given when the deal is selected first.
    private List<float> remainedTimes = new List<float>();

    private ResourceManager resourceManager;
    private void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
        remainedTimes.Add(3);
        remainedTimes.Add(5);
        remainedTimes.Add(7);
        Debug.Log("Count: "+ remainedTimes.Count);
        //Just for try
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }
    
    void CountDown()
    {
        foreach (DealSO deal in currentDeals)
        {
            if (deal)
            {
                int index = (int)deal.type;
                Debug.Log("index:" + index);
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
        }
    }

    private void FailDeal(int index)
    {
        float addition = currentDeals[index].loss;
        resourceManager.MoneyLoosed(addition);
        currentDeals[index] = null;
        //Loose Money
        //Make the delivered good count equals to zero
        //Destroy the deal?
    }

    public void DoneDeal()
    {
        Debug.Log("Deal done");
        //Gain money
        //Make the delivered quantity equals to zero
        //Destroy the deal?????
    }
}
