using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandBaseScript : MonoBehaviour
{   
    public Text textMoney;
    
    private int childCount;
    private int howManyTileToMakeBuildable=10;
    private int tilesThatMadeBuildable;
    private int childIndexToMakeBuildable;
    
    public int numberI;
    public float cost;
    
    private bool isMakingBuildableProccessCompleted = false;
    public bool isBought=false;


    public Tile[] children = new Tile[600];
    
    void Start()
    {
        cost *= numberI; 
        childCount = transform.childCount;

        for(int i=0; i<childCount ;i++)
        {
            children[i] = transform.GetChild(i).GetComponent<Tile>();

        }
     
    }
    public void MakeSomeTilesBuildable()
    {
        for (int i = 0; i < howManyTileToMakeBuildable ; i++)
        {
            childIndexToMakeBuildable = Random.Range(0,childCount);
            tilesThatMadeBuildable++;

            if(tilesThatMadeBuildable < howManyTileToMakeBuildable)
            {
                transform.GetChild(childIndexToMakeBuildable).GetComponent<Tile>().MakeBuildable();
                isMakingBuildableProccessCompleted=true;
            }
        } 
    }
    public void Show()
    {
        textMoney.text= numberI.ToString() +"\n" + "$" + cost.ToString();
    }
}
