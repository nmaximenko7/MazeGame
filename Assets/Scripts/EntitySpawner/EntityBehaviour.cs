using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EntityBehaviour : MonoBehaviour
{
    private Transform _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        if ( _player != null)
        {
            Vector3 direction = _player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up); ;
        }
    }
}
