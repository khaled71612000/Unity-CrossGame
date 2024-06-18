using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] Car carPrefab;
    [SerializeField] List<Transform> spawnPos;
     float spawnSpeed;
    [SerializeField] Vector3 endPos;
     float speed;
    Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(SpawnCar());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {

        spawnSpeed = DiffecultyManager.instance.spawnWaitTime;
        speed = DiffecultyManager.instance.CarSpeed;
        Vector3 randomSpawn = spawnPos[Random.Range(0, spawnPos.Count)].position;
        Vector3 randomEndPos = new Vector3 (randomSpawn.x, randomSpawn.y, endPos.z);

        Car spawnedCar = Instantiate(carPrefab, randomSpawn,Quaternion.identity,this.transform);
        spawnedCar.StartPosition = randomSpawn;
        spawnedCar.EndPosition = randomEndPos;
        spawnedCar.Speed = speed;
    }

    IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(spawnSpeed);
        Spawn();
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(SpawnCar());
    }
}
