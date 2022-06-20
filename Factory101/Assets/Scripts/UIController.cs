 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //In this script, we will design our UIController that handles when a spesific key that is going to trigger an UI to be opened and stuffs like that.
    
    public  GameObject lastSelectedUI;
    public  GameObject UIBank;
    public  GameObject UIContract;
    public  GameObject UIBuilding;
    public  GameObject UIImprovement;
    public  GameObject UILands;
    public  GameObject UIEsc;
    public  GameObject UITuto;
    public  GameObject gm;

    private BuyAndPlaceTheBuildings buyAndPlaceTheBuildings;
    private BankMainScript bms;
    private ContractManager cm;
    public  LandBaseScript[] lb;
    public  Contract[] contracts;
    
    private bool bank = false;
    private bool cont = false;
    private bool isBuildingUIOpened=false;
    private bool imp = false;
    private bool land = false;

    public  string gameMode="";

    void Start()
    {
        buyAndPlaceTheBuildings = GameObject.FindObjectOfType<BuyAndPlaceTheBuildings>();
        gm = GameObject.Find("GameManager");
        bms = GetComponent<BankMainScript>();
        cm = gm.GetComponent<ContractManager>();
        UIBank.SetActive(false);
        UIContract.SetActive(false);
        UIBuilding.SetActive(false);
        UIImprovement.SetActive(false);
        UILands.SetActive(false);
        UIEsc.SetActive(false);
        UITuto = GameObject.Find("Tuto");
        UITuto.SetActive(true);
    }

    void Update()
    {
        BankMenu();//
        BuildingMenu();
        ContractMenu();
        ImprovementMenu();
        LandMenu();
        RoadBuilding();
        EscMenu();
        TutoMenu();
    }

    public void ShowMenu(GameObject UI)
    {
        if(lastSelectedUI != null)
        lastSelectedUI.SetActive(false);
        lastSelectedUI = UI; 
        UI.SetActive(true);
    }
    public void HideMenu(GameObject UI)
    {
        UI.SetActive(false);
    }
    void RoadBuilding()
    {
        if(Input.GetKeyDown(KeyCode.R) && gameMode!= "Road")
        {
            gameMode="Road";
        }
        else if(Input.GetKeyDown(KeyCode.R) && gameMode== "Road")
        {
            gameMode="Play";
        }
    }
    void TutoMenu()
    {
        if(Input.GetKeyDown(KeyCode.T) && gameMode != "Tuto")
        {
            UITuto.SetActive(true);
            gameMode = "Tuto";
        }
        else if(Input.GetKeyDown(KeyCode.T) && gameMode == "Tuto")
        {
            UITuto.SetActive(false);
            gameMode = "Play"; 
        }

    }
    void EscMenu()
    {
        //Stop the game
        if(Input.GetKeyDown(KeyCode.Escape) && gameMode != "Esc")
        {
            UIEsc.SetActive(true);
            gameMode = "Esc";
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gameMode == "Esc")
        {
            UIEsc.SetActive(false);
            gameMode = "Play"; 
            Time.timeScale = 1f; 
        }
    }
    public void QGame()
    {
        Application.Quit();
    }
    void BuildingMenu()
    {
        //For The Building Menu
        if(Input.GetKeyDown(KeyCode.B) && !isBuildingUIOpened)
        {
            gameMode="Build";
            ShowMenu(UIBuilding);
            isBuildingUIOpened =true;
            UIBuilding.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.B) && isBuildingUIOpened)
        {
            buyAndPlaceTheBuildings.sellectedBuilding = null;
            buyAndPlaceTheBuildings.isThereAnySellectedBuilding =false;
            gameMode="Play";
            HideMenu(UIBuilding);
            isBuildingUIOpened = false;
            UIBuilding.SetActive(false);
        }
    }
    void ContractMenu() 
    {
        if(Input.GetKeyDown(KeyCode.C) && cont == false)
        {
            if(!cm.areContractsArranged)
            cm.RandomizeValuesAndAssignThem();
            gameMode = "Contract";
            ShowMenu(UIContract);
            cont = true;
            foreach(Contract c in contracts)
            {
                c.Show();
            }
        }
        else if(Input.GetKeyDown(KeyCode.C) && cont == true)
        {
            gameMode = "Play";
            HideMenu(UIContract);
            cont = false;
        }

    }
    void BankMenu()
    {
        //For The Bank Menu
        if(Input.GetKeyDown(KeyCode.Q) && !bank)
        {
            gameMode = "Bank";
            ShowMenu(UIBank);
            bank = true;
            bms.Display();
        }
        else if(Input.GetKeyDown(KeyCode.Q) && bank)
        {
            gameMode = "Play";
            HideMenu(UIBank);
            bank = false;
        }

    }
    void LandMenu()
    {
        if(Input.GetKeyDown(KeyCode.X) && !land)
        {
            gameMode = "Land";
            ShowMenu(UILands);
            land = true;
            foreach(LandBaseScript l in lb)
            {
                l.Show();
            }
        }
        else if(Input.GetKeyDown(KeyCode.X) && land)
        {
            gameMode = "Play";
            HideMenu(UILands);
            land = false;
        }
    }
    void ImprovementMenu()
    {
        if(Input.GetKeyDown(KeyCode.I) && !imp)
        {
            gameMode = "Improvement";
            ShowMenu(UIImprovement);
            imp = true;
            gm.GetComponent<ImprovementMainHandler>().Display();
        }
        else if(Input.GetKeyDown(KeyCode.I) && imp)
        {
            gameMode = "Play";
            HideMenu(UIImprovement);
            imp = false;
        }
    }
}