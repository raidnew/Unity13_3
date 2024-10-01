using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowMain : BaseWindow
{
    public static Action OnPlayStart;

    [SerializeField] private Button _playButton;

    void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        Close();
        OnPlayStart?.Invoke();
    }
}
