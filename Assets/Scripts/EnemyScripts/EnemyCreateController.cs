using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;//yerleþtirilecek modeli tutar
    
    bool created = false;//bir kontrol deðiþkeni
   
    /*
     * Düþmanýn içine model yerleþtiren scripttir
     * Bu script sayesinde tek tek enemy oluþturmayý veyahutta sürü halinde oluþturmaya olanak tanýr .
     * Tek tek oluþturmak için enemy prefabýný sahneye býrakmalý ve enemy kýsmýna istenilen obje konulmalýdýr 
     * Sürü halinde ise sahneye enemy spawner  býrakýlmalý ve içindeki deðerler doldurulmalýdýr.
     */

    // Update is called once per frame
    void Update()
    {
        if((!created)&&(enemy != null))//daha önce oluþturulmamýþ ise veyahutta 
        {
            created = true;
            /*
             * Yaratýldý ve parent olarak enemy atandý 
             */
            Instantiate(enemy, transform.position, transform.rotation).transform.SetParent(transform);

        }
    }
}
