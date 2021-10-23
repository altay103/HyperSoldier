using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        transform.Translate(speed*hor * Time.deltaTime, 0,speed* ver * Time.deltaTime);

    }
}
