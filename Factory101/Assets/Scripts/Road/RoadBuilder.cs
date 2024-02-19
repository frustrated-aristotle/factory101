using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoadBuilder : MonoBehaviour
{
    //* to gameManager
    
    public  bool canCreate;
    public  bool areRoadsCompleted;

    [SerializeField]float m;

    public  Vector3 addPos;
    
    public  GameObject target;
    public  GameObject home;
    public  GameObject roads;
    public  GameObject first, second;

    private UIController uIController;
    private LineRenderer roadToBuild;
    public  LineRenderer roadTemplate;
    public  LineRenderer lr;
    //We are going to deal with it by using instantia method. we need to make roads prefabs that includes their own line renderer. 

    void Start()
    {        
        roadToBuild = roadTemplate;
        uIController = GameObject.Find("GameManager").GetComponent<UIController>();
    }
    public void BuildRoads()
    {
        Debug.Log("BuildRoads is working");
             //The vehicle will be placed on a road. So each road need a mainTarget and 
        if(AttachPairs() && uIController.gameMode == "Road")
        { /* !PairChecker(target.GetComponent<OnMouseDownS>().pairs, home) */
            lr.SetPosition(0, home.transform.position);
            lr.GetComponent<Road>().home=home;
            lr.SetPosition(1, target.transform.position);
            lr.GetComponent<Road>().target=target;
            lr.useWorldSpace = false;
           /*
            * We are trying to avoid the player to choose same points that she already chose.
            * Each buildings can carry those buildings in their own Building script.
            * 
            */
            CreateNewLiner();
        }
        else
        Debug.Log("Else is wokrin on BuildRoads method");
    }
    void CreateNewLiner()
    {
        Instantiate(roadToBuild, Vector3.zero, Quaternion.identity);
        lr=roadTemplate;
    }

    bool AttachPairs()
    {
        Building bHome = home.GetComponent<Building>();
        Building bTarget = target.GetComponent<Building>();
        
        if(bHome.b1 == null)
        {
            bHome.b1= bTarget;
        }
        else if(bHome.b1 == bTarget)
        {
            return false;         
        }
        if(bHome.b1 == null)
        {
            bHome.b2= bTarget;
        }
        else if(bHome.b2 == bTarget)
        {
            return false;
        }
        if(bHome.b1 == null)
        {
            bHome.b3= bTarget;
        }
        else if(bHome.b3 == bTarget)
        {
            return false;
        }
        if(bHome.b1 == null)
        {
            bHome.b4 = bTarget;
        }
        else if(bHome.b4 == bTarget)
        {
            return false;         
        }
        return true;
    }

    bool PairChecker()
    {
        Debug.Log("PairChecker");
        if(canCreate)
        return true;
        return false;
    }
}
