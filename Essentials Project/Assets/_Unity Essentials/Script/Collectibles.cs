using UnityEngine;

public class Collectibles : MonoBehaviour {
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject onCollectEffect;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 0, rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Destroy the collectible
            Destroy(gameObject);//its better use SetActive the GameObject for the scene and data 
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
