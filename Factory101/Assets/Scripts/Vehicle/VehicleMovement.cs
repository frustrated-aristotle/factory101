using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public GameObject home;
    public GameObject target;
    public GameObject helder;
    public GameObject helderForCheckReals;
    public GameObject realHome;
    public GameObject realTarget;

    private float arranger=1;
    public float speed;
    public float moveSpeed;
    public float cost;
    
    public int level;
    
    //---------Booleans----------\\
    public bool isCreatedFirstTime;
    public bool canMove=true;
    public bool isLoaded=true;

    //----------Componenets---------\\
    private Rigidbody2D rb;
    public Vector2 moveVelocity;
    private Vector3 moveDir;
    FactoryResources playerAsFactory;
    public Improvement imp;


    void Awake()
    {
        imp.isThisABuilding=true;
        imp.fr=playerAsFactory; 
        isCreatedFirstTime = true;
        playerAsFactory = GameObject.Find("Factory").GetComponent<FactoryResources>();
    }
    
    void Start()
    {
        //if(isLoaded){AssignTargetAndHome();}
        
        
        CheckRealHomeAndTarget();
        home=realHome;
        target=realTarget;
        moveSpeed=speed;
        rb= GetComponent<Rigidbody2D>();
        IgnoreTheCollider();
    }

    private void AssignTargetAndHome()
    {
        Debug.Log("aaa");
        realHome = home;
        realTarget = target;
    }

    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Road" || col.gameObject.tag == "Vehicle" || col.gameObject.tag == "Tile")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }
    
    public void IgnoreTheCollider()
    {
        Physics2D.IgnoreCollision(home.GetComponent<Collider2D>() , GetComponent<Collider2D>(), true);
    }

    public void UnignoreTheCollider()
    {
        Physics2D.IgnoreCollision(home.GetComponent<Collider2D>() , GetComponent<Collider2D>(), false);
    }
    
    public void ChangeTarget()
    {
        arranger = arranger * -1;
        helder=target;
        target=home;
        home=helder;
    }

    //Sometimes we click higher buildings before their affairs. When we do it, vehicle can not work correctly.

    public void CheckRealHomeAndTarget()
    {
        Debug.Log("Checking");
        /*if(realHome.GetComponent<Producer>().producerType > realTarget.GetComponent<Producer>().producerType)
        {
            helderForCheckReals = realTarget;
            realTarget = realHome;
            realHome=helderForCheckReals;
        }*/
    }

    public void IncreaseImprovement()
    {
        switch(level)
        {
            case 1:
            ALevelThing();
            break;
            case 2:
            ALevelThing();
            break;
        }
    }

    public void ALevelThing()
    {
        if(CostDeal())
        {
            Debug.Log("Arkadaşım improvement gerçekleşti.");
            level++;
            moveSpeed += speed/4;
        }
    }

    public bool CostDeal()
    {
        if((playerAsFactory.money - imp.impCost) >=0)
        {
            playerAsFactory.money -= imp.impCost;
            return true;
        }
        else
        {
            Debug.Log("Money is not enough");
        }
        return false;
    }
}
