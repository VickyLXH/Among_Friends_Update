using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box;
    public float spawnHeight;

    public GameObject anotherBox;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            TriggerSpawnBox(collision);
        }
    }

    private void TriggerSpawnBox(Collider2D collision)
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
            if (anotherBox.transform.parent == null || !anotherBox.transform.parent.CompareTag("Player"))
            {
                GameObject.Destroy(anotherBox);
                anotherBox = null;
                Vector2 spawnPosition = transform.position + new Vector3(0, spawnHeight, 0);
                GameObject newObject = Instantiate(box, spawnPosition, Quaternion.identity);
                Box newBox = newObject.GetComponent<Box>();
                newBox.SetSpawner(this);
                anotherBox = newObject;
            }
        }
    }

    public void SetAnotherBox(GameObject gameObject)
    {
        anotherBox = gameObject;
    }
}