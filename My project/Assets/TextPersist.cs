using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPersist : MonoBehaviour
{
    private static TextPersist instance;
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
}
