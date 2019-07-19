using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour
{

    RaycastHit Hit;
    public GameObject holdText;
    public GameObject flashLite,
    LitePickUp,
    spotlight,
    mainGateCol,
    mainGateBut,
    keyBed1Col,
    keyBed1Button,
    bedRoom1DoorCol,
    bedRoom2DoorCol,
    bedRoom3DoorCol,
    bedRoom1Button,
    bedRoom2Button,
    bedRoom3Button,
    fridgeButton,
    fridgeCol,
    drawerCol,
    drawerBut,
    fridgeKeyBut,
    fridgeKeyCol,
    safeCol,
    safeBut,
    room2KeyCol,
    room2KeyBut,
    paintingCol,
    paintingBut,
    paintingCol2,
    paintingBut2,
    page1But,
    page1Col,
    page2But,
    page2Col,
    slabCol,
    slabBut,
    paintingCol3,
    paintingBut3,
    page3But,
    page3Col;

    bool holdTextOn;

    public pageCollector pageScript;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);

        if (Physics.Raycast(ray, out Hit, 1.2f))
        {
            //FlashLight PickUp.
            if (Hit.collider.gameObject == flashLite)
            {
                LitePickUp.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    spotlight.GetComponent<flashLightOnOF>().lightPicked();
                }
            }
            else
            {
                LitePickUp.SetActive(false);
            }

            //Main Gate Opener.
            if (Hit.collider.gameObject == mainGateCol)
            {
                if (spotlight.GetComponent<flashLightOnOF>().lightpicked == true)
                {
                    mainGateBut.SetActive(true);
                    if (holdTextOn == true)
                    {
                        holdTextOn = false;
                        holdText.SetActive(true);
                    }
                }
            }

            //BedRoom1Key picker.
            if (Hit.collider.gameObject == keyBed1Col)
            {
                keyBed1Button.SetActive(true);
            }
            else
            {
                keyBed1Button.SetActive(false);
            }

            //BedRoom1Button Activator.
            if (Hit.collider.gameObject == bedRoom1DoorCol)
            {
                bedRoom1Button.SetActive(true);
            }
            else
            {
                bedRoom1Button.SetActive(false);
            }

            //BedRoom2Button Activator.
            if (Hit.collider.gameObject == bedRoom2DoorCol)
            {
                bedRoom2Button.SetActive(true);
            }
            else
            {
                bedRoom2Button.SetActive(false);
            }

            //BedRoom3Button Activator.
            if (Hit.collider.gameObject == bedRoom3DoorCol)
            {
                bedRoom3Button.SetActive(true);
            }
            else
            {
                bedRoom3Button.SetActive(false);
            }

            //Fridge Button Activator.
            if (Hit.collider.gameObject == fridgeCol)
            {
                fridgeButton.SetActive(true);
            }
            else
            {
                fridgeButton.SetActive(false);
            }

            //Drawer Button Activator.
            if (Hit.collider.gameObject == drawerCol)
            {
                drawerBut.SetActive(true);
            }
            else
            {
                drawerBut.SetActive(false);
            }

            //Fridge Key Button Activator.
            if (Hit.collider.gameObject == fridgeKeyCol)
            {
                fridgeKeyBut.SetActive(true);
            }
            else
            {
                fridgeKeyBut.SetActive(false);
            }

            //Safe Button Activator.
            if (Hit.collider.gameObject == safeCol)
            {
                safeBut.SetActive(true);
            }
            else
            {
                safeBut.SetActive(false);
            }

            //Room 2 Button Activator.
            if (Hit.collider.gameObject == room2KeyCol)
            {
                room2KeyBut.SetActive(true);
            }
            else
            {
                room2KeyBut.SetActive(false);
            }

            //Painting Button Activator.
            if (Hit.collider.gameObject == paintingCol)
            {
                paintingBut.SetActive(true);
            }
            else
            {
                paintingBut.SetActive(false);
            }

            //Painting Button 2 Activator.
            if (Hit.collider.gameObject == paintingCol2)
            {
                paintingBut2.SetActive(true);
            }
            else
            {
                paintingBut2.SetActive(false);
            }

            //Page1 button Activator.
            if (Hit.collider.gameObject == page1Col)
            {
                page1But.SetActive(true);
            }
            else
            {
                page1But.SetActive(false);
            }

            if (pageScript.page1Collected)
            {
                //Page2 button Activator.
                if (Hit.collider.gameObject == page2Col)
                {
                    page2But.SetActive(true);
                }
                else
                {
                    page2But.SetActive(false);
                }

                //slab button Activator.
                if (Hit.collider.gameObject == slabCol)
                {
                    slabBut.SetActive(true);
                }
                else
                {
                    slabBut.SetActive(false);
                }

                //Painting Button 3 Activator.
                if (Hit.collider.gameObject == paintingCol3)
                {
                    paintingBut3.SetActive(true);
                }
                else
                {
                    paintingBut3.SetActive(false);
                }

                //Page3 button Activator.
                if (Hit.collider.gameObject == page3Col)
                {
                    page3But.SetActive(true);
                }
                else
                {
                    page3But.SetActive(false);
                }
            }
        }
        else
        {
            LitePickUp.SetActive(false);
            mainGateBut.SetActive(false);
            holdText.SetActive(false);
            holdTextOn = true;
            mainGateBut.GetComponent<LockPicking>().lockAnim.SetActive(false);
            mainGateBut.GetComponent<LockPicking>().doPick = true;
            mainGateBut.GetComponent<LockPicking>().startPick = false;
            StopCoroutine(mainGateBut.GetComponent<LockPicking>().lockOpened());
            keyBed1Button.SetActive(false);
            bedRoom1Button.SetActive(false);
            bedRoom2Button.SetActive(false);
            bedRoom3Button.SetActive(false);
            fridgeButton.SetActive(false);
            drawerBut.SetActive(false);
            fridgeKeyBut.SetActive(false);
            safeBut.SetActive(false);
            room2KeyBut.SetActive(false);
            paintingBut.SetActive(false);
            paintingBut2.SetActive(false);
            page1But.SetActive(false);
            page2But.SetActive(false);
            slabBut.SetActive(false);
            paintingBut3.SetActive(false);
            page3But.SetActive(false);
        }
    }
}
