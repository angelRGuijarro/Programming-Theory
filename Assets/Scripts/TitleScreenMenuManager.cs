using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

/// <summary>
/// Manages transactions between scenes
/// </summary>
public class TitleScreenMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField m_InputFieldPlayersName;
    [SerializeField] TMP_Text m_PlayersNameTooltipText;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        
        m_InputFieldPlayersName.onEndEdit.AddListener(ApplicationManager.Instance.setPlayersName);
        if (ApplicationManager.playersName != null)
        {
            m_InputFieldPlayersName.text = ApplicationManager.playersName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void StartButtonPressed()
    {
        //Check user has input a player's name        
        if (m_InputFieldPlayersName.text != "")
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            m_PlayersNameTooltipText.gameObject.SetActive(true);
        }
    }    

    public void QuitButtonPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
