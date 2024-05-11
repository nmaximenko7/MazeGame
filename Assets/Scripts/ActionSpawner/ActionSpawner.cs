using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionSpawner : MonoBehaviour
{
    public Transform EntityTransform;
    public Transform ScrimerTransform;

    [SerializeField] private GameObject _triggerLeft;
    [SerializeField] private GameObject _triggerBottom;
    private Cell3D _cell3D;
    void Start()
    {
        _cell3D = GetComponent<Cell3D>();
        _triggerLeft.GetComponent<ActionSpawnTrigger>().OnTriggerEvent.AddListener(OnTriggerAction);
        _triggerBottom.GetComponent<ActionSpawnTrigger>().OnTriggerEvent.AddListener(OnTriggerAction);
    }

    void OnTriggerAction()
    {
        CellRole thisCellRole = MazeGenerator3D.Instance.CurrentMazeData[_cell3D.X, _cell3D.Y].ThisCellRole;
        if (thisCellRole == CellRole.ENTITY)
        {
            Transform entity = Instantiate(EntityTransform, transform);
            entity.position = transform.position + new Vector3(0, 3f, 0);
            PlayerControl playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            playerMove.IsStopped = true;
            SetCheckpointPlayer(MazeGenerator3D.Instance);
        }else if (thisCellRole == CellRole.SCRIMER)
        {
            ScoreCounter.Instance.Score += 1;
            Transform scrimer = Instantiate(ScrimerTransform, transform);
            scrimer.position = transform.position + new Vector3(0, 3f, 0);
            SetCheckpointPlayer(MazeGenerator3D.Instance);
        }
    }

    private void SetCheckpointPlayer(MazeGenerator3D mazeGenerator)
    {
        for (int x = 0; x < mazeGenerator.CurrentMazeData.GetLength(0); x++)
        {
            for (int y = 0; y < mazeGenerator.CurrentMazeData.GetLength(1); y++)
            {
                if (mazeGenerator.CurrentMazeData[x, y].ThisCellRole == CellRole.START)
                    mazeGenerator.CurrentMazeData[x, y].ThisCellRole = CellRole.MID;
            }
        }
        mazeGenerator.CurrentMazeData[_cell3D.X, _cell3D.Y].ThisCellRole = CellRole.START;
        mazeGenerator.CurrentMazeData[_cell3D.X, _cell3D.Y].TriggerBottom = false;
        mazeGenerator.CurrentMazeData[_cell3D.X, _cell3D.Y].TriggerLeft = false;
        _triggerBottom.SetActive(false);
        _triggerLeft.SetActive(false);
    }

}
