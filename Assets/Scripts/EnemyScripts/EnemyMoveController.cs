using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    public float triggerDistance = 30;//ne kadar mesafe sonra tetiklenceðini tutar

    NavMeshAgent agent;//enemyin agent componetini tutar

    GameObject nearSoldier;//yakýndaki dost askeri tutar
    float distance;//ve en yakýn dost askerin ne kadar yakýn olduðunu 
    /*
        Bu scriptin amacý düþmaný dost birliklere doðru ilerletmektir.
        Belli bir mesafe yaklaþýldýðýnda dost birliklere doðru ilerler.
        Ve savaþ baþlar .
     */
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//componeti çekiyoruz
    }
    void Update()
    {
        SetNearSoldier();//en yakýndaki dost askeri buluyor
        if ((nearSoldier != null) && (distance<=triggerDistance))//en yakýndaki asker boþ deðilse yani bulmuþsa ve tetiklenme mesafesi aþýlmýþsa
        {
            //Debug.Log("Chargeee!");
            agent.SetDestination(nearSoldier.transform.position);//en  yakýndaki askerin konuma hareket saðlýyoruz 
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
            Debug.Log("Boþ");
        }
        distance = minDistance;
        
    }
}
