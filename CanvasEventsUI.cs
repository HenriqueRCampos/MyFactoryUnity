using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEventsUI : MonoBehaviour
{
    private GameObject _playerhead;
    // Start is called before the first frame update
    void Start()
    {
        _playerhead = GameObject.Find("head");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_playerhead.transform.position);
    }
}
