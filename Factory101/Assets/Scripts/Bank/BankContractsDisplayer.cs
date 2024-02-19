using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankContractsDisplayer : MonoBehaviour
{
    public BankContractSO bankContractSO;

    [SerializeField]
    public Text moneyToTake, moneyToPay, timeToPay, interest;

    public void DisplayBank()
    {
        bankContractSO.CalculateValues();
        //Texts
        moneyToTake.text = "Take:\n" + bankContractSO.moneyToTake.ToString()+"$";
        moneyToPay.text ="Pay:\n" + bankContractSO.moneyToPay.ToString()+"$";
        timeToPay.text ="Payment Time:\n" + bankContractSO.timeToPay.ToString()+" Second";
        interest.text ="Interest:\n%" + bankContractSO.interestOverMainMoney.ToString();
    }

}
