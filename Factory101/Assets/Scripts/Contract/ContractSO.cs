using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "Contracts" ,fileName = "Contract")]
public class ContractSO : ScriptableObject
{
    [Header("Image")]
    public Sprite image;

    [Header ("Properties To Show")]
    public string contractName;
    public float orderedGoods;
    public float deliverTime;
    public float gain;
    public float faul;

    [Header ("Base Properties")]
    public float baseOrderedGoods;
    public float baseDeliverTime;
    public float baseGain;
    public float baseFaul;

    [Header ("Properties That Will Be Change")]
    public float deliveredGoods;

    public int type;
    public int contractsCmpltd;


    //-----Booleans---------\\
    public bool isSellected;
    public bool isDelivered;
    public bool isContractFulfilled;

    [Header ("Texts")]
    public Text nameTxt;
    public Text goodsTxt;
    public Text deliverTimeTxt;
    public Text gainAndFaulTxt;
    public TextMeshProUGUI deliveredGoodsTxt;

    [Header ("Other Classes")]
    public FactoryResources fr;
    public ContractArranger ca;
    public Randomizer rndz;

    //We need to assign these other classes on another script that can handle it.

    public void DisplayTheContract()
    {
        nameTxt.text=contractName;
        goodsTxt.text=orderedGoods.ToString();
        deliverTimeTxt.text=deliverTime.ToString();
        gainAndFaulTxt.text= gain.ToString() + " " + faul.ToString();
    }
    public void ContractIsDelivered()
    {
        fr.money += gain;
        deliveredGoods = 0;
        isDelivered=true;
    }
    public void ContractIsntDelivered()
    {
        fr.money -= faul;
    }
    
    public bool IsContractFulfilled()
    {
        if(deliveredGoods >= orderedGoods)
        {
            Debug.Log("Delivered Goods: " + deliveredGoods + " Ordered Goods: " + orderedGoods);
            return true;
        }
        else
        {
            return false;
        }
    }
}