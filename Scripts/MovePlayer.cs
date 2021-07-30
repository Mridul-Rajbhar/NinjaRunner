using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class MovePlayer : MonoBehaviour
{

    public float jumpForce;

    public static bool isAlive = true;
    float lastFrame;
    private int score = 0;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private TMP_Text scoreText; 

    [SerializeField]
    float speed;
    [SerializeField]
    Animator animator;

    [SerializeField]
    public bool isGround = true;
    bool rotate90 = false;

    [SerializeField]
    Rigidbody rigidbody;
    Vector3 direction = new Vector3(0, 0, 1f);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lastFrame = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = ""+score;
        
        if (isAlive)
        {
            if (Time.time > 1f + lastFrame && isAlive)
            {
                increaseScore(1);
                lastFrame = Time.time;
               
            }

            transform.Translate(new Vector3(0f, 0f, speed) * Time.deltaTime);
        }
    }


    void increaseScore(int s)
    {
        score = score+s;
    }


    public void Jump()
    {
            animator.SetTrigger("Jump");
            isGround = false;
            rigidbody.velocity = new Vector3(0, jumpForce, 0);
    }

    public void Turn()
    {
            rotate90 = !rotate90;
            if (rotate90)
                transform.eulerAngles = new Vector3(0, 90, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        if(collision.gameObject.tag == "obstacle")
        {
            isAlive = false;
        }

        if(collision.gameObject.tag == "coin")
        {
            increaseScore(3);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(other.gameObject,2);
        }
    }

}
