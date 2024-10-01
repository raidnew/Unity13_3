using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private InteractiveObject _interactiveObject;

    private void Update()
    {
        _interactiveObject?.SetHorisontal(Input.GetAxis(Constraints.Horizontal));
        _interactiveObject?.SetVertical(Input.GetAxis(Constraints.Vertical));
        if(Input.GetButtonDown(Constraints.Jump))
            _interactiveObject?.Jump();
    }
}
