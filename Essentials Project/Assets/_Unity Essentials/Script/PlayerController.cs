using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour {
    [SerializeField] float speed; // Set player's movement speed.
    [SerializeField] float rotationSpeed; // Set player's rotation speed.
    [SerializeField] float jumpForce;

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update() {
        JumpPlayer();
    }


    // Handle physics-based movement and rotation.
    private void FixedUpdate() {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public void JumpPlayer() {
        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}
