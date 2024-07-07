using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerrainSpawner : MonoBehaviour
{
    public Transform player;
    public List<GameObject> terrainPrefabs;
    public float spawnDistance = 15f;
    public float terrainLength = 1f;

    private List<GameObject> activeTerrains = new List<GameObject>();
    private float nextSpawnPoint = -0.5f;

    public static int score = 0;

    public TextMeshProUGUI resultText;

    void Start()
    {

        //  for (int i = 0; i < 3; i++)
        // {
        //      SpawnTerrain();
        //  }

        
        UpdateScoreText();
    }

    void Update()
    {
        // Check if we need to spawn new terrain
        if (player.position.z > nextSpawnPoint - spawnDistance - 10f)
        {
            SpawnTerrain();
        }
        
    }

    void SpawnTerrain()
    {
        // Select a random terrain prefab
        int randomIndex = Random.Range(0, terrainPrefabs.Count);
        GameObject terrain = Instantiate(terrainPrefabs[randomIndex], new Vector3(0, -1f, nextSpawnPoint), Quaternion.identity);

        // Add the new terrain to the list of active terrains
        activeTerrains.Add(terrain);

        // Update the next spawn point
        nextSpawnPoint += terrainLength;


        if (activeTerrains.Count > 3)
        {
            Destroy(activeTerrains[0]);
            activeTerrains.RemoveAt(0);
        }

        AddScore();
    }

    void AddScore()
    {
        score = score + 1;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        resultText.text = score.ToString("Score: " + score); 
    }

}