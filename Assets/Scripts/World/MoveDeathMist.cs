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
        if (transform.position.x < 1)
        {
            transform.position = transform.position + new Vector3(1 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position = transform.position + new Vector3((1.5f * (transform.position.x)) * Time.deltaTime, 0, 0);
        }
    }
}
