using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Deals", fileName = "Deal")]
public class DealSO : ScriptableObject
{
    public string dealerName;

    [Header("Main Properties")]
    public int orderedQuantity;
    public float profit;
    public float loss;
    public float dueTime;
    public ProductType type;
    [Header ("Texts")]
    public TextMeshProUGUI dealerNameTxt;
    public TextMeshProUGUI orderedQuantityTxt;
    public TextMeshProUGUI dueTimeTxt;
    public TextMeshProUGUI profitTxt;
    public TextMeshProUGUI lossTxt;

    [HideInInspector] 
    public bool isDone = false;

    public int dealLevel;
}
