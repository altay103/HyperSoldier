using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SoilderSortController : MonoBehaviour
{
    public int lenght = 5;
    public float margin = 0.5f; 
    
    static int ID = 1;
    NavMeshAgent agent;
    [HideInInspector]
    public GameObject leader;
    [HideInInspector]
    public Vector3 target;
    [HideInInspector]
    public Vector3 size;
    [HideInInspector]
    public int order = 1;
    [HideInInspector]
    public int id;
    [HideInInspector]
    public bool newState = false;

    void Start()
    {
        id = ID++;
        target = transform.position;
        //Invoke("ManuelDestroy", Random.Range(20.0f, 90.0f));

        size = transform.localScale;
        leader = gameObject;
        

        agent = GetComponent<NavMeshAgent>();
        SetLeader();
        //Debug.Log(id);
    }

    // Update is called once per frame
    void Update()
    {

        if (newState)
        {

            newState = false;
            order = 0;
            List<int> sortData = GameObject.Find("Commander").GetComponent<CommanderController>().sortData;
            foreach (int data in sortData)
            {
                if (data == id)
                {
                    break;
                }
                order++;
            }
            SetLeader();
        }

        
       
        SetTarget();
        agent.SetDestination(target);
        


    }
    void SetTarget()
    {
        if (leader != null)
        {
            int row, column;
            row = order / lenght;
            column = order % lenght;



            target.z = leader.transform.position.z - (row * (size.z + margin));
            target.x = leader.transform.position.x - (column * (size.x + margin));
            target.y = leader.transform.position.y;
        }

    }
    void SetLeader()
    {
        leader = GameObject.Find("Leader");
    }
    void ManuelDestroy()
    {
        GameObject.Find("Commander").GetComponent<CommanderController>().newState = true;
        Destroy(gameObject);

    }

}
