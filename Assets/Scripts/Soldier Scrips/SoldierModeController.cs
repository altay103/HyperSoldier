using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Iman.Power;
public class SoldierModeController : MonoBehaviour
{

    List<GameObject> soldierTypes;
    int Mode=0;
    /*
     Eklemeler sıralı yapılmalı 
     Static mode değişlenine atılan ilk değer doğar doğmaz çıkıcak askeri temsil eder
     */

    int mode = -1;//modu tutuyoruz ilk defa çalışacağında çalışması için -1 gibi anlamsız bir değer atadım.
    /*
     Bu Script
     Asker modunu ayarlıyor
     Şayet dışardan static Mode değişkeni değiştirileceke olursa mod değişecektir.
     
     */
    void Start()
    {
        GameObject.Find("Commander").GetComponent<CommanderController>().newState = true;//komutana haber edildi yeni durum var diye
                                                                                         //Çünkü Yeni Asker Geldi 
    }

    void Update()
    {
        Mode = ModeController.Mode;
        soldierTypes = GameObject.Find("ModeManager").GetComponent<ModeController>().soldierTypes;
        CreateChild(mode);//moda göre child spawn ediyoruz
        mode = Mode;
    }
    void CreateChild(int mode)
    {
        if (mode != Mode)//şayet anlık mod static moddan farklı ise 
        {
            
            GameObject tempChild;//işlem yapıcağımız gameobject seçiyoruz
            Quaternion rotation = Quaternion.identity;//yaratılacak askerin yönünü tutuyor
            if (transform.childCount > 0)//şayet halihazırda çocuk varsa
            {

                tempChild = transform.GetChild(0).gameObject;//çocuğu çektik
                rotation = tempChild.transform.rotation;//eski askerin yönünü alıyoruz
                Destroy(tempChild);//sonra destroy ettik
                tempChild = Instantiate(soldierTypes[Mode], transform.position, rotation);//istenen tipte askermodeli spawn ettik
                tempChild.transform.parent = transform;//bu askeride childimiz yaptık
            }
            else
            {
                //Debug.Log(gameObject.GetComponent<SoldierSortController>().id);
                tempChild = Instantiate(soldierTypes[Mode], transform.position, rotation);//istenen tipte askermodeli spawn ettik
                tempChild.transform.parent = transform;//bu askeride childimiz yaptık
                tempChild.transform.Rotate(-90, 0, 0);//yatık bir şekilde geldiği için diktim 90 derece x ekseninde
               
            }
            tempChild.transform.Translate(0, 0, 1);//origin merkeze olduğu için yarısı kadar ileri

            //mode = Mode;//anlık modu statik mod ile eşitledik

            //ReFix




        }
    }
}
