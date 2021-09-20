using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemySpawn : SingletonMonoBehavior<EnemySpawn>
{
    public GameObject prefab;
    public Terrain terrain;
    public float yOffset = 6f;

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;

    public bool gameActive = true;

    public int m_mobCap;

    public int m_killsToEnd;

    public Slider m_progressBar;

    public int EnemyCount { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //Get terrain size
        var terrainData = terrain.terrainData;
        terrainWidth = terrainData.size.x;
        terrainLength = terrainData.size.z;

        //Get terrain position
        var position = terrain.transform.position;
        xTerrainPos = position.x;
        zTerrainPos = position.z;

        for(int i=0; i<50; i++)
            GenerateObjectOnTerrain();

        StartCoroutine(SpawnCycle());
    }

    public void KillEnemy()
    {
        --EnemyCount;
        if (m_progressBar.value>=0)
        {
            m_progressBar.value -= (float) 1 / m_killsToEnd;
        }
    }
    
    void GenerateObjectOnTerrain()
    {
        if (EnemyCount>=m_mobCap)
        {
            return;
        }
        //Generate random x,z,y position on the terrain
        float randX = Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

        //Apply Offset if needed
        yVal = yVal + Random.Range(2, yOffset);

        //Generate the Prefab on the generated position
        GameObject go = Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.identity);
        go.transform.parent = transform;
        EnemyCount++;
    }

    IEnumerator SpawnCycle()
    {
        while(gameActive)
        {
            GenerateObjectOnTerrain();
            EnemyMarker.updateRequest+=1;
            yield return new WaitForSeconds(1);
        }
    }
}
