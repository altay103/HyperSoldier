using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health=100;
    public bool news = true;
    public GameObject effect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            if (news)
            {
                ManuelDestroy();
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
    void ManuelDestroy()//olurda ilerde ölme filan iþlemleri olursa bu fonksiyon ile ölücez
    {
        //destroya ek olarak ölümü komutana iletir bu sayaede yeni düzen hazýrlanýr 
        GameObject.Find("Commander").GetComponent<CommanderController>().newState = true;
        Destroy(gameObject.transform.parent.gameObject);

    }
}
