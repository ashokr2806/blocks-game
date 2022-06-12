using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public GameObject gameWonPanel;

    public GameObject gameLostPanel;
    
    public float speed;

    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true) {
            rigidbody2d.velocity = new Vector2(0f, 0f);
            return;
        }

        if(Input.GetAxis("Horizontal") > 0) {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        } else if(Input.GetAxis("Horizontal") < 0) {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        } else if(Input.GetAxis("Vertical") > 0) {
            rigidbody2d.velocity = new Vector2(0f, speed);
        } else if(Input.GetAxis("Vertical") < 0) {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        } else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Door") {
            Debug.Log("Level complete!!!");
            isGameOver = true;
            gameWonPanel.SetActive(true);
        } else if (other.tag == "Enemy") {
            Debug.Log("Spike hit!!!");
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }
    } 

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart game...");
    }
}
