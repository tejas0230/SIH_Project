using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [HideInInspector]
    public bool CanPlayerMove = true;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneTo(int index)
    {
        SceneManager.LoadScene(index);
    }

    
}
