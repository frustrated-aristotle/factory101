using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject target;
    public GameObject home;
    
    void Start()
    {
        //GetComponent<Physics>();
        gameObject.AddComponent<BoxCollider2D>();
        this.gameObject.GetComponent<BoxCollider2D>().size= new Vector2(GetComponent<BoxCollider2D>().size.x, 0.17f);
    } 
}