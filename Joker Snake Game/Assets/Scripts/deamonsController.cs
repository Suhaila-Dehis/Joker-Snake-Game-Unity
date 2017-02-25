using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deamonsController : MonoBehaviour {

    public GameObject deamon;
    public Text gameOver;
    public AudioClip clip;
  
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snakeHead"))
        {
            // Game Over
            gameOver.text = "Game Over";
            AudioSource.PlayClipAtPoint(clip, transform.position);
            StartCoroutine(PlaySound());

            SceneManager.LoadScene("GameOver");

        }// if snake hits deamon

    }// on trigger
    IEnumerator PlaySound()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(clip.length);
    }// play the sound 

}// deamons class
