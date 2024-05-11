using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ResetZone : MonoBehaviour
{
    public GameObject EndlPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        EndlPanel.SetActive(true);
    }

}
