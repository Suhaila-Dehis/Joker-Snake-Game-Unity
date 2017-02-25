using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour {

    public GameObject fruit;
    public AudioClip clip;
    // Use this for initialization
    void Start()
    {
        // move the fruit to a random place
        MoveFruit();

    }// start function

    // Update is called onc per frame
    void Update()
    {
        // rotate the fruit 
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }// update
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("snakeHead"))
        {
           // other.GetComponent<SnakeController>().AddBodyPart();
            
            fruit.SetActive(false);
            // Destroy(gameObject);
            MoveFruit();
            AudioSource.PlayClipAtPoint(clip, transform.position);

        }// if snake hits fruit
    }// on trigger

    private void MoveFruit()
    {
        // moving the fruit to a random place

        System.Random rnd = new System.Random();
        float fruit_x = (float)rnd.Next(-8, 8);
        float fruit_z = (float)rnd.Next(-8, 8);

        fruit.transform.position = new Vector3(fruit_x, 0.5f, fruit_z);
        fruit.SetActive(true);

    }// move fruit function
}// class
