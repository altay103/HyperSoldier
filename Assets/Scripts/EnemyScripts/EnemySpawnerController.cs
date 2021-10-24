using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject enemy;//Enemy Prefab�n� tutuyor koyulmas� �art
    public GameObject enemyType;//spawn edilcek enemyi tutuyor
    public int rowLenght = 1;//sat�r say�s�n� tutuyor
    public int columnLenght = 1;//sutun say�s�n� tutuyor
    public float margin = 0.3f;//aralardaki bo�luklar� tutuyor
    Vector3 size;//boyutlar� tutuyor

    /*
     * Bu scriptin amac� gruplar halinde d��ma yerle�tirmeyi kolayla�t�rmas�d�r
     * ka�a ka� s�ra ile ve aralar�nda ne kadar bo�luk kal�cak ne spawn edilcek gibi de�erleri dolduruyoruz
     * ve bunu harita �zerine diziyor .
     * emptyGameObjecte at�lan bir scripttir.
     */
    void Awake()
    {
        size = enemy.transform.localScale;//y�klenen enemy prefab�n boyutunu al�yoruz .
        for (int i = 0; i < rowLenght; i++)
        {
            for (int j = 0; j < columnLenght; j++)
            {
                Vector3 position;//spawn olucak pozisyonu tutuyor
                GameObject tempEnemy;//spawn olan enemyi tutuyor

                /*dizme i�leminde kullan�lan matematiksel hesaplar Yeni konum hesaplar� */
                position.z = transform.position.z - (i * (size.z + margin));
                position.x = transform.position.x - (j * (size.x + margin));
                position.y = transform.position.y;
                
                /*enemy objesini create ettiyor ederken nerye bakarak create oluca��n� empty objenin bakt��� y�n olarak belirliyoruz*/
               tempEnemy= Instantiate(enemy, position, Quaternion.LookRotation(transform.forward));
                /*create olan enemy objesinin i�inde hangi enemytipini yerle�tiriyoruz*/
               tempEnemy.GetComponent<EnemyCreateController>().enemy = enemyType;

            }
        }
        Destroy(gameObject);//i�ini yapan empty objeyi siliyoruz 
    }




}
