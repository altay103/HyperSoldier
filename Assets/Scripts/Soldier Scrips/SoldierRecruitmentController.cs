using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRecruitmentController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soldier;
    /*
     Bu scriptin amacý Asker Toplamaktýr
     Temas ettiðimiz protomanleri soldiera çevirir(Onlarý yok edip soldier yaratýr)
    */
  
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ProtoMan")//Askerin çarptýðý protoman ise yani toplanýcak asker ise
        {
            Vector3 protoPosition = collision.gameObject.transform.position;//ilk önce pozisyonunu alýyoruz ilerde kullanýcaz
            Destroy(collision.gameObject);//sonra yok ediyoruz
            Instantiate(soldier, protoPosition, Quaternion.identity);//sonra aldýðýmýz pozisyona bir asker spawnlýyoruz
        }
    }
}
