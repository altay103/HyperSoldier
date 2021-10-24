using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Iman.Power;
public class SoldierModeController : MonoBehaviour
{


    public List<GameObject> soldierTypes;//asker tiplerini tutuyor 
    /*
     Eklemeler sıralı yapılmalı 
     Static mode değişlenine atılan ilk değer doğar doğmaz çıkıcak askeri temsil eder
     */
    public static int Mode = 0;//LegionMan=0 PhalanxMan=1 ArcherMan=2 vs ilerde eklenirse buraya eklenicek 
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
        CreateChild(mode);//moda göre child spawn ediyoruz
        mode = Mode;
    }
    void CreateChild(int mode)
    {
        if (mode != Mode)//şayet anlık mod static moddan farklı ise 
        {
            GameObject tempChild;//işlem yapıcağımız gameobject seçiyoruz
            Quaternion rotation=Quaternion.identity;//yaratılacak askerin yönünü tutuyor
            if (transform.childCount > 0)//şayet halihazırda çocuk varsa
            {
                tempChild = transform.GetChild(0).gameObject;//çocuğu çektik
                tempChild.transform.Rotate(90, 0, 0);
                rotation = tempChild.transform.rotation;//eski askerin yönünü alıyoruz
                Destroy(tempChild);//sonra destroy ettik
            }
            tempChild = Instantiate(soldierTypes[Mode], transform.position, rotation);//istenen tipte askermodeli spawn ettik
            tempChild.transform.parent = transform;//bu askeride childimiz yaptık

            //mode = Mode;//anlık modu statik mod ile eşitledik

            //ReFix
            
            


        }
    }
}
