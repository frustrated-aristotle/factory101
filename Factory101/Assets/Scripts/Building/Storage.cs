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

    public void SourceArrived(int amount)
    {
        source += amount;
    }

    public void OutcomeProduced(int spendAmount, int createAmount)
    {
        source -= spendAmount;
        outcome += createAmount;
    }
}