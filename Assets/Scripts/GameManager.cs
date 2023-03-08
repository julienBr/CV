using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AppDatas _datas;
    
    [Header("Windows")]
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _questWindow;
    [SerializeField] private GameObject _commandWindow;

    private bool _gamePaused;
    private bool _commandActive;
    private bool _questActive;

    private void Awake() { _datas.actualLanguage = _datas.languageList[0]; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_gamePaused) GameResume();
            else GamePaused();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_commandActive) OpenCommandWindow();
            else CloseCommandWindow();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!_questActive) OpenQuestWindow();
            else CloseQuestWindow();
        }
    }
    
    private void GamePaused()
    {
        Time.timeScale = 0;
        _gamePaused = true;
        _pauseWindow.SetActive(true);
    }
    
    public void GameResume()
    {
        Time.timeScale = 1;
        _gamePaused = false;
        _pauseWindow.SetActive(false);
    }
    
    public void OpenSettingsWindow() { _settingsWindow.SetActive(true); }
    
    public void CloseSettingsWindow() { _settingsWindow.SetActive(false); }
    
    public void QuitGame() { Application.Quit(); }

    private void OpenCommandWindow()
    {
        _commandActive = true;
        _commandWindow.SetActive(true);
        _commandWindow.GetComponent<Animator>().SetBool("CommandWindow", true);
    }
    
    private void CloseCommandWindow() { StartCoroutine(MoveOut("CommandWindow")); }
    
    private void OpenQuestWindow()
    {
        _questActive = true;
        _questWindow.SetActive(true);
        _questWindow.GetComponent<Animator>().SetBool("QuestWindow", true);
    }
    
    private void CloseQuestWindow() { StartCoroutine(MoveOut("QuestWindow")); }
    
    IEnumerator MoveOut(string window)
    {
        switch (window)
        {
            case "CommandWindow":
                _commandActive = false;
                _commandWindow.GetComponent<Animator>().SetBool(window, false);
                yield return new WaitForSeconds(1.5f);
                _commandWindow.SetActive(false);
                break;
            case "QuestWindow":
                _questActive = false;
                _questWindow.GetComponent<Animator>().SetBool(window, false);
                yield return new WaitForSeconds(1.5f);
                _questWindow.SetActive(false);
                break;
        }
    }

    public void ChooseLanguage(int index)
    {
        _datas.actualLanguage = index switch
        {
            0 => _datas.languageList[0],
            1 => _datas.languageList[1],
            _ => _datas.actualLanguage
        };
    }
}