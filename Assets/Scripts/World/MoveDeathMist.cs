using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDeathMist : MonoBehaviour
{
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3((1 * (transform.position.x / 5)) * Time.deltaTime, 0, 0);
    }
}
