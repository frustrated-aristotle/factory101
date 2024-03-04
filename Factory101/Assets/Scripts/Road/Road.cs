using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour, IPurchasable
{
    public GameObject target;
    public GameObject home;
    

    float m;
    float rotationAmount;
    int intForM;
    float secondM;

    public Vector2[] points;
   
    private LineRenderer lineRenderer;
    private PolygonCollider2D polygonCollider;

    private StateManager stateManager;
    private PurchaseManager purchaseManager;
    private ResourceManager resourceManager;

    [SerializeField] private float cost;

    public List<GameObject> vehicles;
    void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
        purchaseManager = FindObjectOfType<PurchaseManager>();
        resourceManager = FindObjectOfType<ResourceManager>();
        lineRenderer = GetComponent<LineRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        UpdateCollider();
    }

    void UpdateCollider()
    {
        Vector3 start = lineRenderer.GetPosition(0);
        Vector3 end = lineRenderer.GetPosition(lineRenderer.positionCount - 1);

        Vector3 direction = end - start;
        direction.Normalize(); 

        Vector2 start2D = new Vector2(start.x, start.y);
        Vector2 end2D = new Vector2(end.x, end.y);

        Vector2[] points = new Vector2[4];
        Vector2 perpendicular = new Vector2(-direction.y, direction.x); 
        
        float thickness = 0.025f;
        thickness = 0.05f;

        points[0] = start2D + thickness * perpendicular;
        points[1] = end2D + thickness * perpendicular;
        points[2] = end2D - thickness * perpendicular;
        points[3] = start2D - thickness * perpendicular;

        polygonCollider.points = points;

        LineRenderer outLine = new LineRenderer();
        outLine = lineRenderer;
        outLine.sharedMaterial.SetColor("_Color", Color.gray);

    }

  


    private void OnMouseDown()
    {
        if (stateManager.currentState.type == StateType.Purchase)
        {
            GameObject vehicle = purchaseManager.OnTileClicked(lineRenderer.GetPosition(0));
            GameObject temp = home.GetComponent<Tile>().building.GetGameObject();
            GameObject tempT = target.GetComponent<Tile>().building.GetGameObject();
            vehicle.GetComponent<VehicleMovement>().home = temp;
            vehicle.GetComponent<VehicleMovement>().target = tempT;
            vehicle.GetComponent<VehicleMovement>().LoadVehicle();
            vehicles.Add(vehicle);
        }
        else if (stateManager.currentState.type == StateType.Bulldoze)
        {
            foreach (var vehicle in vehicles)
            {
                resourceManager.MoneyGained(vehicle.GetComponent<IPurchasable>().GetCost());
                Destroy(vehicle);
            }
            vehicles.Clear();
            resourceManager.MoneyGained(cost);
            home = null;
            target = null;
            lineRenderer = null;
            gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
    #region IPurchasable
     
         public PurchasableType GetPurchasableType()
         {
             return PurchasableType.Road;
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