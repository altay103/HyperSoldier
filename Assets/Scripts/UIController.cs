using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    Text modetext;
    void Start()
    {
        
        modetext = GameObject.Find("ModeText").GetComponent<Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        modetext.text = "Mode : " + GameObject.Find("ModeManager").GetComponent<ModeController>().modeCount.ToString();
    }
}
