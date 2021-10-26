using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderController : MonoBehaviour
{
    [HideInInspector]
    public bool newState=false;//bu yeni bir sıralama olup olmadığını kaydediyor
    [HideInInspector]
    public List<int> sortData;//bu sıralamayı tutuyor 
    
    /*
     sıra dizilimi id lere göre yapılır
     yeni doğan her askere bir id verilir . 
     Sıralama da sondakiler arkadaya geçicek şekilde yapılır 
     bu scriptin yaptığı tek şey yeni sıraları ayarlayıp 
     askerleri yeni sıraya yapıldı yerlerinizi düzenleyin demektir (onların newStateni true yapıcak )
     */
    // Update is called once per frame
    void Update()
    {
        if (newState)//yeni bir durum olmuşsa (biri ölmüş yada gruba yeni biri katılmış)
        {
            newState = false;
         
            SortSoldier();//sıralama yapılır
            WakeUp();//askerlere yeni sıralama yapıldığı haber edilir (Onlarında kendi içinde newState sistemi var)
        }
    }
    void SortSoldier()
    {
        if (sortData.Count > 0)//sıralama bilgisini tutan liste boş değilse
        {
            sortData.Clear();//temizleyelim
        }
      
        GameObject[] soldiers=GameObject.FindGameObjectsWithTag("Soldier");//Oyundaki bütün askerleri diziye kaydettim
        foreach(GameObject soldier in soldiers)//tek tek askerlerin idlerini alalım ki sıralayabilelim 
        {
            sortData.Add(soldier.GetComponent<SoldierSortController>().id);//ekledik idleri listeye
            
        }
        
        sortData.Sort();//Daha sonra sıraladık bir fonk ile 
        

    }
    void WakeUp()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");//tüm askerleri diziye attık
        foreach (GameObject soldier in soldiers)//tek tek çekip
        {
            soldier.GetComponent<SoldierSortController>().newState=true;//yeni durum oldu dedik yani newState i true yaptık
        }
    }
}
