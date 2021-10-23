using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRecruitmentController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soldier;
    /*
     Bu scriptin amac� Asker Toplamakt�r
     Temas etti�imiz protomanleri soldiera �evirir(Onlar� yok edip soldier yarat�r)
    */
  
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ProtoMan")//Askerin �arpt��� protoman ise yani toplan�cak asker ise
        {
            Vector3 protoPosition = collision.gameObject.transform.position;//ilk �nce pozisyonunu al�yoruz ilerde kullan�caz
            Destroy(collision.gameObject);//sonra yok ediyoruz
            Instantiate(soldier, protoPosition, Quaternion.identity);//sonra ald���m�z pozisyona bir asker spawnl�yoruz
        }
    }
}
