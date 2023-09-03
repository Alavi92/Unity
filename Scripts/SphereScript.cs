using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereScript : MonoBehaviour
{
    public float Velocity=15;
     public static bool Grounded=true;
    //int Score;
    //public GameObject Text;
    public GameObject Text;
    public Text Instruction;
    public static bool ExternalForce=false;
   

   


    void Start()
    {
        
        if (SyncScript.MiddleGame)
        { transform.position = new Vector3(-142, 1, 26);
            GameObject.Find("Main Camera").transform.position = new Vector3(-142, 5, 14);
        }
    }
   
    void Update()
    {
        if (!ExternalForce)
        {

            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;

            if (Input.GetKeyDown(KeyCode.W) && Grounded == true)
            {
                Grounded = false;

                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Velocity * 50, 0f));

            }
            v = gameObject.GetComponent<Rigidbody>().velocity;

            if (Input.GetKey(KeyCode.S))
            {

                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Velocity * (-5), 0f));
            }

            v = gameObject.GetComponent<Rigidbody>().velocity;
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                if (!ExternalForce)
                {
                    if (Grounded)
                    { gameObject.GetComponent<Rigidbody>().velocity = new Vector3((-1) * Velocity, v.y, v.z); }
                    else
                    { gameObject.GetComponent<Rigidbody>().velocity = new Vector3((-1) * Velocity - 10, v.y, v.z); }

                }
                else
                { gameObject.GetComponent<Rigidbody>().velocity = new Vector3((-1) * (Velocity + 10), v.y, v.z); }


            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                if (Grounded)
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Velocity, v.y, v.z);

                }
                else
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Velocity - 10, v.y, v.z);

                }
            }

            else if (Grounded == true && ExternalForce == false)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, v.y, v.z);
            }

            v = gameObject.GetComponent<Rigidbody>().velocity;
            if (Input.GetKey(KeyCode.UpArrow))
            {

                if (Grounded)
                { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(v.x, v.y, Velocity); }
                else
                { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(v.x, v.y, Velocity - 10); }
                Instruction.text = "Score: " + Score.score.ToString() + " out of 7";

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Grounded)
                { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(v.x, v.y, (-1) * Velocity); }
                else
                { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(v.x, v.y, (-1) * Velocity - 10); }
                //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, UpwardForce*(-1)));
            }
            else if (Grounded == true)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, 0);
            }

        }
        //Debug.Log("External Force "+ExternalForce);
        Debug.Log("Grounded : "+Grounded);
       // if (transform.position.y - 1< 0.1)
       //
       // { Grounded = true; }
       // else if (transform.position.y - 1 > 0.2)
        //{ Grounded = false; }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") )
        {

            Grounded = true;
        }
        if (collision.gameObject.CompareTag("Environment"))
        {

            Grounded = true;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Score.score += 1;
            Destroy(other.gameObject);
            Instruction.text = "Score: "+ Score.score.ToString()+ " out of 9";
            if (Score.score == 9)
            { Instruction.text = "Score: " + Score.score.ToString() + " out of 9 \n You won!"; }
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (SceneManager.GetActiveScene().name=="Scene2")
            {
                SceneManager.LoadScene("Scene3");
                
            }
            else

            {
                SyncScript.MiddleGame = true;
                SceneManager.LoadScene("Scene2");
                

            }
        }
    }


    }
