using System.Collections;
using TMPro;
using UnityEngine;

public class NoticeField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _noticeField;

    public void ShowMessage(string message)
    {
        StartCoroutine(AppearMessage(message));
    }

    private IEnumerator AppearMessage(string message)
    {
        _noticeField.enabled = true;
        _noticeField.text = message;
        yield return new WaitForSeconds(3);
        _noticeField.text = "";
        _noticeField.enabled = false;
        yield return false;
    }

}
