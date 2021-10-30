using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject leader;
    public float distance = 10;
    void Start()
    {
        leader = GameObject.Find("Leader");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(transform.position.x, transform.position.y, leader.transform.position.z - distance);
        transform.position=target;
      
    }
}
