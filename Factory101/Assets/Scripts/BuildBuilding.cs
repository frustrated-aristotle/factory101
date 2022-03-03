using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    public GameObject gOToBuild;
    public bool isBuildingAccessable;
    public bool isBuildingOn;
    public GameObject buildingUI;
    public FactoryResources factoryResources;
    // Start is called before the first frame update
    void Awake()
    {
        buildingUI.SetActive(false);
    }
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.B) && isBuildingAccessable ==false)
        {
                isBuildingAccessable=true;
                buildingUI.SetActive(true);
                
        }
        else if(Input.GetKeyDown(KeyCode.B) && isBuildingAccessable == true)
        {
                isBuildingAccessable=false;
                buildingUI.SetActive(false);
        }
        
        if (Input.GetButtonDown("Fire1") && isBuildingOn)
        {
            //Check there is enough resources
            if(factoryResources.money >= gOToBuild.GetComponent<Building>().cost)
            {
                BuyAndPlaceTheBuilding();
                factoryResources.money -= gOToBuild.GetComponent<Building>().cost;
            }
            else
            {
                Debug.Log("There is no enough money to build this building.");
            }
            
        }
    }

    void BuyAndPlaceTheBuilding()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Camera.main.nearClipPlane;
        Instantiate(gOToBuild, mousePos, Quaternion.identity);
    }
    public void SellectBuilding(GameObject SellectedGO)
    {
        gOToBuild=SellectedGO;
        isBuildingOn=true;
    }
}