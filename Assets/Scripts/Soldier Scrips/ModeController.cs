using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModeController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> soldierTypes;//asker tiplerini tutuyor 
    public static int Mode = 0;//LegionMan=0 PhalanxMan=1 ArcherMan=2 vs ilerde eklenirse buraya eklenicek 
    public int modeCount =5;
    public int startMode=0;
    void Start()
    {
        Mode = startMode;
        
    }
    private void Awake()
    {
        InteractiveControl(mode:startMode);
    }
    void Update()
    {
        if (modeCount == 0)
        {
            InteractiveControl(standard:false);
        }
    }

    void ChangeMode(string soldierName)
    {
        for(int i=0;i<soldierTypes.Count;i++)
        {
            if (soldierTypes[i].name == soldierName)
            {
                Mode = i;
                break;
            }
        }
    }
    void InteractiveControl(int mode=-1,string name="",bool standard = true)
    {
        if (mode != -1)
        {
            for(int i = 0; i < soldierTypes.Count; i++)
            {
                if (i == mode)
                {
                    name = soldierTypes[i].name;
                    break;
                }
            }
        }
        GameObject.Find("BowButton").GetComponent<Button>().interactable = standard;
        GameObject.Find("ShieldButton").GetComponent<Button>().interactable = standard;
        GameObject.Find("SpearButton").GetComponent<Button>().interactable = standard;

        bool control = true;
        foreach(GameObject soilder in soldierTypes)
        {
            if (soilder.name == name)
            {
                control = false;
                break;
            }
        }
        if (control)
        {
            name = "";
        }
        if (name != "")
        {
            switch (name)
            {
                case "LegionMan":
                    GameObject.Find("ShieldButton").GetComponent<Button>().interactable = !standard;
                    break;
                case "PhalanxMan":
                    GameObject.Find("SpearButton").GetComponent<Button>().interactable = !standard;
                    break;
                case "JanissaryMan":
                    GameObject.Find("BowButton").GetComponent<Button>().interactable = !standard;
                    break;
            }
           
        }
        
    }
   
    public void BowClick()
    {
        ChangeMode("JanissaryMan");
        InteractiveControl(name:"JanissaryMan");
        modeCount--;

    }

    public void SpearClick()
    {
        ChangeMode("PhalanxMan");
        InteractiveControl(name:"PhalanxMan");
        modeCount--;
    }

    public void ShieldClick()
    {
        ChangeMode("LegionMan");
        InteractiveControl(name:"LegionMan");
        modeCount--;
    }

   
}
