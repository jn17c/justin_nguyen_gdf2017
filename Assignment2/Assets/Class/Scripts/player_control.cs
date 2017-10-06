using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_control : MonoBehaviour {

    //public float speed = .3f;
    private Rigidbody2D rigid;
    private float x;  //horizontal value
    private float y;  //vertical value
    public float speed;
    private int count;
    private int numWhite;
    private int numRed;
    public Text countText;
    public Text countWhite;
    public Text countRed;
    public Text winText;
    public int nbPickups;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D> ();
        countText.text = "Counter: 0";
        countWhite.text = "White Asteroids: 0";
        countRed.text = "Red Asteroids: 0";
        count = 0;
        numWhite = 0;
        numRed = 0;
        winText.text = "";

	}

    void Update()
    {

        if (count >= nbPickups) {
            speed = 0f;
            winText.text = "You won the game!";
            rigid.velocity = Vector3.Lerp(rigid.velocity, Vector3.zero, Time.deltaTime);
        }

    }

    // Update is called once per frame
    void FixedUpdate () {

        //Translate the player
        //transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
        
        x = Input.GetAxis ("Horizontal");
        y = Input.GetAxis ("Vertical");
        //Add force to the player
        rigid.AddForce(new Vector2(x * speed, y * speed));

    }

    void OnTriggerEnter2D(Collider2D other) {
        //Check what the player hit
        if (other.CompareTag("PickUp_1pt")) {
            //print("hit pickup");
            other.gameObject.SetActive (false);
            count = count + 1;
            numWhite = numWhite + 1;
            countText.text = "Counter: " + count;
            countWhite.text = "White Asteroids: " + numWhite;
        }

        if (other.CompareTag("PickUp_3pt"))
        {
            //print("hit pickup");
            other.gameObject.SetActive(false);
            count = count + 5;
            numRed = numRed + 1;
            countText.text = "Counter: " + count;
            countRed.text = "Red Asteroids: " + numRed;
        }
    }

}
