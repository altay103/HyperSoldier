using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderPositionController : MonoBehaviour
{
    // Start is called before the first frame update
   
    Animator anim;
    Ray ray;
    Transform child;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.childCount>0)
        {
            anim =transform.GetChild(0).gameObject.GetComponent<Animator>();
            ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

            if (Physics.Raycast(ray, out hit, 300))
            {
                Debug.Log("hit");
                if (hit.collider.tag == "Soilder")
                {

                    anim.SetBool("Back", true);
                }
                else
                {
                    anim.SetBool("Back", false);
                }

            }
            else
            {
                anim.SetBool("Back", false);
            }
        }
    }
}
