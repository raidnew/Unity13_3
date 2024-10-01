using UnityEngine;

public class HintObject : NoticeArea
{
    [SerializeField] private string _hintText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICanUse>() != null)
            OnNotice?.Invoke(_hintText);
    }
}
