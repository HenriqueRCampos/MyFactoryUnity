using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameObject HitTargget;
    public Animator _doorAnimator;
    public List<GameObject> Lights;
    public List<GameObject> LightButtons;
    public List<GameObject> LightButtonsOff;
    public List<GameObject> InteractionEventsUI;
    public List<GameObject> DoorButton;
    public List<GameObject> GateUp;
    public List<GameObject> GateDown;


    bool _turnOn_off = true;

    void Start()
    {

    }
    
    void Update()
    {
        RayCastInterections();
    }
    private void RayCastInterections()
    {
        HitTargget = FirstPersonCamera.hit.collider.gameObject;
        for (int _listIndex = 0; _listIndex < LightButtons.Count; _listIndex++)
        {
            if (HitTargget.CompareTag("interactions"))
            {
                InteractionEventsUI[_listIndex].SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _turnOn_off = !_turnOn_off;
                    if (HitTargget.name == LightButtons[_listIndex].name || HitTargget.name == LightButtonsOff[_listIndex].name)
                    {
                        Lights[_listIndex].SetActive(_turnOn_off);
                        if (_turnOn_off)
                        {
                            LightButtons[_listIndex].SetActive(true);
                            LightButtonsOff[_listIndex].SetActive(false);

                        }
                        else
                        {
                            LightButtonsOff[_listIndex].SetActive(true);
                            LightButtons[_listIndex].SetActive(false);
                        }
                    }
                    if (HitTargget.name == DoorButton[_listIndex].name)
                    {
                        _doorAnimator.SetBool("OpenDoor",true);
                        _doorAnimator.SetBool("CloseDoor",true);

                    }


                }
            }
            else
            {
                InteractionEventsUI[_listIndex].SetActive(false);
            }
        }     
    }
}
