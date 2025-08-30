using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jump = 7f;
    private int score = 0;
    //private AudioSource audioPlayer;
   // public AudioClip saltar;


    void Update()
    {
        Debug.Log(score);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(0, jump);
            //audioPlayer = GetComponent<AudioSource>();
            //audioPlayer.clip = saltar;
            //audioPlayer.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("point"))
        {
            score++;
            if (score == 10)
            {
                SceneManager.LoadScene("E8");
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
