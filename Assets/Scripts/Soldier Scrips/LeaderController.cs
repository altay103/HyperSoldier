using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderController : MonoBehaviour
{
   
    public float speed = 2;//liderin hızı
    GameObject input;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float hor = GameObject.Find("InputManager").GetComponent<InputController>().HorizontalAxis;

        transform.Translate(speed*hor * Time.deltaTime, 0,speed* Time.deltaTime,Space.World);//alınan verilere göre hareket sağladık
        

  

    }
}
