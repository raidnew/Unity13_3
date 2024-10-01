using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private WindowMain _windowMain;
    [SerializeField] private WindowLevels _windowLevels;
    [SerializeField] private WindowPause _windowPause;

    private void OnEnable()
    {
        Game.OnShowMenu += _windowMain.Open;
        Game.OnBeginSelectLevel += _windowLevels.Open;
        Game.OnPauseGame += _windowPause.Open;
    }

    private void OnDisable()
    {
        Game.OnShowMenu -= _windowMain.Open;
        Game.OnBeginSelectLevel -= _windowLevels.Open;
        Game.OnPauseGame -= _windowPause.Open;
    }
}
