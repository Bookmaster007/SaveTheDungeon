using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] Vector2 mousePosition;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject dungeonDweller;
    [SerializeField] GameObject archer;
    CoinManager coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = GameObject.Find("LogicManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void OnSelect2()
    {
        spawn = dungeonDweller;
    }
    void OnSelect1()
    {
        spawn = archer;
    }
    void OnSpawn()
    {
        if (coins.getCoins() >= 3)
        {
            Instantiate(spawn, new Vector3(mousePosition.x, mousePosition.y, 0), transform.rotation);
            coins.removeCoins(3);
        }
    }

}
