using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonedas : MonoBehaviour
{

    public GameObject[] Monedas;
    public float TiempoMin = 1f, TiempoMax = 2f;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnCorrutine(0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCorrutine(float time)
    {
        yield return new WaitForSeconds(time); //esto nos lo creemos , todavia no se que hace

        //instantiate crea un game object al azar
        Instantiate(Monedas[Random.Range(0, Monedas.Length)], transform.position, Quaternion.identity);
        
        //TODO agregar y

        //para que vuelva a ejecutarse hace falta:
        StartCoroutine(SpawnCorrutine(Random.Range(TiempoMin, TiempoMax)));



    }


}
