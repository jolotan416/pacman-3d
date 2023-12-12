using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    [SerializeField]
    private float speed = 5f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        playerRigidbody.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speed + Vector3.right * Input.GetAxis("Horizontal") * speed, ForceMode.Impulse);
    }
}
