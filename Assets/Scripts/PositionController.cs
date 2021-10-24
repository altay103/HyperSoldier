using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{

    public float distance;//işlem mesafesi (ışın mesafesi)
    public string friendTag;
    public string enemyTag;
    float childDistance;
    Animator anim;//Askerin içindeki modelin animator componenti
    Ray ray;//ışın atıcaz onun değişkeni
    Ray childRay;//çocuğumuzun ışını
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
              
                if (hit.collider.tag == friendTag)//şayet dost askere çarpar ise 
                {

                    BackIdle();//Arka sıra animasyonu
                }
                else
                {
                    Idle();//Ön Sıra animayonu
                }

            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.forward*distance, Color.green);//debug için cizgi çekiyoruz 
                Idle();//Ön Sıra animasyonu 
            }
        }
    }


    /* İş Kolaylaştıran fonksiyonlar */
    void Idle()
    {
        childRay = transform.GetChild(0).gameObject.GetComponent<RaycastController>().ray;//çocuğun ışını aldık
        childDistance = transform.GetChild(0).gameObject.GetComponent<RaycastController>().distance;//çocuğun ışın mesafesini aldık
        RaycastHit childHit;//çocuğumuzun çarptığı obje
        
        /*Bu kısım idle kısım*/
        anim.SetBool("Back", false);//arka sıra animasyonu (orn legionMan için kalkan kaldırma) 
        anim.SetBool("Fight", false);//kavga animasyonu 
        
        /*idle olmadan kavga olmuyor bu yüzden idle animasyonu pozisyonuna geçince
         *bakıyoruz kavga lazım mı :D
         */
        if (Physics.Raycast(childRay, out childHit, childDistance))//çocuğun ışını bir yere çarptı mı bakıyoruz
        {
            if (childHit.collider.tag == enemyTag)//şayet düşmana çarpar ise
            {
                Fight();//Kavga animasyonu
            }
            
        }
    }
    void BackIdle()
    {
        anim.SetBool("Back", true);//arka sıra animasyonu (orn legionMan için kalkan kaldırma) 
        anim.SetBool("Fight", false);//kavga animasyonu 
    }
    void Fight()
    {
        anim.SetBool("Back", false);//arka sıra animasyonu (orn legionMan için kalkan kaldırma) 
        anim.SetBool("Fight", true);//kavga animasyonu 
    }
}
