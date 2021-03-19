using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Bloques;
    public float TiempoMin = 1f, TiempoMax = 2f;
    public float yMax, yMin;
    private Transform posicion;
    public bool yRandom;

    // Start is called before the first frame update
    void Start()
    {
        //las corrutinas se lanzan una vez nada mas
        StartCoroutine(SpawnCorrutine(0));
        posicion = GetComponent<Transform>();

                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //creacion de una corrutina, se ejecuta periodicamente
    IEnumerator SpawnCorrutine(float time) 
    {
        yield return new WaitForSeconds(time); //esto nos lo creemos , todavia no se que hace

        //instantiate crea un game object al azar
        Instantiate(Bloques[Random.Range(0 , Bloques.Length)], transform.position, Quaternion.identity);

        //para que vuelva a ejecutarse hace falta:
        StartCoroutine(SpawnCorrutine(Random.Range(TiempoMin,TiempoMax)));

        if (yRandom)
        {
            // transform.position = new Vector3(seguidorPlayer.position.x , transform.position.y, transform.position.z );

            transform.position = new Vector2(transform.position.x, Random.Range(yMin, yMax));
        }


    
    }


}
