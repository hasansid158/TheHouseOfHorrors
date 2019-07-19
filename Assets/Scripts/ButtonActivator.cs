using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{

    public GameObject DoorBut;
    RaycastHit rayHit;
    public GameObject gates;
    public GameObject cam;
    public GameObject brickCol;
    public GameObject brickBut;
    public GameObject Hammer, hammerBut;
    public GameObject funtionsLight;
    public GameObject lightCol, LightButtonActive;
    public GameObject KeyCol, KeyBut;
    public GameObject LockPickCol, LockPickBut;
    public GameObject HouseDoorCol, houseDoorBut;
    public GameObject CabinDoorCol, CabinDoorBut;
    public GameObject key2Col, key2But;
    public CabinDoorOpener cabindoor;
    public GameObject fader;

    IEnumerator fade() 
    {
        fader.GetComponent<Image>().CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        fader.SetActive(false);
    }

    void Start() 
    {
        StartCoroutine("fade");
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        
        if (Physics.Raycast(ray, out rayHit, 1.2f))
        {
            // Main Gate And Break breaker buttons.
            if (rayHit.collider.gameObject == gates)
            {
                DoorBut.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<BrickMove>().Locked_Main_Door();
                }
            }
            else
            {
                DoorBut.SetActive(false);
            }

            if (rayHit.collider.gameObject == brickCol)
            {
                brickBut.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<BrickMove>().Brick_Breaker();
                }
            }
            else
            {
                brickBut.SetActive(false);
            }

            if (rayHit.collider.gameObject == Hammer)
            {
                hammerBut.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<BrickMove>().HammerPickUp();
                }
            }
            else
            {
                hammerBut.SetActive(false);
            }

            // Light Button.

            if (rayHit.collider.gameObject == lightCol)
            {
                LightButtonActive.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    funtionsLight.GetComponent<flashLightOnOF>().lightPicked();
                    gameObject.GetComponent<ObjectHint>().Icall();
                }
            }
            else
            {
                LightButtonActive.SetActive(false);
            }

            // Key and LockPick Button.

            if (rayHit.collider.gameObject == KeyCol)
            {
                if (gameObject.GetComponent<DoorClosed>().KeyNow == true)
                {
                    KeyBut.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        gameObject.GetComponent<KeyandLockPick>().keyPicker();
                    }
                }
            }
            else
            {
                KeyBut.SetActive(false);
            }

            // House Gate Button.

            if (rayHit.collider.gameObject == HouseDoorCol)
            {
                houseDoorBut.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<ObjectHint>().HouseDoorClosed();
                }
            }
            else
            {
                houseDoorBut.SetActive(false);
            }

            // Cabin Door Button

            if (rayHit.collider.gameObject == CabinDoorCol)
            {
                CabinDoorBut.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    cabindoor.CabinOpen();
                }
            }
            else
            {
                CabinDoorBut.SetActive(false);
            }

            // 2nd Key pickup button

            if (rayHit.collider.gameObject == key2Col)
            {
                key2But.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<KeyandLockPick>().key2Picked();
                }
            }
            else
            {
                key2But.SetActive(false);
            }
        }

        //Turn all buttons off when not looking at

        else
        {
            DoorBut.SetActive(false);
            brickBut.SetActive(false);
            hammerBut.SetActive(false);
            LightButtonActive.SetActive(false);
            KeyBut.SetActive(false);
            houseDoorBut.SetActive(false);
            CabinDoorBut.SetActive(false);
            key2But.SetActive(false);
        }
    }
}