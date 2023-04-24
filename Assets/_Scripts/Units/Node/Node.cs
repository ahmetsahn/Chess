using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector2 pos;

    public bool isOccupied;

    private void Start()
    {
        pos = transform.position;
    }

    private void Update()
    {
        IsNodeOccupied();
    }

    private void IsNodeOccupied()
    {
        if (transform.childCount > 1)
        {
            isOccupied = true;
        }
        else
        {
            isOccupied = false;
        }
    }

}
