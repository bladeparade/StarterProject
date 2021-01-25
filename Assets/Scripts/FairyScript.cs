using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FairyScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float speed;
    private int drops = 0;
    public Text dropText;
    public Text winText;
    public Text howText;
    

float currentTime = 0f;
float startingTime = 15f;
public Text timer;    

public bool gameOver = false;
public bool win = false;
public bool sound = false;



AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        dropText.text = "Drops: " + drops.ToString();
        howText.text = "You're the Rain Fairy! Collect the raindrops before time runs out.";


        currentTime = startingTime;
        timer.text = "";
    }

    // Update is called once per frame

    void Update ()
    {
        currentTime -= 1 * Time.deltaTime;
                timer.text = currentTime.ToString();

                if(currentTime <= 0){
                currentTime = 0;
                 winText.text = "You lose! Press R to restart.";
                 speed = 0;
                 gameOver = true;
    }

     if (Input.GetKey(KeyCode.R))
            {
                if (gameOver == true || win == true)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }


            }

             if (Input.GetKey("escape"))
            {
                Application.Quit();
            }

    }
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Pickup")
        {
            sound = true;
            drops += 1;
            dropText.text = "Drops: " + drops.ToString();
            Destroy(collision.collider.gameObject);
        }

        if (drops == 5)
        {
            speed = 0;
            winText.text = "You won! Game by Estefani Blades. Press R to restart";
            win = true;
        }

    }
}
