using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallController : MonoBehaviour {

    public Text score;
    public AudioClip clip;
    
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("snakeHead"))
        {
            //Application.LoadLevel(Application.loadedLevel);
            score.text = "Game Over";
           
            StartCoroutine(PlaySound());
            
            SceneManager.LoadScene("GameOver");

        }// if the snake hits tha wall

    }// on collision with the snake head
    IEnumerator PlaySound()
    {
        AudioSource.PlayClipAtPoint(clip,transform.position);
        yield return new WaitForSeconds(clip.length);
    }// play sound

}// class
