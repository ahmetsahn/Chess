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
        //child objesinde taþ varsa false

        if (transform.childCount > 1)
        {
            isOccupied = true;
        }
        else
        {
            isOccupied = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(pos);
    }

   
}
