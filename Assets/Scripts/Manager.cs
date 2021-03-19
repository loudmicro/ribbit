using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public int puntuacion = 0;
    public Text score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementaPuntos(int puntos)
    {
        puntuacion += puntos;
        string text = "Puntuacion: " + puntuacion;
        score.text = text;
        Debug.Log("Puntuacion: " + puntuacion);

    }

    
}
