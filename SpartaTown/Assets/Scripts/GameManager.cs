using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject characterName;
    public GameObject startPanel;
    public GameObject input;
    public Button submitButton;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        submitButton.onClick.AddListener(ValidateInput);
    }

    void Update()
    {
        
    }

    void ValidateInput()
    {
        InputField inputField = input.GetComponent<InputField>();
        string inputText = inputField.text;

        if (inputText.Length >= 2 && inputText.Length <= 10)
        {
            startPanel.SetActive(false);
            characterName.GetComponent<InputField>().name = inputText;
        }
    }
}
