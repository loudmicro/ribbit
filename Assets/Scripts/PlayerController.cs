using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Atributos del jugador
    //public para que lo vea el inspector
    public float fuerzaSalto = 10f;
    private float playerSpeed = 5f;
    private Rigidbody2D myRigidBody;
    public Manager gameManager;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteActual;
    private bool isGrounded;
    private int jumpCount = 0;
    private float tiempo = 10f;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<Manager>();
        spriteActual = GetComponent<SpriteRenderer>();
        spriteActual.sprite = spriteArray[0];
        
        

    }

    // Update is called once per frame
    void Update()
    {

        if(tiempo > 10)
        {
            playerSpeed = playerSpeed * 1.1f;
            tiempo = 0;
        }

        tiempo += UnityEngine.Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Space)  || Input.touchCount == 1 || Input.touchCount == 2) {

            //le aplicamos el valor de la fuerza en el componente visual
            //myRigidBody.gravityScale *= -1;

           
            if(jumpCount < 2)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, fuerzaSalto);
                jumpCount++;
            }
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x , fuerzaSalto );

            //prueba salto
            
        
        }

        //modificamos la coord x para movimiento horizontal

        myRigidBody.velocity = new Vector2(playerSpeed, myRigidBody.velocity.y);

    }

    //este metodo se llama cuando hay una colisión
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("fresa"))
        {

            //spriteActual.sprite = sprite[2];
            //destruir objetos
            Debug.Log("Ganas 10 puntos");
            gameManager.IncrementaPuntos(10);
  
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("copa"))
        {
            Debug.Log("Ganas 50 puntos");
            gameManager.IncrementaPuntos(50);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("confeti") )
        {
            Debug.Log("MUERTE"); 

            PlayerDead();
        }else if(collision.gameObject.CompareTag("ZonaMuerte"))
        {
            Debug.Log("MUERTE");

            PlayerDead();
        }

        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = true;
            Debug.Log("SUELO");
            jumpCount = 0;

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            isGrounded = false;
        }

    }

    private void PlayerDead()
    {
        //cambia de escena
        SceneManager.LoadScene("menuppal");

        

    }

}
