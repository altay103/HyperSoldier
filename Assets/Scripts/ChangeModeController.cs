using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
            if (soldiers.Length > 0)
            {
                if (soldiers[0].GetComponent<SoldierModeController>().soldierTypes.Count > 1)
                {
                    SoldierModeController.Mode++;
                    if (SoldierModeController.Mode > (soldiers[0].GetComponent<SoldierModeController>().soldierTypes.Count - 1))
                    {
                        SoldierModeController.Mode = 0;
                    }
                }
            }
        }
    }
}
