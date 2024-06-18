using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffecultyManager : MonoBehaviour
{
    [SerializeField] List<DifficultySettings> dsOS;
    Player player;

    [HideInInspector] public float CarSpeed;
    [HideInInspector] public float spawnWaitTime;
    [HideInInspector] public float playerHealth;
    [HideInInspector] public int sceneNum;


    //public DifficultySettings currentLevelDif;

    public static DiffecultyManager instance;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(instance);
        }

        
    }

    public void InitData()
    {
        Debug.Log("data w kda");
        CarSpeed = dsOS[sceneNum].CarSpeed;
        spawnWaitTime = dsOS[sceneNum].spawnWaitTime;
        playerHealth = dsOS[sceneNum].playerHealth;
    }
}
