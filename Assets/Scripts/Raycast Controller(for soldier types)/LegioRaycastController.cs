using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegioRaycastController : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;//rayin ne kadar uzaklýða bakýcaðýný tutuyor
    [HideInInspector]
    public Ray ray;//rayi tutuyor
    Vector3 direction;
    
    /*
     * Bu scriptin amacý her birliðin saldýrma mesafesine animasyonlarýný ve 
     * hasar verme iþlerini baþlatma ihtiyacý gerekmiþ . Bu yüzden özel raycast atýlma iþi oluþmuþtur.
     * sanýrsam okçularýn en uzun menzili olur sonra flanklerin sonra ise lejyonlarýn
     * Buda lejyonlar için 
     */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = -transform.up;
        ray = new Ray(transform.position, direction);//ray oluþturuyoruz
        RaycastHit hit;//nereye çarptýðýný tutuyor
        if(Physics.Raycast(ray,out hit, distance))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);//Debug yapabilmek için ýþýný çiziyoruz
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + direction * distance, Color.red);//Debug yapabilmek için ýþýný çiziyoruz
        }
    }
}
