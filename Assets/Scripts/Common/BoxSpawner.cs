using System;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box;
    public float spawnHeight;

    public GameObject anotherBox;
    //bool QPressed = false;

    //private void Awake()
    //{
    //    PlayerInteraction.trySpawn += PlayerInteraction_trySpawn;
    //}

    //private void PlayerInteraction_trySpawn()
    //{
    //    QPressed = true;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerSpawnBox(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TriggerSpawnBox(collision);

    }

    private void TriggerSpawnBox(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            if (anotherBox == null)
            {
                Vector2 spawnPosition = transform.position + new Vector3(0, spawnHeight, 0);
                GameObject newObject = Instantiate(box, spawnPosition, Quaternion.identity);
                Box newBox = newObject.GetComponent<Box>();
                newBox.SetSpawner(this);
            }
            else
            {
                if (anotherBox.transform.parent && anotherBox.transform.parent.CompareTag("Player"))
                {

                }
                else
                {
                    GameObject.Destroy(anotherBox);
                    anotherBox = null;
                    Vector2 spawnPosition = transform.position + new Vector3(0, spawnHeight, 0);
                    GameObject newObject = Instantiate(box, spawnPosition, Quaternion.identity);
                    Box newBox = newObject.GetComponent<Box>();
                    newBox.SetSpawner(this);
                }
            }

        }
    }

   

    public void SetAnotherBox(GameObject gameObject)
    {
        anotherBox=gameObject;

    }
}
