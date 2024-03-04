using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class RoadManager : MonoBehaviour
{
    /// <summary>
    /// We should check if the new road has already created.
    /// To do so, we need to search for home and targets of roads.
    /// To accomplish this, we need created roads. They can be stored in RoadManager, this way we can get them whenever we want.
    /// When we are ready to create a new road, we should find roads that has the same home node, then check if one of them has the same target. IF so, clear nodes and alert!.

    /// </summary>

    [SerializeField]
    private LineRenderer roadTemplate;

    public Transform home;
    public Transform target;

    public List<LineRenderer> roads = new List<LineRenderer>();

    public Transform parent;
    /// <summary>
    /// Takes a home position and a target position to create the building in between.
    /// </summary>
    public void BuildRoad()
    {
        Debug.Log("Building the road. ");
        roadTemplate.SetPosition(0, GetPos(home));
        roadTemplate.SetPosition(1, GetPos(target));
        roadTemplate.useWorldSpace = false;
        roadTemplate.transform.GetChild(1).GetComponent<LineRenderer>().SetPosition(0, GetPos(home));
        roadTemplate.transform.GetChild(1).GetComponent<LineRenderer>().SetPosition(1, GetPos(target));
        roadTemplate.transform.GetChild(1).gameObject.SetActive(false);
        LineRenderer instantiated =  Instantiate(roadTemplate, Vector3.zero, quaternion.identity);
        instantiated.GetComponent<Road>().home = home.gameObject;
        instantiated.GetComponent<Road>().target = target.gameObject;
        instantiated.transform.SetParent(parent);
        roads.Add(instantiated);
        ClearNodes();
    }

    private bool CheckState()
    {
        bool returnVal =FindObjectOfType<StateManager>().currentState.type == StateType.Purchase;
        if (!returnVal)
        {
            ClearNodes();
        }
        return returnVal;
    }


    public void OnNodeSelected(Transform node)
    {
        if (home == null)
        {
            //May show a text says: "Select the base tile."
            home = node;
        }
        else if (target == null)
        {
            if (CheckOrder(node) && home != node)
            {
                target = node;
            }
            //May show a text says: "Select the target tile."
        }
        //Build road when the state is not changed and both home and target has been selected.
        if (home && target && CheckState() && !IsExist())
        {
            BuildRoad();
        }
    }

    private bool IsExist()
    {
        foreach (var road in roads)
        {
            if (road.gameObject.activeSelf)
            {
                if (road.GetComponent<Road>().home.transform == home)
                {
                    if (road.GetComponent<Road>().target.transform == target)
                    {
                        Debug.Log("It exists.");
                        ClearNodes();
                        return true;
                    }
                }
            }

        }
        return false;
    }

    //We only can build roads in between two nodes at the same level or home is one more than target node.
    private bool CheckOrder()
    {
        int homeType = (int)home.GetComponent<IPurchasable>().GetPurchasableType();
        int targetType = (int)target.GetComponent<IPurchasable>().GetPurchasableType();
        if (homeType >= targetType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckOrder(Transform node)
    {
        int homeType = (int)home.GetComponent<Tile>().building.GetPurchasableType();
        int targetType = (int)node.GetComponent<Tile>().building.GetPurchasableType();
        if (homeType <= targetType)
        {
            return true;
        }
        ClearNodes();
        return false;
    }
    public void ClearNodes()
    {
        home = null;
        target = null;
    }

    private Vector3 GetPos(Transform node)
    {
        Vector3 tempPos = node.position;
        tempPos.z = -1;
        return tempPos;
    }
}