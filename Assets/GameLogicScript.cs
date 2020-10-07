using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;

    void Start()
    {
        System.Random random = new System.Random();

        Instantiate(obj, new Vector3(40 * ((float)random.NextDouble() - 0.5f), 3 * (float)random.NextDouble(), 15 * (float)random.NextDouble() - 20), Quaternion.identity, this.transform);
        Instantiate(obj, new Vector3(40 * ((float)random.NextDouble() - 0.5f), 3 * (float)random.NextDouble(), 15 * (float)random.NextDouble() - 20), Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
