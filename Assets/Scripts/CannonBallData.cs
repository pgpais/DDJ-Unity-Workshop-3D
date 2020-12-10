using UnityEngine;

[CreateAssetMenu(fileName = "CannonBallData", menuName = "CannonBallData", order = 0)]
public class CannonBallData : ScriptableObject {
    public float launchForce = 10f;
    public float timeToDie = 2f;
}