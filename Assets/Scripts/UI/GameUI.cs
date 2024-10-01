using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    static public Action OnPauseClick;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private NoticeField _noticeField;

    void OnEnable()
    {
        Game.OnLevelStart += OnLevelStart;
        Game.OnPauseGame += OnPauseGame;
        Game.OnResumeGame += OnResumeGame;
        Game.OnExitGame += OnExitGame;
        NoticeArea.OnNotice += ShowNotice;
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    void OnDisable()
    {
        Game.OnLevelStart -= OnLevelStart;
        Game.OnPauseGame -= OnPauseGame;
        Game.OnResumeGame -= OnResumeGame;
        Game.OnExitGame -= OnExitGame;
        NoticeArea.OnNotice -= ShowNotice;
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnLevelStart(int level)
    {
        ShowNotice($"Level {level} has started");
        this._pauseButton.gameObject.SetActive(true);
    }

    private void OnPauseGame()
    {
        this._pauseButton.gameObject.SetActive(false);
    }    
    
    private void OnResumeGame()
    {
        this._pauseButton.gameObject.SetActive(true);
    }
    
    private void OnExitGame()
    {
        this._pauseButton.gameObject.SetActive(false);
    }
    
    private void OnPauseButtonClick()
    {
        OnPauseClick?.Invoke();
    }

    private void ShowNotice(string message)
    {
        _noticeField.ShowMessage(message);
    }
}
