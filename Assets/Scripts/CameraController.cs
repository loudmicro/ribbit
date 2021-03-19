using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //atributo para enfocar al personaje SIEMPRE LO SIGUE AL JUGADOR
    public Transform seguidorPlayer;


    // Start is called before the first frame update
    void Start()
    {
        //metodo alternativo para coger una referencia del juego

        if (seguidorPlayer == null) {
            seguidorPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //unity 3d , una camara siempre trabaja en 3D entonces usa -> Vector3
        transform.position = new Vector3(seguidorPlayer.position.x , transform.position.y, transform.position.z );
        
        
    }
}
