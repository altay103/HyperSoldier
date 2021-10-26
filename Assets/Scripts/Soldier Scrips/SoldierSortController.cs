using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoldierSortController : MonoBehaviour
{
    public int lenght = 5;//bu değişken kaç sıra dolunca arkaya geçicek onu tutuyor
    public float margin = 0.5f; //bu ise aralarda ne kadar boşluk olucak onu tutuyor
    
    static int ID = 1;//static id 
    NavMeshAgent agent;//ai hareketi için gerekli componeti tutuyor
    [HideInInspector]
    public GameObject leader;//lideri tutuyor
    [HideInInspector]
    public Vector3 target;//gidilecek hedef konumu tutuyor
    [HideInInspector]
    public Vector3 size;//askerin boyutunu tutuyor
    [HideInInspector]
    public int order = 0;//sıra numaramızı tutuyor
    [HideInInspector]
    public int id;//idyi tutuyor
    [HideInInspector]
    public bool newState = false;//yeni durum varmı onu tutuyor

    void Start()
    {
        id = ID++;//id alındı
        size = transform.localScale;//boyut atandı
        agent = GetComponent<NavMeshAgent>();//ai componenti alındı
        //GameObject.Find("Commander").GetComponent<CommanderController>().newState = true;
        
        /*Şimdilik verilen değerler*/
        order = 0;
        target = transform.position;
        leader = gameObject;

        
        SetLeader();//lider belirlendi
        /*
         Oyunda Lider olmaz ise hata vericektir.
         Veya Sonradan Lider Oluşturulursa görmücektir.
        Olurda böyle bir hata ile karşılanırsan liderin değiştiği durumda SetLeader() fonkunu çağır
         */
    }

    // Update is called once per frame
    void Update()
    {

        if (newState)//yeni bir durum oldu(örn Komutan sırayı değiştirdi çünkü biri ölmüş yada bir katılmış)
        {

            newState = false;
            SetOrder();//sıramız belirleniyor
        }

        
       
        SetTarget();//yeni konum belirlenir
        agent.SetDestination(target);//asker yeni konuma doğru gider

        //Debug.Log(order);

    }
    void SetOrder()
    {
        order = 0;//order 0 dan başlar
        List<int> sortData = GameObject.Find("Commander").GetComponent<CommanderController>().sortData;//sortData çekilir
        //aşağıda ise kaçıncı sırada olduğumuzu arıyoruz
     
        foreach (int data in sortData)
        {
            if (data == id)
            {
                break;
            }
            order++;
        }
        //sonuç olarak order değişkeni güncelleniyor 
    }
    void SetTarget()
    {
        if (leader != null)//lider varsa gircek
        {
            /*tek boyutlu bir listeyi 2 boyutlu bir hale çevirmek için 
             * gerekli matematik işlemleri
             */
            int row, column;
            row = order / lenght;
            column = order % lenght;
            

            //elimizdeki konum değerlerini kullanarak ve
            //lideri referans alarak yeni hedef konumumuzu belirliyoruz
            target.z = leader.transform.position.z - (row * (size.z + margin));
            target.x = leader.transform.position.x - (column * (size.x + margin));
            target.y = leader.transform.position.y;
        }

    }
    void SetLeader()
    {
        leader = GameObject.Find("Leader");//lider tagına sahip kişi bulundu 
        //genelede boş bir gameobjecte veririz bunu tagı 
    }
    

}
