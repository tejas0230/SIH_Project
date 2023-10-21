using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject namePanel;

    public TMP_Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        namePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClicked()
    {
        mainMenuPanel.SetActive(false);
        namePanel.SetActive(true);
    }

    public void OnQuitClicked()
    {

    }

    public void OnStartClicked()
    {
        Debug.Log(nameText.text.Length);
        if(nameText.text.Length!=1)
        {
            PlayerPrefs.SetString("Name", nameText.text);
            Debug.Log(PlayerPrefs.GetString("Name"));
            GameManager.instance.ChangeSceneTo(1);
        }
    }
}
