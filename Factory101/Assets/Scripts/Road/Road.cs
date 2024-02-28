using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour, IPurchasable
{
    public GameObject target;
    public GameObject home;
    
    public GameObject instHomePos1;
    public GameObject instHomePos2;

    public GameObject child;

    float m;
    float rotationAmount;
    int intForM;
    float secondM;

    public Vector2[] points;
   
    private LineRenderer lineRenderer;
    private PolygonCollider2D polygonCollider;

    private StateManager stateManager;
    private PurchaseManager purchaseManager;
    void Start()
    {
        purchaseManager = FindObjectOfType<PurchaseManager>();
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

        points[0] = start2D + thickness * perpendicular;
        points[1] = end2D + thickness * perpendicular;
        points[2] = end2D - thickness * perpendicular;
        points[3] = start2D - thickness * perpendicular;

        polygonCollider.points = points;
    }


    public PurchasableType GetPurchasableType()
    {
        return PurchasableType.Road;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    private void OnMouseDown()
    {
        GameObject vehicle = purchaseManager.OnTileClicked(lineRenderer.GetPosition(0));
        GameObject temp = home.GetComponent<Tile>().building.GetGameObject();
        GameObject tempT = target.GetComponent<Tile>().building.GetGameObject();
        vehicle.GetComponent<VehicleMovement>().home = temp;
        vehicle.GetComponent<VehicleMovement>().target = tempT;
        vehicle.GetComponent<VehicleMovement>().LoadVehicle();
    }
}