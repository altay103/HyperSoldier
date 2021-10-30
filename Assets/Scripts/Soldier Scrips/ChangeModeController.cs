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
        int Mode = ModeController.Mode;
        List<GameObject> soldierTypes = GameObject.Find("ModeManager").GetComponent<ModeController>().soldierTypes;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] soldiers = GameObject.FindGameObjectsWithTag("Soldier");
            if (soldiers.Length > 0)
            {
                if (soldierTypes.Count > 1)
                {
                    Mode++;
                    if (Mode > (soldierTypes.Count - 1))
                    {
                        Mode = 0;
                    }
                }
            }
        }
    }
}
