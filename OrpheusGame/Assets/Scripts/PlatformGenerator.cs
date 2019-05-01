using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject longPlatform;
    public GameObject mediumPlatform;
    public GameObject shortPlatform;
    public float maxDistance;
    public float distanceBetweenPlatforms;
    public GameObject player;
    public GameObject currPlatform;
    public GameObject currPlatform2;
    public GameObject startingPlatform;
    GameObject gOToInstantiate;
    GameObject newPlatform;
    GameObject newPlatformSecondaryLayer;
    GameObject newPlatformSecondaryLayerLonger;
    GameObject newPlatform2;
    public GameObject item;
    List<GameObject> gOToDestroy = new List<GameObject>();
    List<GameObject> gOToDestroy2 = new List<GameObject>();
    GameObject secondLayerPlatform;
    public int minPlatformDistance;
    public int maxPlatformDistance;
    public int chanceForNoPlatform;

    public float secondaryLayerDistance;

    float y;
    float secondY;
    float randomNumber;
    float randomNumberSecondary;
    // Start is called before the first frame update
    void Start()
    {
        newPlatform = Instantiate(longPlatform);
        y = -8;
        newPlatform.transform.position = new Vector3(player.transform.position.x + distanceBetweenPlatforms, y, 0);
        randomNumber = Random.Range(minPlatformDistance, maxPlatformDistance);
        randomNumberSecondary = Random.Range(minPlatformDistance, maxPlatformDistance);
        newPlatformSecondaryLayer = Instantiate(mediumPlatform);
    }
    // Update is called once per frame
    void Update()
    { 
        if (newPlatform.transform.position.x-randomNumber < player.transform.position.x)
        { 
            newPlatform = Instantiate(longPlatform);
            newPlatform.transform.position = new Vector3(player.transform.position.x+distanceBetweenPlatforms, y, 0);
            gOToDestroy.Add(newPlatform);

            if (gOToDestroy.Count > 4)
            {
                Destroy(gOToDestroy[0]);
                gOToDestroy.RemoveAt(0);

            }
            if (Random.Range(0, 10) < chanceForNoPlatform)
            {
                randomNumber = Random.Range(minPlatformDistance, maxPlatformDistance);
            }
            else randomNumber = -5;
        }
        if (newPlatformSecondaryLayer.transform.position.x - randomNumberSecondary < player.transform.position.x)
        {
            if (Random.Range(0, 1) == 0)
            {
                newPlatformSecondaryLayer = Instantiate(mediumPlatform);
            }
            else newPlatformSecondaryLayer = Instantiate(shortPlatform);
            newPlatformSecondaryLayer.transform.position = new Vector3(player.transform.position.x + distanceBetweenPlatforms
            , secondaryLayerDistance+Random.Range(-2.5f,2.5f), 0);

            gOToDestroy.Add(newPlatformSecondaryLayer);

            if (gOToDestroy.Count > 4)
            {
                Destroy(gOToDestroy[0]);
                gOToDestroy.RemoveAt(0);

            }
            if (Random.Range(0, 10) < chanceForNoPlatform)
            {
                randomNumberSecondary = Random.Range(minPlatformDistance, maxPlatformDistance);
            }
            else randomNumberSecondary  = -5;
        }
    }

}
