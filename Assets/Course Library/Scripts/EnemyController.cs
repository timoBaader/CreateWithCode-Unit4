using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject _player;

    public float speed = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddForce(
            (_player.transform.position - _rigidbody.transform.position).normalized
                * speed
                * Time.deltaTime
        );
    }
}
