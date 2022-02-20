using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float upkeepCost;
    public GameObject playerAsFactory;
    void Start()
    {
        InvokeRepeating("Upkeep", 0f, 1f);
    }
    void Upkeep()
    {
        playerAsFactory.GetComponent<FactoryResources>().money -= upkeepCost;
    }
}
