using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderController : MonoBehaviour
{
   
    public float speed = 2;//liderin hızı
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");//ileri geri tuşlarının basılma değerini aldık
        float hor = Input.GetAxis("Horizontal");//sağ sol tuşlarının basılma değerlerini aldık

        transform.Translate(speed*hor * Time.deltaTime, 0,speed* ver * Time.deltaTime);//alınan verilere göre hareket sağladık

    }
}
