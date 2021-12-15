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
    [SerializeField] float lookSensitivity = 0.5f;

    [Header("Interacting")]
    [SerializeField] float interactRange = 5f;
    [SerializeField] LayerMask interactLayer;

    #region References
    [Header("References")]
    [SerializeField] Transform cam;
    Rigidbody rb;
    #endregion

    float mouseRot;

    // Awake happens before Start. Use it to initialize references
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mouseRot = cam.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        DoAim();
    }

    private void DoAim()
    {
        // Apply sensitivity
        aimInput *= lookSensitivity;

        // Rotate Body
        transform.Rotate(Vector3.up * aimInput.x);

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

    // FixedUpdate is called on every physics loop (constant time intervals)
    private void FixedUpdate()
    {
        DoMovement();
    }

    private void DoMovement()
    {
        Vector3 forward = transform.forward * movInput.y;
        Vector3 right = transform.right * movInput.x;

        // In some cases (like FPSs) you don't want to change velocity like this.
        // It's a very sudden change and can cause jittering.
        // In those cases, look up damping. (lerping can also work, but it is intended for different cases)
        rb.velocity = (forward + right) * movSpeed + new Vector3(0, rb.velocity.y);
    }

    public void Interact()
    {
        Debug.DrawRay(cam.position, cam.forward * interactRange);

        RaycastHit hit;
        // Fires a ray from the camera to cam.forward + interactRange
        // only hitting objects on the interactLayer (Button, in this case)
        if (Physics.Raycast(cam.position, cam.forward, out hit, interactRange, interactLayer))
        {
            hit.collider.GetComponent<Button>().Interact();
        }
    }
}
