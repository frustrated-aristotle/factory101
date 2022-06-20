using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Contract : MonoBehaviour
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
    public bool isDelivered=false;

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

    private GameObject gm;

    //We need to assign these other classes on another script that can handle it.
    void Awake()
    {
        deliveredGoodsTxt = GameObject.Find("DVTXT").GetComponent<TextMeshProUGUI>();
        gm = GameObject.Find("GameManager");
        ca= gm.GetComponent<ContractArranger>();
        fr=GameObject.Find("Factory").GetComponent<FactoryResources>();
        rndz= GameObject.Find("GameManager").GetComponent<Randomizer>();
    }

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
        fr.totalCompletedContract ++;
        isDelivered=true;
    }

    public void ContractIsntDelivered()
    {
        fr.money -= faul;
        deliveredGoods = 0;
        isDelivered=false;
    }
    
    public void Show()
    {
        nameTxt.text  = contractName;
        goodsTxt.text = "Deliver:\n"+((int)orderedGoods).ToString();
        deliverTimeTxt.text ="Time:\n" + ((int)deliverTime).ToString() + " Second";
        gainAndFaulTxt.text ="Gain and Faul:\n" + ((int)gain).ToString() + "$" + "\n" + ((int)faul).ToString()+"$";  
    }
}