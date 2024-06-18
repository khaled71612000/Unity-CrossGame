using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int level;
    [SerializeField] List<Transform> Lanes;
     public float Health;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        Health = DiffecultyManager.instance.playerHealth;
        DiffecultyManager.instance.InitData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer();
        }

       

        Debug.Log(DiffecultyManager.instance.sceneNum);
    }

    private void MovePlayer()
    {
        Transform nextLane = Lanes[index];
        Vector3 targetDest = new Vector3(nextLane.position.x, nextLane.position.y,transform.position.z);

        this.transform.position = targetDest;

        index++;


        if (index >= Lanes.Count)
        {
            if (DiffecultyManager.instance.sceneNum >= 3)
            {
                DiffecultyManager.instance.sceneNum = 0;
            }
            else
            {
                DiffecultyManager.instance.sceneNum++;
            }
            SceneManager.LoadScene(DiffecultyManager.instance.sceneNum);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
            Health--;

                if (Health<=0)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
