using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CheckStatus", 3);
    }
    void CheckStatus()
    {
       
        if (GameObject.FindGameObjectsWithTag("Soldier").Length == 0)
        {
            Text text;
            text=GetComponent<Text>();
            text.enabled = true;
            text.color = Color.red;
            text.text = "You Lost \n Try Again?";
            
            Time.timeScale = 0;
        }
        else if(GameObject.Find("Leader").transform.position.z>460)
        {
            Text text;
            text = GetComponent<Text>();
            text.enabled = true;
            text.text = "You Win!";
            text.color = new Color(195,0,255);
            Time.timeScale = 0;
        }
    }
}
