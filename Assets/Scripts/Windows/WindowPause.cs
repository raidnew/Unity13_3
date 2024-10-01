using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowPause : BaseWindow
{
    public static Action OnExitToMenuClick;
    public static Action OnCancelClick;
    public static Action OnRestartClick;

    [SerializeField] private Button _cancel;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _cancel?.onClick.AddListener(OnClickCancel);
        _restart?.onClick.AddListener(OnClickRestart);
        _exit?.onClick.AddListener(OnClickExit);
    }

    private void OnDisable()
    {
        _cancel.onClick.RemoveListener(OnClickCancel);
        _restart.onClick.RemoveListener(OnClickRestart);
        _exit.onClick.RemoveListener(OnClickExit);
    }

    private void OnClickCancel()
    {
        OnCancelClick?.Invoke();
        Close();
    }
    private void OnClickRestart()
    {
        OnRestartClick?.Invoke();
        Close();
    }
    private void OnClickExit()
    {
        OnExitToMenuClick?.Invoke();
        Close();
    }
}
