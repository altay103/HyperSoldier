using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderController : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool newState=false;
    [HideInInspector]
    public List<int> sortData;
    [HideInInspector]
    public float id=0;
    [HideInInspector]
    public GameObject leader;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newState)
        {
            newState = false;
            //düzenlemeler yapılır 
            SortSoilder();
            WakeUp();
        }
    }
    void SortSoilder()
    {
        if (sortData.Count > 0)
        {
            sortData.Clear();
        }
      
        GameObject[] soilders=GameObject.FindGameObjectsWithTag("Soilder");
        foreach(GameObject soilder in soilders)
        {
            sortData.Add(soilder.GetComponent<SoilderSortController>().id);
        }
        sortData.Sort();
        
        string log=id.ToString()+':';
        id++;
        foreach(int data in sortData)
        {
            log += ' ' + data.ToString();
        }
        //Debug.Log(log);

        foreach(GameObject soilder in soilders)
        {
            if (soilder.GetComponent<SoilderSortController>().id == sortData[0])
            {
                leader = soilder;
                break;
            }
        }

    }
    void WakeUp()
    {
        GameObject[] soilders = GameObject.FindGameObjectsWithTag("Soilder");
        foreach (GameObject soilder in soilders)
        {
            soilder.GetComponent<SoilderSortController>().newState=true;
        }
    }
}
