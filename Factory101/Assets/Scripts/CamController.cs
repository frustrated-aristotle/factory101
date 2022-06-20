using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    bool doMovement=true;
    public float panSpeed=30;
    public float scrollSpeed=5;
    
    public float thickness = 10f;
    public float minZ;
    public float maxZ;
    public float posY=15;
    public float posX=15;
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - thickness && transform.position.y <= posY)
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= thickness && transform.position.y >= -posY)
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - thickness && transform.position.x <= posX)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <= thickness && transform.position.x >= -posX)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scrool = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.z += scrool * 1000 * scrollSpeed * Time.deltaTime;
        /* 
        if(pos.z < minZ)
        pos.z=minZ;
        else if(pos.z > maxZ)
        pos.z = maxZ;
        */
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
