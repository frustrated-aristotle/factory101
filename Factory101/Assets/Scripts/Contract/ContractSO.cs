using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Contracts" ,fileName = "Contract")]
public class ContractSO : ScriptableObject
{
    public string dealerName;

    [Header("Main Properties")]
    public int orderedQuantity;
    public float profit;
    public float loss;
    public float dueTime;
    
    [Header ("Texts")]
    public TextMeshProUGUI dealerNameTxt;
    public TextMeshProUGUI orderedQuantityTxt;
    public TextMeshProUGUI dueTimeTxt;
    public TextMeshProUGUI profitTxt;
    public TextMeshProUGUI lossTxt;
    
    
}