using UnityEngine.UI;
using UnityEngine;

public class ContractManager : MonoBehaviour
{
    
    /// <summary>
    /// 
    /// </summary>
    private float remainingTime;

    public  bool isContractSellected;
    public  bool areContractsArranged;

    private GameObject contractUI;
    public  Contract[] contracts;
    public  Contract sellectedContract;
    private Contract lastSellectedContract;
    
    private Randomizer randomizer;
    
    public Text deliveredGoodsTxt,genBehTxt,remainingTimeTxt;

    UIController ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("GameManager").GetComponent<UIController>();
        sellectedContract=null;
        lastSellectedContract=null;
//        remainingTimeTxt = GameObject.Find("DeliverTimeCounter").GetComponent<Text>();
      //  deliveredGoodsTxt = GameObject.Find("DVTXT").GetComponent<Text>();
      //  genBehTxt = GameObject.Find("General Case Text").GetComponent<Text>();
        //randomizer = GameObject.FindObjectOfType<Randomizer>();
        //contractUI = GameObject.Find("Contract UI");
    }

    // Update is called once per frame
    void Update()
    {
        if(isContractSellected)
        {
            CountDown();
        }
        if(isContractSellected && remainingTime<=0)
            {
                //It is not delivered. 
                if(!sellectedContract.isDelivered && lastSellectedContract == sellectedContract)
                {
                    ContractNotDelivered();
                    isContractSellected = false;
                }
            }
    }
    //Randomize The values
    //Assign them to the contracts texts
    public void RandomizeValuesAndAssignThem()
    {
        foreach(Contract contract in contracts)
        {
            randomizer.RandomContractValues(contract);
            contract.Show();
            areContractsArranged=true;
        }
    }
    public void SellectAContract(Contract _sellectedContract)
    {
        Debug.Log("dGoods _sel: "+_sellectedContract.deliveredGoods);
        if(!isContractSellected)
        {

            isContractSellected=true;
            
            sellectedContract = _sellectedContract;
            lastSellectedContract = sellectedContract;
            remainingTime = sellectedContract.deliverTime;
            ui.HideMenu(ui.UIContract); 
            sellectedContract.isDelivered=false;
            //Start Countdown
        }
    }

    //Countdown
    void CountDown()
    {
        remainingTime -= Time.deltaTime;
        remainingTimeTxt.text = "Remaining time is: " +((int)remainingTime).ToString();
    }

    public void Fulfilled()
    {
        sellectedContract.ContractIsDelivered();
        //Contract activate
        randomizer.RandomContractValues(sellectedContract);
        sellectedContract.Show();
        genBehTxt.text="Contract is fulfilled. You need to chose a new contract.";
        sellectedContract=null;
        isContractSellected=false;
    }

    void ContractNotDelivered()
    {
        sellectedContract.ContractIsntDelivered();
        randomizer.RandomContractValues(sellectedContract);
        sellectedContract.Show();
        //! Make ContractUI appear.
        contractUI.SetActive(true);
        sellectedContract=null;
        isContractSellected=false;
    }
    
    public void DisplayDeliveredGoods()
    {
        deliveredGoodsTxt.text = sellectedContract.deliveredGoods.ToString();
    }
}
