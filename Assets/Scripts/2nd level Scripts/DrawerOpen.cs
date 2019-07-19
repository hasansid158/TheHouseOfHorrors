using UnityEngine;
using System.Collections;

public class DrawerOpen : MonoBehaviour
{

    public GameObject col, fridgeKeyCol;
    public AudioClip drawerOpenSound;

    IEnumerator enableKeyCol()
    {
        yield return new WaitForSeconds(1);
        fridgeKeyCol.SetActive(true);
    }

    public void openDrawer()
    {
        gameObject.GetComponent<Animation>().Play("DrossAnimOpen");
        col.gameObject.SetActive(false);
        gameObject.GetComponent<AudioSource>().PlayOneShot(drawerOpenSound, 1);
        StartCoroutine("enableKeyCol");
    }
}
