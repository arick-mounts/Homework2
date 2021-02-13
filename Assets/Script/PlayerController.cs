﻿using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 800.0f;
    public Text scoreText;
    public Button winButton;
    private int count = 0;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            scoreText.text = "Score: " + count;
            if (count >= 20) {
                winButton.gameObject.SetActive(true);
            }
        }
    }
}