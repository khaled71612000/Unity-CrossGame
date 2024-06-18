using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using ScriptableObjectEvent;

public class PlayerHPManage : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] SOGameEvent onClick;
    [SerializeField] Image bgImage;
    [SerializeField] Image healthBar;
    [SerializeField] Color hitColor;

    void Update()
    {
        if(playerHealth != null && playerHealth.playerHealth <= 0.0f)
        {
            StartCoroutine(RestartScene());
        }
    }

    public void Bleed()
    {

        playerHealth.playerHealth--;

        if (playerHealth.playerHealth < 0.5f)
        {
            bgImage.color = hitColor;
        }
        

        if(playerHealth.playerHealth > 0)
        {
            healthBar.fillAmount = playerHealth.playerHealth / 3f;

            onClick.Raise();
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerHealth.playerHealth = 3;
    }
}