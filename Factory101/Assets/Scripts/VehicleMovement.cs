using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public GameObject home;
    public GameObject target;
    public GameObject helder;
    Vector3 moveDir;

    CharacterController charC;
    public float speed;

    void Start()
    {
        charC=GetComponent<CharacterController>();
    }
    void Update()
    {
        moveDir=target.transform.position - transform.position;
        charC.Move(moveDir * Time.deltaTime * speed);
    }
}
