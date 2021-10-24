using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;//yerle�tirilecek modeli tutar
    
    bool created = false;//bir kontrol de�i�keni
   
    /*
     * D��man�n i�ine model yerle�tiren scripttir
     * Bu script sayesinde tek tek enemy olu�turmay� veyahutta s�r� halinde olu�turmaya olanak tan�r .
     * Tek tek olu�turmak i�in enemy prefab�n� sahneye b�rakmal� ve enemy k�sm�na istenilen obje konulmal�d�r 
     * S�r� halinde ise sahneye enemy spawner  b�rak�lmal� ve i�indeki de�erler doldurulmal�d�r.
     */

    // Update is called once per frame
    void Update()
    {
        if((!created)&&(enemy != null))//daha �nce olu�turulmam�� ise veyahutta 
        {
            created = true;
            /*
             * Yarat�ld� ve parent olarak enemy atand� 
             */
            Instantiate(enemy, transform.position, transform.rotation).transform.SetParent(transform);

        }
    }
}
