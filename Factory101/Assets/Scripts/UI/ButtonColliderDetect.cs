using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColliderDetect : MonoBehaviour
{
   //We need one more boolean to check if we can build a building.
   //When the player interacts with the collider of any button
    //This boolean will be false.
    //Then it make false the real boolean that we get from main script.
    //When the interaction is completed and the player is no longer interacts with the coll;
    //Boolean will be true and then it will make the main boolean true;
    //BuildBuilding realBool;
    bool tempBool;

    void Start()
    {
        //realBool = GameObject.Find("GameManager").GetComponent<BuildBuilding>();
    }

    void OnMouseEnter()
    {
        tempBool=false;
        //CheckTheBool();   
    }

    void OnMouseExit()
    {
        tempBool=true;
        //CheckTheBool();
    }

    /* void CheckTheBool()
    {
        if(realBool.isBuildingOn && tempBool==false)
        {
            realBool.isBuildingOn = false;
        }
        else if(realBool.isBuildingOn && tempBool==true)
        {
            realBool.isBuildingOn = true;
        }
        else if(!realBool.isBuildingOn)
        {
            realBool.isBuildingOn = false;
        }
    } */
}
