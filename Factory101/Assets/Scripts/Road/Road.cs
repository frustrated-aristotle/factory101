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
    void Start()
    {
        //ArrangeTheCollider();
    } 
    void ArrangeTheCollider()
    {
        points = child.GetComponent<EdgeCollider2D>().points;
        child.GetComponent<EdgeCollider2D>().useAdjacentEndPoint=true;
        child.GetComponent<EdgeCollider2D>().useAdjacentStartPoint=true;
        child.GetComponent<EdgeCollider2D>().adjacentEndPoint=target.transform.position;
        child.GetComponent<EdgeCollider2D>().adjacentStartPoint=home.transform.position;
        
        points[0] = new Vector2(home.transform.position.x, home.transform.position.y);
        points[1] = new Vector2(target.transform.position.x, target.transform.position.y);
        
        child.GetComponent<EdgeCollider2D>().points = points;
        //child.GetComponent<EdgeCollider2D>().SetPoints( new Vector2(0, 1));
    }

    public PurchasableType GetPurchasableType()
    {
        return PurchasableType.Road;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
}