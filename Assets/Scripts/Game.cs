using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Action OnShowMenu;
    public static Action OnPauseGame;
    public static Action OnResumeGame;
    public static Action OnExitGame;
    public static Action OnBeginSelectLevel;
    public static Action<int> OnLevelStart;

    private int _currentLevel = 1;

    void OnEnable()
    {
        WindowMain.OnPlayStart += StartPlay;
        WindowLevels.OnLevelSelect += StartLevel;
        WindowLevels.OnCancelLevelSelect += OpenMenu;
        WindowPause.OnCancelClick += CancelPause;
        WindowPause.OnRestartClick += RestartLevel;
        WindowPause.OnExitToMenuClick += OpenMenu;
        GameUI.OnPauseClick += PauseGame;
        Ball.OnDie += RestartLevel;
        Finish.OnFinishComplete += LevelComplete;
    }

    void OnDisable()
    {
        WindowMain.OnPlayStart -= StartPlay;
        WindowLevels.OnLevelSelect -= StartLevel;
        WindowLevels.OnCancelLevelSelect -= OpenMenu;
        WindowPause.OnCancelClick -= CancelPause;
        WindowPause.OnRestartClick -= RestartLevel;
        WindowPause.OnExitToMenuClick -= QuitToMenu;
        GameUI.OnPauseClick -= PauseGame;
        Ball.OnDie -= RestartLevel;
        Finish.OnFinishComplete -= LevelComplete;
    }

    private void Start()
    {
        OpenMenu();
    }

    private void StartPlay()
    {
        OnBeginSelectLevel?.Invoke();
    }

    private void PauseGame()
    {
        OnPauseGame?.Invoke();
    }

    private void CancelPause()
    {
        OnResumeGame?.Invoke();
    }

    private void RestartLevel()
    {
        StartLevel(_currentLevel);
    }

    private void LevelComplete()
    {
        _currentLevel++;
        StartLevel(_currentLevel);
    }

    private void QuitToMenu()
    {
        OnExitGame?.Invoke();
        OpenMenu();
    }

    private void OpenMenu()
    {
        SceneManager.LoadScene(1);
        OnShowMenu?.Invoke();
    }

    private void StartLevel(int level)
    {
        int sceneId = 2;
        switch (level)
        {
            case 1:
                sceneId = 2;
                break;
            case 2:
                sceneId = 3;
                break;
            case 3:
                sceneId = 4;
                break;
            case 4:
                sceneId = 5;
                break;
            case 5:
                sceneId = 6;
                break;
            default:
                sceneId = 2;
                break;
        }

        SceneManager.LoadScene(sceneId);
        OnLevelStart?.Invoke(level);
    }


}
