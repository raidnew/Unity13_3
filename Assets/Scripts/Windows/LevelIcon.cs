using Assets.Scripts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelIcon : MonoBehaviour
{
    public Action<LevelInfo> OnLevelSelect;

    [SerializeField] private Image[] _stars;
    [SerializeField] private Button _hitArea;
    [SerializeField] private TextMeshProUGUI _label;

    private LevelInfo _levelInfo;

    public void InitInfo(LevelInfo info)
    {
        _levelInfo = info;
        _label.text = $"Lvl {info.Number}";
    }

    private void OnEnable()
    {
        _hitArea.onClick.AddListener(ClickOnLevel);
    }

    private void OnDisable()
    {
        
    }

    private void ClickOnLevel()
    {
        OnLevelSelect?.Invoke(_levelInfo);
    }
}
