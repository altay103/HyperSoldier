using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFix : MonoBehaviour
{
    // Start is called before the first frame update

    /*
     * Bu script ise bir üşengeçlik eseridir
     * Asker modellerini yamuk yapmışım daha doğrusu ters eksene bakar şekilde
     * bu yüzden bu transform fix scriptini bozuk olan modellere attım
     * onların transformlarını düzeltiyor 
     */
    void Start()
    {
        transform.Rotate(-90, 0, 0);//yatık bir şekilde geldiği için diktim 90 derece x ekseninde
        transform.Translate(0, 0, 1);//origin merkeze olduğu için yarısı kadar ileri
    }


    
}
