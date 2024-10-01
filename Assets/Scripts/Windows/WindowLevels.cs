using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowLevels : BaseWindow
{

    [SerializeField] private Button _buttonCancel;
    [SerializeField] private LevelIcon _levelIcon;
    [SerializeField] private Transform _levelsContainer;

    public static Action<int> OnLevelSelect;
    public static Action OnCancelLevelSelect;
    

    public void OnEnable()
    {
        _buttonCancel.onClick.AddListener(CancelSelect);
    }

    public void OnDisable()
    {
        _buttonCancel.onClick.RemoveListener(CancelSelect);
    }

    void Start()
    {
        CreateLevelsList();
    }

    private void CancelSelect()
    {
        Close();
        OnCancelLevelSelect?.Invoke();
    }

    private void CreateLevelsList()
    {
        int levelInRow = 6;

        for (int i = 0; i < 10; i++)
        {
            LevelIcon levelBtn = GameObject.Instantiate<LevelIcon>(_levelIcon);
            LevelInfo test = new LevelInfo(i + 1, i < 5, i < 4, i % 4);
            levelBtn.InitInfo(test);
            levelBtn.gameObject.transform.SetParent(_levelsContainer, true);
            levelBtn.gameObject.transform.SetLocalPositionAndRotation(new Vector3(i % levelInRow * 150, i / levelInRow * 100, 0), Quaternion.Euler(Vector3.zero));
            levelBtn.OnLevelSelect += OnLevelClick;
        }
    }

    private void OnLevelClick(LevelInfo selectedLevel)
    {
        OnLevelSelect?.Invoke(selectedLevel.Number);
        Close();
    }
}
