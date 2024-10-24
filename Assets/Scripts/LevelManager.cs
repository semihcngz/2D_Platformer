using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;
    public int collectedGem;

    public string levelToLoad;

    //public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        AudioManager.instance.PlaySFX(8);

        //Instantiate(deathEffect, PlayerController.instance.transform.position, transform.rotation);

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        PlayerController.instance.theSR.flipX = false;
        UIController.instance.UpdateHealthDisplay();

        PlayerController.instance.gameObject.SetActive(true);

    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    private IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        UIController.instance.levelComplatedText.SetActive(true);

        CameraController.instance.stopFollow = true;


        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(0.5f * UIController.instance.fadeSpeed);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        SceneManager.LoadScene(levelToLoad);
    }

}
