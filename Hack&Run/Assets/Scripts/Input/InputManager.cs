using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject selectedGameObject;
    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;


        RaycastHit2D rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));
        //if you click on the screen
        if (!rayHit.collider)
        {
            if (selectedGameObject != null)
                selectedGameObject.GetComponent<IClicked>().onClickOtherAction();
            selectedGameObject = null;
            return;
        }
        //if you click on other colliders
        if(selectedGameObject != null && selectedGameObject != rayHit.collider.gameObject)
        {
            selectedGameObject.GetComponent<IClicked>().onClickOtherAction();
        }
        selectedGameObject = rayHit.collider.gameObject;
        selectedGameObject.GetComponent<IClicked>().onClickAction();
    }
}
