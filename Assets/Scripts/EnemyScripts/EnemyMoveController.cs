using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    public float triggerDistance = 30;//ne kadar mesafe sonra tetiklence�ini tutar

    NavMeshAgent agent;//enemyin agent componetini tutar

    GameObject nearSoldier;//yak�ndaki dost askeri tutar
    float distance;//ve en yak�n dost askerin ne kadar yak�n oldu�unu 
    /*
        Bu scriptin amac� d��man� dost birliklere do�ru ilerletmektir.
        Belli bir mesafe yakla��ld���nda dost birliklere do�ru ilerler.
        Ve sava� ba�lar .
     */
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//componeti �ekiyoruz
    }
    void Update()
    {
        SetNearSoldier();//en yak�ndaki dost askeri buluyor
        if ((nearSoldier != null) && (distance<=triggerDistance))//en yak�ndaki asker bo� de�ilse yani bulmu�sa ve tetiklenme mesafesi a��lm��sa
        {
            //Debug.Log("Chargeee!");
            agent.SetDestination(nearSoldier.transform.position);//en  yak�ndaki askerin konuma hareket sa�l�yoruz 
        }
        
        
    }
    void SetNearSoldier()
    {
        
        float minDistance;
        minDistance = float.MaxValue;

        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
        if (soldiers.Length > 0)
        {
            foreach (GameObject soldier in soldiers)
            {
                if(minDistance> Mathf.Abs(Vector3.Distance(soldier.transform.position,transform.position)))
                {
                    minDistance = Mathf.Abs(Vector3.Distance(soldier.transform.position, transform.position));
                    nearSoldier = soldier;
                }
            }
        }
        else
        {
            nearSoldier = null;
            Debug.Log("Bo�");
        }
        distance = minDistance;
        
    }
}
