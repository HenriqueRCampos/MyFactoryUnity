using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject sunLight;
    // Start is called before the first frame update
    void Start()
    {
        sunLight = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        sunLight.transform.Rotate(Vector3.right, 0.01f);
    }
}
