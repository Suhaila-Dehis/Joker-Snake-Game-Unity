using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour {

    // public variables
    public Text countText;
    public Text losingText;
    public AudioClip clip;
   

    public List<Transform> BodyParts = new List<Transform>();
    public float miniDistance = 0.25f;
    public int beginSize;

    public float speed = 1;
    public float rotaionspeed = 200;
    public GameObject bodyprefab;


    // private variables
    private float distance;
    private Transform currentBodyPart;
    private Transform prevBodyPart;
    private int score;
    private Rigidbody rb;

    // Use this for initialization

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setCountText();
        losingText.text = "";

        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();

        }// loop to craete the snake body depending on the begin size

    }// start function

    // Update is called once per frame
    void Update()
    {
        // moe the snake every frame
        Move();
     
    }// update

    public void Move()
    {
        float currentSpeed = speed;

        BodyParts[0].Translate(BodyParts[0].right * currentSpeed * Time.smoothDeltaTime, Space.World);

        // if pressed left or right arrow, change the direction of the snake's head
        if (Input.GetAxis("Horizontal") != 0)
        {
            BodyParts[0].Rotate(Vector3.up * rotaionspeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }// if 

        // loop to move all the body parts of the snake, 
        for (int i = 1; i < BodyParts.Count; i++)
        {
            currentBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            distance = Vector3.Distance(prevBodyPart.position, currentBodyPart.position);

            Vector3 newposition = prevBodyPart.position;
            newposition.y = BodyParts[0].position.y;

            float time = Time.deltaTime * distance / miniDistance * currentSpeed;

            if (time > 0.5f)
            {
                time = 0.5f;
            }
            currentBodyPart.position = Vector3.Slerp(currentBodyPart.position, newposition, time);
            currentBodyPart.rotation = Quaternion.Slerp(currentBodyPart.rotation, prevBodyPart.rotation, time);


        }// loop to move all the body parts of the snake, 

    }// move function


    public void AddBodyPart()
    {
        Transform newPart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        newPart.SetParent(transform);
        BodyParts.Add(newPart);

    }// add body part function


    // snake on trigger function (snake hit something)

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("fruit"))
        {
            AddBodyPart();
            score++;
            setCountText();

        }// if the collided object is the fruit

        else if (other.gameObject.CompareTag("deamon"))
        {
            losingText.text = "Game Over ";
            StartCoroutine(PlaySound());
            SceneManager.LoadScene("GameOver");

        }// if the collided object is the deamon

    }// on trigger enter

    void setCountText()
    {
        // set the score function
        countText.text = "Score: " + score.ToString();
    }// set count text

    IEnumerator PlaySound()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        yield return new WaitForSeconds(clip.length);
    }// play the sound


}// snake controller class
