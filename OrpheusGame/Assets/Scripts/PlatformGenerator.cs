using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject longPlatform;
    public GameObject mediumPlatform;
    public GameObject shortPlatform;

    public GameObject player;

    public GameObject startingPlatform;

    GameObject newPlatform;
    public GameObject item;
    List<GameObject> itemToDestroy = new List<GameObject>();
    List<GameObject> gOToDestroy = new List<GameObject>();
    List<GameObject> gOToDestroy2 = new List<GameObject>();

    public float secondaryLayerDistance;
    List<int> randomNumbers = new List<int>();
    float y;
    float secondY;
    float randomNumber;
    float randomNumberSecondary;
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        newPlatform = Instantiate(longPlatform);
        y = -8;
        newPlatform.transform.position = new Vector3(player.transform.position.x + 10, y, 0);
        gOToDestroy.Add(newPlatform);

        randomNumbers.Add(45);
        randomNumbers.Add(50);
        randomNumbers.Add(60);
        randomNumbers.Add(55);

    }
    // Update is called once per frame
    void Update()
    {

        if (gOToDestroy.Count<4)
        {
            randomNumber = randomNumbers[Random.Range(0, randomNumbers.Count)];

            GameObject j = Instantiate(longPlatform);
            j.transform.position = new Vector3(gOToDestroy[gOToDestroy.Count-1].transform.position.x +randomNumber,y,0);
            gOToDestroy.Add(j);

            if(Random.Range(0, randomNumbers.Count) <= 2)
            {
                GameObject l = Instantiate(mediumPlatform);
                l.transform.position = j.transform.position + new Vector3(0, 6, 0);
                gOToDestroy2.Add(l);
                if(Random.Range(0, 10) > 1)
                {
                    GameObject i = Instantiate(item);
                    i.transform.position = l.transform.position + new Vector3(0, 2, 0);
                    itemToDestroy.Add(i);

                }
            }

        }
        if (gOToDestroy.Count >= 4 && player.transform.position.x-randomNumber>gOToDestroy[0].transform.position.x)
        {
            Destroy(gOToDestroy[0]);
            gOToDestroy.RemoveAt(0);
        }
        /*=================SECONDLAYER================*/
        if (gOToDestroy2.Count >= 6)
        {
            Destroy(gOToDestroy2[0]);
            gOToDestroy2.RemoveAt(0);
        }
    }


}

