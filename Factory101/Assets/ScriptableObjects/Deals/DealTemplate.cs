using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deal Template", fileName = "Deals")]
public class DealTemplate : ScriptableObject
{
    public List<Deal> deals;

    [Serializable]

    public struct Deal
    {
        public int orderedQuantity;
        public float profit;
        public float loss;
        public float dueTime;
    }
    
}
