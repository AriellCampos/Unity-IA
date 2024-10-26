using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Randomize();
        RandomizeYRotation();
    }

    void Randomize() { transform.rotation = Random.rotation; }

    void RandomizeYRotation() {
        Quaternion randomYRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        transform.rotation = randomYRotation;
    }
   
}
