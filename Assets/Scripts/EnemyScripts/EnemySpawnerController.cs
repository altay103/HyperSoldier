using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject enemy;//Enemy Prefabýný tutuyor koyulmasý þart
    public GameObject enemyType;//spawn edilcek enemyi tutuyor
    public int rowLenght = 1;//satýr sayýsýný tutuyor
    public int columnLenght = 1;//sutun sayýsýný tutuyor
    public float margin = 0.3f;//aralardaki boþluklarý tutuyor
    Vector3 size;//boyutlarý tutuyor

    /*
     * Bu scriptin amacý gruplar halinde düþma yerleþtirmeyi kolaylaþtýrmasýdýr
     * kaça kaç sýra ile ve aralarýnda ne kadar boþluk kalýcak ne spawn edilcek gibi deðerleri dolduruyoruz
     * ve bunu harita üzerine diziyor .
     * emptyGameObjecte atýlan bir scripttir.
     */
    void Awake()
    {
        size = enemy.transform.localScale;//yüklenen enemy prefabýn boyutunu alýyoruz .
        for (int i = 0; i < rowLenght; i++)
        {
            for (int j = 0; j < columnLenght; j++)
            {
                Vector3 position;//spawn olucak pozisyonu tutuyor
                GameObject tempEnemy;//spawn olan enemyi tutuyor

                /*dizme iþleminde kullanýlan matematiksel hesaplar Yeni konum hesaplarý */
                position.z = transform.position.z - (i * (size.z + margin));
                position.x = transform.position.x - (j * (size.x + margin));
                position.y = transform.position.y;
                
                /*enemy objesini create ettiyor ederken nerye bakarak create olucaðýný empty objenin baktýðý yön olarak belirliyoruz*/
               tempEnemy= Instantiate(enemy, position, Quaternion.LookRotation(transform.forward));
                /*create olan enemy objesinin içinde hangi enemytipini yerleþtiriyoruz*/
               tempEnemy.GetComponent<EnemyCreateController>().enemy = enemyType;

            }
        }
        Destroy(gameObject);//iþini yapan empty objeyi siliyoruz 
    }




}
