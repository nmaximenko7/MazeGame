using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ResetZone : MonoBehaviour, IDeadZoneActivator
{
    public GameObject EndlPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DeadPlayer();
    }
    public void DeadPlayer()
    {
        EndlPanel.SetActive(true);
    }

}
