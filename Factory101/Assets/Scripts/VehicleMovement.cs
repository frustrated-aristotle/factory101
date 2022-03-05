using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public GameObject home;
    public GameObject target;
    public GameObject helder;
    public GameObject realHome;
    public GameObject realTarget;
    private float arranger=1;
    Rigidbody2D rb;
    Vector3 moveDir;

    public float speed;
    public Vector2 moveVelocity;
    
    void Start()
    {
        home=realHome;
        target=realTarget;
        rb= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Road")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }

    public void ChangeTarget()
    {
        arranger = arranger * -1;
        //transform.localRotation= new Quaternion(0,180,0, 0);
        helder=target;
        target=home;
        home=helder;
    }
}
