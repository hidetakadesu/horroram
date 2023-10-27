using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaAbrir : MonoBehaviour
{
    private GameObject player;
    public GameObject door;
    //public GameObject playcam;
    public bool openSide;
    public bool isDoorOpen;
    public GameObject UIOpenDoor;
    public GameObject UICloseDoor;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(door.transform.position, player.transform.position) < 1.5f && !isDoorOpen)
        {
            UIOpenDoor.SetActive(true);
            if(openSide && Input.GetKeyDown(KeyCode.E))
            {
                door.transform.SetPositionAndRotation(new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z), Quaternion.Euler(0, 90, 0));
                UIOpenDoor.SetActive(false);
                isDoorOpen = true;
            }

            else if(!openSide && Input.GetKeyDown(KeyCode.E))
            {
                door.transform.SetPositionAndRotation(new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z), Quaternion.Euler(0, -90, 0));
                UIOpenDoor.SetActive(false);
                isDoorOpen = true;
            }
        }
        else if(Vector3.Distance(transform.position, player.transform.position) < 1.5f && isDoorOpen){
            UICloseDoor.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                door.transform.SetPositionAndRotation(new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z), Quaternion.Euler(0, 0, 0));
                isDoorOpen = false;
                UICloseDoor.SetActive(false);
            }
        }
        else{
            UIOpenDoor.SetActive(false);
            UICloseDoor.SetActive(false);
        }
    }
}
