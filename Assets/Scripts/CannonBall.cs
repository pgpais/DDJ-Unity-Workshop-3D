using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour {

    [SerializeField] CannonBallData data;

    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * data.launchForce, ForceMode.Impulse);
        Destroy(gameObject, data.timeToDie);
    }
}