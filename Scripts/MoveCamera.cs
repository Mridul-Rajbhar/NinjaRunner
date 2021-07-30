using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    float currTime;

    Color[] colours = { Color.black, Color.red, Color.blue, Color.green, Color.yellow };
    // Start is called before the first frame update
    void Start()
    {
        currTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>currTime + 4f)
        {
            Camera.main.backgroundColor = colours[Random.Range(0, 5)];
            currTime = Time.time;
        }


        if (player.transform.position.y > -1)
            transform.position = new Vector3(offset.x + player.transform.position.x, offset.y + player.transform.position.y, offset.z + player.transform.position.z);
        else
        {
            MovePlayer.isAlive = false;
        }
    }
}
