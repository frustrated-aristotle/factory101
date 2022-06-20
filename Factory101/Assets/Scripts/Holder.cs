using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Holder : MonoBehaviour
{
    public GameObject a,b,c,v;

    public Contract first, second, third;
    
    //*ID for buildings
    public int id;
    void Awake()
    {
        id=0;
    }
}