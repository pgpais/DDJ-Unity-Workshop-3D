using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Input Fields
        public Vector2 movInput;

        public Vector2 aimInput;
    #endregion

    [SerializeField] float movSpeed = 5f;

    [Header("Aiming")]
    [SerializeField] float lookClamp = 70f;

    [Header("Interacting")]
    [SerializeField] float interactRange = 5f;
    [SerializeField] LayerMask interactLayer;

    #region References
        [Header("References")]
        [SerializeField] Transform cam;
        Rigidbody rb;
    #endregion

    float mouseRot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mouseRot = cam.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DoMovement();
        DoAim();
    }

    private void DoMovement()
    {
        Vector3 forward = transform.forward * movInput.y;
        Vector3 right = transform.right * movInput.x;

        rb.velocity = (forward + right) * movSpeed + new Vector3(0, rb.velocity.y);
    }

    private void DoAim()
    {
        // Rotate Body
        transform.Rotate(new Vector3(0, aimInput.x));

        // Rotate Camera

        // Add rotation input
        mouseRot += aimInput.y;
        // Clamp so player doesn't turn upside down
        mouseRot = Mathf.Clamp(mouseRot, -lookClamp, lookClamp);

        // Get camera's rotation and change X axis
        Vector3 newRot = cam.rotation.eulerAngles;
        newRot.x = mouseRot;
        cam.rotation = Quaternion.Euler(newRot);
    }

    public void Interact(){
        Debug.DrawRay(cam.position, cam.forward * interactRange);
        
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, interactRange, interactLayer)){
            hit.collider.GetComponent<Button>().Interact();
        }
    }
}
