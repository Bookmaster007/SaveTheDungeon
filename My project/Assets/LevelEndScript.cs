using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour
{
    [SerializeField] GameObject adventurerObject;
    AdventureScript adventurer;
    CoinManager coins;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        adventurer = GameObject.FindGameObjectWithTag("Adventurer").GetComponent<AdventureScript>();
        coins = GameObject.Find("LogicManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Adventurer")) {
            coins.addCoins(Mathf.FloorToInt((adventurer.maxHealth - adventurer.health) * .3f + timer / 4));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
