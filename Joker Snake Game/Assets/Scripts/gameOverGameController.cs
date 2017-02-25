using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverGameController : MonoBehaviour {

    void Start()
    {
        StartCoroutine(wait());
        Application.Quit();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
    }// wait for some time

}// game Over Controller
