using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject obj;//ne spawn edilcek
    public int number;//kaç tane spawn edilcek
    public float spawnTime;//ne kadar aralıklar ile spawn edilcek
   
    bool control = true;//control değişkeni spawn etmeye başlaması için true olması şarttır

    /*
     * Debug için kullanılan bir scripttir
     * belli bir sayıda asker spawn ettikten sonra spawnerı yok eder
     */
    
    /*
     * Çalışma prensibini anlatmak gerekirse
     * spawn fonksiyonu spawnTime vaktinde çalışması için kurar(Invoke) ve bekler(control)
     * spawn fonksiyonu çalışırken bir sonraki çalışma için tetiklemeyi açar(control true)
     * spawn fonksiyonu aynı zamanda number sayısını bir azaltır
     * number sayısı 0 olunca objeyi yok eder.
     */
    void Update()
    {
        
        if (control)
        {
            Invoke("Spawn", spawnTime);//spawn tetiklendi
            control = false;//spawn tetikleme izni kaldırıldı
        }
        if (number <= 0)//şayet istenilen spawn sayısına ulaşıldı ise
        {
            Destroy(gameObject);//obje yok edilir(Spawn yapan obje)
            //genedel bu obje bir emptyGameobjettir
        }
    }
    void Spawn()
    {
        control = true;//bir sonraki spawn tetiklemesi için izin verildi
        Instantiate(obj, transform.position, Quaternion.identity);//spawn edildi
        GameObject.Find("Commander").GetComponent<CommanderController>().newState = true;//komutana haber edildi yeni durum var diye
        number--;//spawn edilecek asker sayısı bir eksiltildi
    }
}
