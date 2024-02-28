using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private float money;
    public float Money { get=>money;}

    public List<int> resourceAmounts;
    public int resourceAmount;

    private UIManager uiManager;
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateMoney(money.ToString());
    }

    public void ResourceAdded(ProductType type, int amount)
    {
        int i = (int)type;
        resourceAmounts[i] += amount;
    }

    public void ResourceAdded(int amount)
    {
        resourceAmount += amount;
        uiManager.UpdateResource(resourceAmount.ToString());
    }

    public void ResourceRemoved(ProductType type, int amount)
    {
        int i = (int)type;
        resourceAmounts[i] -= amount;
    }

    public void ResourceRemoved(int amount)
    {
        resourceAmount -= amount;
        uiManager.UpdateResource(resourceAmount.ToString());
    }
    public void MoneyGained(float addition)
    {
        money += addition;
        uiManager.UpdateMoney(money.ToString());
    }

    public void MoneyLoosed(float addition)
    {
        money -= addition;
        uiManager.UpdateMoney(money.ToString());
    }

    public void ManipulateResource(ProductType type, int amount)
    {
        int i = (int)type;
        resourceAmounts[i] += amount; // If the desired process is adding, then the amount should be positive, if it is not, then it should be negative like -5.
    }

    public void ManipulateResource(ProductType type, int amount, bool isAdder)
    {
        int i = (int)type;
        if (isAdder)
        {
            resourceAmounts[i] += amount;
        }
        else
        {
            resourceAmounts[i] -= amount;
        }
    }   
    
    
}
