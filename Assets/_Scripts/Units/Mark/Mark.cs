using DG.Tweening;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


public class Mark : BaseMark
{

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        GameManager.Instance.selectedRock.Move(transform.position);

        IsTheMovingNodeOccupiedControl();

        GameManager.Instance.ToggleState();

    }

    private void IsTheMovingNodeOccupiedControl()
    {
        if (GameManager.Instance.nodesList.Find(x => x.transform.position == transform.position).isOccupied)
        {
            var node = GameManager.Instance.nodesList.Find(x => x.transform.position == transform.position);
            node.GetComponentInChildren<BaseRock>().Die();
        }
    }



}
