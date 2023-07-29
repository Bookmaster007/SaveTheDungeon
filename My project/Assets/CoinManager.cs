using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    [SerializeField] int coins = 10;
    public Text coinText;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addCoins(int coinsAdded)
    {
        coins += coinsAdded;
        coinText.text = coins.ToString();
    }
    public int getCoins()
    {
        return coins;
    }
    public void removeCoins(int coinsLost)
    {
        coins -= coinsLost;
        coinText.text = coins.ToString();
    }
}