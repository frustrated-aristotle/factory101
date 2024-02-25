using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Producer
{
    protected override void ProduceTheOutcome()
    {
        if (CanProduce())
        {
            storage.OutcomeProduced(spendAmount, createAmount);
        }
    }
}
