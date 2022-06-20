using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bank" ,fileName = "Bank Contract")]
public class BankContractSO : ScriptableObject
{
    public float moneyToTake;
    public float moneyToPay;

    public float baseTimeToPay;
    public float timeToPay;
    public float interestOverMainMoney;

    public int typeOfBanckContract;

    public bool canSellectable=true;
    public void CalculateValues()
    {
        moneyToPay = moneyToTake + (moneyToTake * interestOverMainMoney);
        timeToPay = baseTimeToPay * typeOfBanckContract;
    }
}