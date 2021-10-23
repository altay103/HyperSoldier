using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPositionController : MonoBehaviour
{

    public float distance;//işlem mesafesi (ışın mesafesi)
    Animator anim;//Askerin içindeki modelin animator componenti
    Ray ray;//ışın atıcaz onun değişkeni

    /*
     Bu script
     Asker Animasyonlarını kontrol eden bir scripttir.
     */
    void Update()
    {
        
        if (transform.childCount>0)//Çocuğumuz varmı ona bakıyoruz yoksa girmiyoruz
        {
            anim =transform.GetChild(0).gameObject.GetComponent<Animator>();//animator alındı
            ray = new Ray(transform.position, transform.forward);//local eksende z ekseninde bir ray oluşturuldu
            RaycastHit hit;//ışının çarptığı objeyi tutuyor
           
            
            if (Physics.Raycast(ray, out hit, distance))//ışın bir yere çarparsa
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);//debug için cizgi çekiyoruz (hit için ayrı)
              
                if (hit.collider.tag == "Soldier")//şayet dost askere çarpar ise 
                {

                    anim.SetBool("Back", true);//arka sıra animasyonu (orn legionMan için kalkan kaldırma) 
                    anim.SetBool("Fight", false);//kavga animasyonu
                }
                else if(hit.collider.tag=="Enemy")//şayet düşman askere çarparsa
                {
                    anim.SetBool("Back", false);//ön sıra  animasyonu (orn legionMan için kalkan kaldırma)
                    anim.SetBool("Fight", true);//kavga animasyonu
                }
                else
                {
                    anim.SetBool("Fight", false);//kavga animasyonu
                    anim.SetBool("Back", false);//ön sıra  animasyonu (orn legionMan için kalkan kaldırma)
                }

            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.forward*distance, Color.green);//debug için cizgi çekiyoruz 
                anim.SetBool("Back", false);//arka sıra animasyonu (orn legionMan için kalkan kaldırma) 
                anim.SetBool("Fight", false);//kavga animasyonu 
            }
        }
    }
}
