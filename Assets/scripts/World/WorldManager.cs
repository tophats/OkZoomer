using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

public class WorldManager : MonoBehaviour
{
    // Count to be used for minimum and maximum distance between two obstacles
    [Serializable]
    public class Count
    {
        public float minimum;             //Minimum value for our Count class.
        public float maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Count(float min, float max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public static WorldManager Instance { get; private set; }

    public Transform PlayerLocation;

    public GameObject[] Tiles;
    public int MaximumObstacles = 10;   // Maximum number of game objects that can be instantiated at one time
    public float FirstGeneration = 5.0f;
    [SerializeField]
    public Count ObstacleDistance = new Count(5.0f, 8.0f);
    [SerializeField]
    public Count ObstacleGap = new Count(1.5f, 3.0f);
    [SerializeField]
    public Count ObstacleHeight = new Count(0.5f, 2.0f);
    private int GenerationCount = 0;
    private List<GameObject> Obstacles = new List<GameObject>();

    // ground generation 
    public GameObject Ground; // ground

    void OnEnable()
    {
        Instance = this;
    }

    void OnDisable()
    {
        if (Instance == this) Instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Instance == this)
        {
            Cleanup();
            if (Obstacles.Count < MaximumObstacles)
            {
                SpawnNewObstacle();
            }
        }
        */

    }

    public void SpawnNewObstacle()
    {
        GameObject ToInstantiate = Tiles[Random.Range(0, Tiles.Length)];
        GameObject CreatedObjectTop;
        GameObject CreatedObjectBot;
        float RandomY = Random.Range(ObstacleHeight.minimum, ObstacleHeight.maximum);
        float RandomYGap = Random.Range(ObstacleGap.minimum, ObstacleGap.maximum);
        float ObjHeight = ToInstantiate.GetComponent<Renderer>().bounds.size.y / 2;
        if (Obstacles.Count == 0)
        {
            CreatedObjectTop = Instantiate(ToInstantiate, new Vector3(PlayerLocation.position.x + FirstGeneration, PlayerLocation.position.y + RandomY, PlayerLocation.position.z), Quaternion.identity) as GameObject;
            CreatedObjectBot = Instantiate(ToInstantiate, new Vector3(PlayerLocation.position.x + FirstGeneration, PlayerLocation.position.y + RandomY - ObjHeight - RandomYGap, PlayerLocation.position.z), Quaternion.identity) as GameObject;
        }
        else
        {
            float RandomX = Random.Range(ObstacleDistance.minimum, ObstacleDistance.maximum);
            Transform LastGenerated = Obstacles[Obstacles.Count-1].transform;
            CreatedObjectTop = Instantiate(ToInstantiate, new Vector3(LastGenerated.position.x + RandomX, PlayerLocation.position.y + RandomY, PlayerLocation.position.z), Quaternion.identity) as GameObject;
            CreatedObjectBot = Instantiate(ToInstantiate, new Vector3(LastGenerated.position.x + RandomX, PlayerLocation.position.y + RandomY - ObjHeight - RandomYGap, PlayerLocation.position.z), Quaternion.identity) as GameObject;
        }
        Obstacles.Add(CreatedObjectTop);
        Obstacles.Add(CreatedObjectBot);

    }

    public void Cleanup() 
    {
        GameObject ToCleanup = Obstacles[0];
        if (ToCleanup.transform.position.x < PlayerLocation.position.x - 50.0f){ 
            Destroy(ToCleanup);
            Obstacles.RemoveAt(0);
        }
    }

    public void CleanupAll() {
        for (int i = 0; i < Obstacles.Count; i++) {
            Destroy(Obstacles[i]);
            Obstacles.RemoveAt(i);
        }
    }
}