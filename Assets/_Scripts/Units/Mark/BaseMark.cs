using UnityEngine;

public class BaseMark : MonoBehaviour
{
    protected Vector2 pos;

    private void OnEnable()
    {
        pos = transform.position;
    }

    protected virtual void OnMouseDown()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.rockMoveSound, 1f);
    }
}
