using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SairPortaFase : MonoBehaviour
{
    private GameObject player;
    public string proximaFase;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            Door.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = Door.transform.position;
                SceneManager.LoadScene(proximaFase);
            }
        }
        else{
            Door.SetActive(false);
        }
    }
}
