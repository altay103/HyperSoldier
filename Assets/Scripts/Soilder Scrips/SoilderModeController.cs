using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderModeController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> soilderTypes;
    public static int Mode = 0;//PhalanxMan ArcherMan vs
    int mode;

    void Start()
    {

        mode = -1;
    }

    // Update is called once per frame
    void Update()
    {
        CreateChild(mode);
        mode = Mode;
    }
    void CreateChild(int mode)
    {
        GameObject tempChild;

        if (mode != Mode)
        {
            if (transform.childCount > 0)
            {
                tempChild = transform.GetChild(0).gameObject;
                Destroy(tempChild);
            }
            tempChild = Instantiate(soilderTypes[Mode], transform.position, Quaternion.identity);
            tempChild.transform.parent = transform;
            //tempChild.transform.Rotate(-90, 0, 0);
            //tempChild.transform.Translate(0, 0, 1);
        }
    }
}
