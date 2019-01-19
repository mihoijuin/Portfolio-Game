using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject charactorScreenButton;

    void Start () {
		
	}
	
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        charactorScreenButton.SetActive(collision.gameObject.CompareTag("Player"));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        charactorScreenButton.SetActive(!collision.gameObject.CompareTag("Player"));
    }



}
