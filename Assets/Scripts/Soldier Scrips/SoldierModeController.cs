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
    int mode=-1;//modu tutuyoruz ilk defa çalışacağında çalışması için -1 gibi anlamsız bir değer atadım.
    /*
     Bu Script
     Asker modunu ayarlıyor
     Şayet dışardan static Mode değişkeni değiştirileceke olursa mod değişecektir.
     
     */
 

    void Update()
    {
        CreateChild(mode);//moda göre child spawn ediyoruz
        
    }
    void CreateChild(int mode)
    {
        if (mode != Mode)//şayet anlık mod static moddan farklı ise 
        {
            GameObject tempChild;//işlem yapıcağımız gameobject seçiyoruz
            if (transform.childCount > 0)//şayet halihazırda çocuk varsa
            {
                tempChild = transform.GetChild(0).gameObject;//çocuğu çektik
                Destroy(tempChild);//sonra destroy ettik
            }
            tempChild = Instantiate(soldierTypes[Mode], transform.position, Quaternion.identity);//istenen tipte askermodeli spawn ettik
            tempChild.transform.parent = transform;//bu askeride childimiz yaptık

            mode = Mode;//anlık modu statik mod ile eşitledik
            
        }
    }
}
