using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerController))]
public class PlayerControls : MonoBehaviour
{
    #region References
        PlayerController controller;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(CallbackContext ctx)
    {
        controller.MovInput = ctx.ReadValue<Vector2>();
    }

    public void OnAim(CallbackContext ctx)
    {
        controller.AimInput = ctx.ReadValue<Vector2>();
    }

    public void OnInteract(CallbackContext ctx){
        if(ctx.performed){
            controller.Interact();
        }
    }
}
