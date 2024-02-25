using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processor : Producer
{
    protected override void ProduceTheOutcome()
    {
        if (CanProduce())
        {
            storage.OutcomeProduced(spendAmount, createAmount);
        }
    }
}
