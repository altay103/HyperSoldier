using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject obj;
    public int number;
    public float spawnTime;
   
    bool control = true;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (control)
        {
            Invoke("Spawn", spawnTime);
            control = false;
        }
        if (number <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Spawn()
    {
        control = true;
        Instantiate(obj, transform.position, Quaternion.identity);
        GameObject.Find("Commander").GetComponent<CommanderController>().newState = true;
        number--;
    }
}
