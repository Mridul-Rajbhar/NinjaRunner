using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel : MonoBehaviour
{
    bool rotate90 = true;

    Vector3 previousPosition;
    Vector3 newPlatformPosition;
    float currentTime;
    public float instantiateTime;
    public GameObject previousObject;

    public GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        previousPosition = previousObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > instantiateTime+currentTime)
        {
            GameObject platformToGenerate = platforms[Random.Range(0, 3)];
            GameObject newPlatform;
            currentTime = Time.time;
            if (rotate90)
            {  
                newPlatformPosition = new Vector3( previousPosition.x + 0.5f + platformToGenerate.transform.localScale.z/2, previousPosition.y, previousPosition.z + previousObject.transform.localScale.z/2 - 0.5f);
                newPlatform = Instantiate(platformToGenerate, newPlatformPosition, Quaternion.Euler(new Vector3(0, -90, 0)));
            }
            else
            {
                
                newPlatformPosition = new Vector3(previousPosition.x - 0.5f + previousObject.transform.localScale.z / 2, previousPosition.y, previousPosition.z + platformToGenerate.transform.localScale.z / 2 + 0.5f);
                newPlatform = Instantiate(platformToGenerate, newPlatformPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            }

            newPlatform.name = "newPlatform";
            rotate90 = !rotate90;
 
            previousObject = newPlatform;
            previousPosition = newPlatformPosition;
        }
    }
}
