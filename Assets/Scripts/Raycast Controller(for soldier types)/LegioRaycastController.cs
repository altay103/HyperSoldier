using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegioRaycastController : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;//rayin ne kadar uzakl��a bak�ca��n� tutuyor
    [HideInInspector]
    public Ray ray;//rayi tutuyor
    Vector3 direction;
    
    /*
     * Bu scriptin amac� her birli�in sald�rma mesafesine animasyonlar�n� ve 
     * hasar verme i�lerini ba�latma ihtiyac� gerekmi� . Bu y�zden �zel raycast at�lma i�i olu�mu�tur.
     * san�rsam ok�ular�n en uzun menzili olur sonra flanklerin sonra ise lejyonlar�n
     * Buda lejyonlar i�in 
     */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = -transform.up;
        ray = new Ray(transform.position, direction);//ray olu�turuyoruz
        RaycastHit hit;//nereye �arpt���n� tutuyor
        if(Physics.Raycast(ray,out hit, distance))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);//Debug yapabilmek i�in ���n� �iziyoruz
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + direction * distance, Color.red);//Debug yapabilmek i�in ���n� �iziyoruz
        }
    }
}
