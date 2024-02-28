using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField]
    private int source;
    [SerializeField]
    private int outcome;

    public int Source { get=> source; }
    public int Outcome { get=> outcome; }

    public void SourceDelivered(int amount)
    {
        Debug.Log("Source Delivered");
        source -= amount;
    }
    public void SourceArrived(int amount)
    {
        Debug.Log("Source Arrived");
        source += amount;
        if (GetComponent<IPurchasable>().GetPurchasableType() == PurchasableType.Storage)
        {
            FindObjectOfType<ResourceManager>().ResourceAdded(amount);
            // FindObjectOfType<ResourceManager>().resourceAmount += amount;
        }
    }

    public void OutcomeProduced(int spendAmount, int createAmount)
    {
        source -= spendAmount;
        outcome += createAmount;
    }

    public void OutcomeArrived(int amount)
    {
        outcome += amount;
    }

    public int VehicleLoaded(int vehicleCapacity)
    {
        Debug.Log("Load");
        int temp = LoadQuantity(vehicleCapacity);

        outcome -= temp;
        return temp;
    }
    private int LoadQuantity(int capacity)
    {
        int i;
        if (Outcome >= capacity)
        {
            i = capacity;
        }
        else
        {
            i = Outcome;
        }
        return i;
    }
}