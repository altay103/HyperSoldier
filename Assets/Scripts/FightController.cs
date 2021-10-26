using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage=50;
    public string enemyTag = "Enemy";
    Ray ray;
    bool control = true;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (control)
        {
            control = false;
            Invoke("Damage", 1);
            
        }
    }
    void Damage()
    {
        ray = GetComponent<RaycastController>().ray;
        control = true;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, GetComponent<RaycastController>().distance))
        {
            
            if (hit.collider.gameObject.tag == enemyTag)
            {
                hit.collider.gameObject.transform.GetChild(0).GetComponent<DeathController>().health -= damage;
                Debug.Log("Fight bro");
            }

        }
    }
}
