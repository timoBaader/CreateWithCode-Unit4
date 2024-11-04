using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject _focalPoint;

    public GameObject PowerUpIndicator;
    public bool hasPowerUp = false;
    public float powerupStrength = 10f;
    public float speed = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(_focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        PowerUpIndicator.SetActive(hasPowerUp);
        Vector3 PowerUpIndicatorPosition = new Vector3(
            _rigidbody.position.x,
            -0.5f,
            _rigidbody.position.z
        );
        PowerUpIndicator.transform.position = PowerUpIndicatorPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyrigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromplayer = enemyrigidbody.position - _rigidbody.position;

            enemyrigidbody.AddForce(awayfromplayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("collided with enemy while powerup enabled");
        }
    }
}
