using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c1direc : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject director;

    void Start()
    {
        director = GameObject.Find("director");
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.z > 3)
        {
            director.GetComponent<director>().arr[director.GetComponent<director>().ind] = 0;
            director.GetComponent<director>().ind += 1;
        }
    }
}
