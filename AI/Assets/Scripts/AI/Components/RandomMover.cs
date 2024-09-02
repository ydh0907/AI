using UnityEngine;

public class RandomMover : MonoBehaviour, AIOutput
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Execute(Vector3 seed)
    {
        rb.AddForce(seed);
    }
}
