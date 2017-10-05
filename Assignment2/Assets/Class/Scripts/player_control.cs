using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {

    //public float speed = .3f;
    private Rigidbody2D rigid;
    private float x;  //horizontal value
    private float y;  //vertical value
    public float speed;
    public int count;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

        //Translate the player
        //transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
        
        //Add force to the player
        rigid.AddForce (new Vector2 (x * speed, y * speed));
        x = Input.GetAxis ("Horizontal");
        y = Input.GetAxis ("Vertical");

	}

    void OnTriggerEnter2D(Collider2D other) {
        //Check what the player hit
        if (other.CompareTag("PickUp")) {
            //print("hit pickup");
            other.gameObject.SetActive (false);
            count = count - 1;
            if (count == 0) {
                print("Game Over, all collectables gone");
                speed = 0;
                rigid.velocity = Vector3.zero;
            }
        }
    }

}
