using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoodleDeadZone : MonoBehaviour, IDeadZoneActivator
{
    private MiniGameGreenManager _gameManager;
    private Transform _player;
    private float offset;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = _player.transform.position.y - transform.position.y;
        _gameManager = FindAnyObjectByType(typeof(MiniGameGreenManager)).GetComponent<MiniGameGreenManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DeadPlayer();
        }
    }
    void LateUpdate()
    {
        if (_player.position.y > transform.position.y + offset)
        {
            Vector3 newPos = new Vector3(transform.position.x, _player.position.y - offset, transform.position.z);
            transform.position = newPos;
        }
    }
    public void DeadPlayer()
    {
        _gameManager.EndGame();
    }
}
