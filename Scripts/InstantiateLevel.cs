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
    public GameObject coins;
    public GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        previousPosition = previousObject.transform.position;
    }

    int getRandomValue()
    {
        float ran = Random.value;
        if (ran < 0.5f)
            return 0;
        else if (ran < 0.9f)
            return 1;
        else
            return 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > instantiateTime+currentTime)
        {
            GameObject platformToGenerate = platforms[getRandomValue()];
            GameObject newPlatform, newCoin;
            
            currentTime = Time.time;
            if (rotate90)
            {  
                newPlatformPosition = new Vector3( previousPosition.x + 0.5f + platformToGenerate.transform.localScale.z/2, previousPosition.y, previousPosition.z + previousObject.transform.localScale.z/2 - 0.5f);
                newPlatform = Instantiate(platformToGenerate, newPlatformPosition, Quaternion.Euler(new Vector3(0, -90, 0)));
                Vector3 offsetPos = new Vector3(Random.RandomRange(-platformToGenerate.transform.localScale.z / 2, platformToGenerate.transform.localScale.z / 2), 1f, 0f);
                if(Random.RandomRange(0,4)==1)
                    newCoin = Instantiate(coins, newPlatformPosition + offsetPos , Quaternion.Euler(new Vector3(0, -90, 0)));
            }
            else
            {
                
                newPlatformPosition = new Vector3(previousPosition.x - 0.5f + previousObject.transform.localScale.z / 2, previousPosition.y, previousPosition.z + platformToGenerate.transform.localScale.z / 2 + 0.5f);
                newPlatform = Instantiate(platformToGenerate, newPlatformPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                Vector3 offsetPos = new Vector3(0f, 1f, Random.RandomRange(-platformToGenerate.transform.localScale.z / 2, platformToGenerate.transform.localScale.z / 2));
                if(Random.RandomRange(0,4) == 1)
                newCoin = Instantiate(coins, newPlatformPosition + offsetPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            newPlatform.name = "newPlatform";
            rotate90 = !rotate90;
 
            previousObject = newPlatform;
            previousPosition = newPlatformPosition;
        }
    }
}
