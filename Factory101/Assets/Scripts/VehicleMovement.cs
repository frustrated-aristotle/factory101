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

        /* 0
        Vector2 moveInput = new Vector2(target.transform.position.x, target.transform.position.y);
        moveVelocity = moveInput * speed;
        */

        /* 1--
        Vector2 target2d= new Vector2(target.transform.position.x, target.transform.position.y);
        Vector2 vehicle2d = new Vector2(transform.position.x, transform.position.y);
        rb.AddForce(target2d * Time.deltaTime *speed* -1);
        */

        /* 2--
        moveDir=target.transform.position - transform.position;
        this.transform.Translate(moveDir * speed * Time.deltaTime);
        */
    }

    /*
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    */

    public void ChangeTarget()
    {
        arranger = arranger * -1;
        //transform.localRotation= new Quaternion(0,180,0, 0);
        helder=target;
        target=home;
        home=helder;
    }
}
