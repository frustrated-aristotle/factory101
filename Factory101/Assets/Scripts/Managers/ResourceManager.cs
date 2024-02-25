using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private float money;
    public float Money { get=>money;}

    public List<int> resourceAmounts;

    public void ResourceAdded(ProductType type, int amount)
    {
        int i = (int)type;
        resourceAmounts[i] += amount;
    }

    public void ResourceRemoved(ProductType type, int amount)
    {
        int i = (int)type;
        resourceAmounts[i] -= amount;
    }

    public void MoneyGained(float addition)
    {
        money += addition;
    }

    public void MoneyLoosed(float addition)
    {
        money -= addition;
        Debug.Log("Money : " + money);
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
