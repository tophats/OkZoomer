using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    // ground generation 
    public GameObject Ground;
    public GameObject Ceiling;
    public Transform PlayerLocation;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collide");
        Instantiate(Ground, new Vector3(PlayerLocation.position.x + 10, -2.1f, -9.824199f), Quaternion.identity);
        Instantiate(Ceiling, new Vector3(PlayerLocation.position.x + 10, 3f, -9.824199f), Quaternion.identity);
        WorldManager.Instance.SpawnNewObstacle();
        WorldManager.Instance.SpawnNewObstacle();
        WorldManager.Instance.SpawnNewObstacle();
        WorldManager.Instance.SpawnNewObstacle();
        WorldManager.Instance.SpawnNewObstacle();
        WorldManager.Instance.SpawnNewObstacle();
        WorldManager.Instance.SpawnNewObstacle();

        /*
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);
        */
    }
}
