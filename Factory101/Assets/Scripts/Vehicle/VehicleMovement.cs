using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour, IPurchasable
{
    public GameObject home;
    public GameObject target;

    public GameObject currentTarget;
    
    public GameObject helder;
    public GameObject helderForCheckReals;

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

    [SerializeField]
    private float distance;

    private Storage storage;

    public int capacity;
    void Awake()
    {
        storage = GetComponent<Storage>();
        imp.isThisABuilding=true;
        imp.fr=playerAsFactory; 
        isCreatedFirstTime = true;
        playerAsFactory = GameObject.Find("Factory").GetComponent<FactoryResources>();
    }
    
    void Start()
    {
        currentTarget = target;
        //if(isLoaded){AssignTargetAndHome();}
        
        
        //CheckRealHomeAndTarget();
        moveSpeed=speed;
        rb= GetComponent<Rigidbody2D>();
        //IgnoreTheCollider();

    }
    
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, currentTarget.transform.position, Time.deltaTime * moveSpeed);
        Vector3 temp = transform.position;
        temp.z = -3;
        //transform.position = temp;
        if (Distance() < distance)
        {
            if (currentTarget == target)
            {
                PurchasableType homeType = home.GetComponent<IPurchasable>().GetPurchasableType();
                PurchasableType targetType = target.GetComponent<IPurchasable>().GetPurchasableType();
                
                //Dump package
                //Now, it is time for Storage.cs!!!!!! LEtsgooooooooo
                
                if (homeType == targetType)
                {
                    target.GetComponent<Storage>().OutcomeArrived(LoadQuantity());
                    storage.SourceDelivered(LoadQuantity());
                }
                else if (homeType == PurchasableType.Miner && targetType == PurchasableType.Processor)
                {
                    target.GetComponent<Storage>().SourceArrived(LoadQuantity());
                    storage.SourceDelivered(LoadQuantity());
                    //Lower level, SourceArrived();
                }
                else if (homeType == PurchasableType.Processor && targetType == PurchasableType.Storage)
                {
                    target.GetComponent<Storage>().SourceArrived(LoadQuantity());
                    storage.SourceDelivered(LoadQuantity());
                }
                
            }
            else if (currentTarget == home)
            {
                //Load package
                //How does our vehicle get its load?
                LoadVehicle();
                storage.SourceArrived(home.GetComponent<Storage>().VehicleLoaded(capacity));
            }
            ChangeTarget();
        }
    }

    public void LoadVehicle()
    {
        storage.SourceArrived(home.GetComponent<Storage>().VehicleLoaded(capacity));
    }
    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Road" || col.gameObject.tag == "Vehicle" || col.gameObject.tag == "Tile")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }*/

    private int LoadQuantity()
    {
        int i;
        if (storage.Source >= capacity)
        {
            i = capacity;
        }
        else
        {
            i = storage.Source;
        }
        return i;
    }
    private float Distance()
    {
        return Vector2.Distance(currentTarget.transform.position, transform.position);
    }

    private void ChangeTarget()
    {
        if (currentTarget == target)
        {
            currentTarget = home;
        }
        else
        {
            currentTarget = target;
        }
    }
/*    
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
        }
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
    }*/
public PurchasableType GetPurchasableType()
{
    return PurchasableType.Vehicle;
}

public GameObject GetGameObject()
{
    return this.gameObject;
}
}
