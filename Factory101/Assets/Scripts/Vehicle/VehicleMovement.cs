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

    #region Bulldoze State

    private void OnMouseDown()
    {
        if (FindObjectOfType<StateManager>().currentState.type == StateType.Bulldoze)
        {
            Destroy(this.gameObject);
            //NEED TO UPDATE ITS ROAD'S VEHICLE COLLECTION
        }
    }

    #endregion
#region IPurchasable



    public PurchasableType GetPurchasableType()
    {
        return PurchasableType.Vehicle;
    }

    public float GetCost()
    {
        return cost;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
#endregion

}
