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
    GameObject newPlatform2;
    public GameObject item;
    List<GameObject> gOToDestroy = new List<GameObject>();
    List<GameObject> gOToDestroy2 = new List<GameObject>();
    GameObject secondLayerPlatform;

    float y;
    float secondY;
    // Start is called before the first frame update
    void Start()
    {
        newPlatform = Instantiate(longPlatform);
        y = -8;
        newPlatform.transform.position = new Vector3(player.transform.position.x + distanceBetweenPlatforms, y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (newPlatform.transform.position.x-15f < player.transform.position.x)
        {

            newPlatform = Instantiate(longPlatform);
            newPlatform.transform.position = new Vector3(player.transform.position.x+distanceBetweenPlatforms, y, 0);
            gOToDestroy.Add(newPlatform);

            if (gOToDestroy.Count > 4)
            {

                Destroy(gOToDestroy[0]);
                gOToDestroy.RemoveAt(0);

            }

        }
    }

}
