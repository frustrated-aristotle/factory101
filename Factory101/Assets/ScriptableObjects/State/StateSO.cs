using UnityEngine;


[CreateAssetMenu(menuName = "State",  fileName = "State")]
public class StateSO : ScriptableObject
{
    public string stateName;
    public GameObject panel;
    public KeyCode key;
    public StateType type;

    private void OnEnable()
    {
        panel = FindObjectOfType<UIManager>().GetPanel(type);
        if (panel)
        {
            panel.SetActive(false);
        }
    } 

    //Things that will be done when the "key" is pressed
    public void Activated()
    {
        if (panel)
            panel.SetActive(true);
    }

    //Things that will be done when the "key" is pressed
    public void Deactivated()
    {
        if (panel)
            panel.SetActive(false);
    }
}
