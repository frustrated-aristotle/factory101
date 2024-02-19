using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy instance;
    void Start()
    {
            DontDestroyOnLoad(this.gameObject);        
    }
}