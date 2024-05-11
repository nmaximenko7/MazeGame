using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    private Transform _player;
    private EntityType _entityType;
    private Renderer _renderer;
    [SerializeField]private Material[] materials;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        Array entityTypes = Enum.GetValues(typeof(EntityType));
        _entityType = (EntityType)entityTypes.GetValue(UnityEngine.Random.Range(0, entityTypes.Length));
        Debug.Log(_entityType);
        _renderer.material = materials[(int)Enum.Parse(typeof(EntityType), _entityType.ToString())];
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(SwitchSceneForSeconds(5f));
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
    private IEnumerator SwitchSceneForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("MiniGame" + _entityType.ToString());
        GetComponent<SceneController>().SwitchToScene("MiniGame" + _entityType.ToString());
    }
}

public enum EntityType
{
    RED, GREEN, BLUE
}
