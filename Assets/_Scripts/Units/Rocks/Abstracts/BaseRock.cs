using System;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

public abstract class BaseRock : MonoBehaviour
{
    public DirectionInWhichItIsoccupied directionInWhichItIsoccupied;
    public RockColor rockColor;
    public RockType rockType;
    public RockScore rockScore;

    public static event Action OnDetermineAllTheNodesItCanGo;
    public static event Action OnDetermineShahStateMoveForWhite;
    public static event Action OnDetermineShahStateMoveForBlack;



    public static void LoadDetermineAllTheNodesItCanGo()
    {
        OnDetermineAllTheNodesItCanGo?.Invoke();
    }

    public static void LoadDetermineShahStateMoveForWhite()
    {
        OnDetermineShahStateMoveForWhite?.Invoke();
    }

    public static void LoadDetermineShahStateMoveForBlack()
    {
        OnDetermineShahStateMoveForBlack?.Invoke();
    }
    



    // <summary>
    // If there is an enemy in the nodes that it can go to, it creates a mark for that node.
    // If the nodes it can go to are empty, create a mark on that node
    // <summary>
    public abstract void ShowNodesItCanGo();


    // <summary>
    // Determines all nodes it can go to, fake.Creates an empty object named fakemark and keeps the position of these points in the list
    // The purpose of this function is to prevent the king from making a wrong move.
    // <summary>
    public abstract void DetermineAllTheNodesItCanGoTo();


    public virtual void OccupiedMove()
    {

    }

    public virtual void DetermineOccupiedRock()
    {

    }

    public virtual void ShahStateMove()
    {

    }

    public virtual void DetermineShahStateMove()
    {

    }

    public void DetermineShahStateMoveForWhite()
    {
        if (rockColor == RockColor.White)
        {
            DetermineShahStateMove();
        }
    }

    public void DetermineShahStateMoveForBlack()
    {
        

        if (rockColor == RockColor.Black)
        {
            DetermineShahStateMove();
        }
    }


    public void Move(Vector2 markPos)
    {

        transform.SetParent(null);
        transform.DOMove(markPos, 0.5f).onComplete += () =>
        transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)transform.position).transform);
    }

    protected virtual void Start()
    {

        SetNodeAsParent();

        OnDetermineAllTheNodesItCanGo += DetermineAllTheNodesItCanGo;
        OnDetermineShahStateMoveForWhite += DetermineShahStateMoveForWhite;
        OnDetermineShahStateMoveForBlack += DetermineShahStateMoveForBlack;
        

    }


    private async void DetermineAllTheNodesItCanGo()
    {
        await Task.Delay(505);

        if (gameObject.activeSelf)
        {
            if (rockColor == RockColor.Black)
            {
                DetermineAllTheNodesItCanGoTo();
                GameManager.Instance.nodesListTheBlackCanGoTo = GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Select(fakeMark => (Vector2)fakeMark.transform.position).ToList();

            }

            await Task.Delay(50);
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Clear();
            await Task.Delay(50);

            if (rockColor == RockColor.White)
            {
                DetermineAllTheNodesItCanGoTo();
                GameManager.Instance.nodesListTheWhiteCanGoTo = GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Select(fakeMark => (Vector2)fakeMark.transform.position).ToList();
            }

            DetermineOccupiedRock();
        }

        
        
    }

    


    private void SetNodeAsParent()
    {
        transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)transform.position).transform);
    }

    private void OnMouseDown()
    {
        SequenceControl();
    }

    private void SequenceControl()
    {
        if (GameManager.Instance.state == GameStates.WaitingForWhiteInput && rockColor == RockColor.White)
        {
            GameManager.Instance.selectedRock = this;
            GameObject.FindGameObjectsWithTag("Mark").Select(m => m.GetComponent<Mark>()).ToList().ForEach(MarkPool.Instance.ReturnToPool);
            ShowNodesItCanGo();


        }
        if (GameManager.Instance.state == GameStates.WaitingForBlackInput && rockColor == RockColor.Black)
        {
            GameManager.Instance.selectedRock = this;
            GameObject.FindGameObjectsWithTag("Mark").Select(m => m.GetComponent<Mark>()).ToList().ForEach(MarkPool.Instance.ReturnToPool);
            ShowNodesItCanGo();
        }
    }

    protected bool IsNodeOccupied(Vector2 pos, bool isSameColor)
    {
        var node = GameManager.Instance.nodesList.FirstOrDefault(x => x.pos == pos && x.isOccupied == true);
        if (node == null)
            return false;

        var rock = node.GetComponentInChildren<BaseRock>();
        return isSameColor ? rock.rockColor == rockColor : rock.rockColor != rockColor;
    }

    protected bool IsNodeEmpty(Vector2 pos)
    {
        return GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == false);
    }

    protected bool IsTheNodeInTheNodeList(Vector2 pos)
    {
        return GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos);
    }

    protected void GetMark(Vector2 pos)
    {
        var mark = MarkPool.Instance.Get();
        mark.transform.position = pos;
        mark.gameObject.SetActive(true);
    }

    protected void AddFakeMarkToList(Vector2 position,List<FakeMark> list)
    {
        var fakeMark = FakeMarkPool.Instance.Get();
        list.Add(fakeMark);
        fakeMark.transform.position = position;
        fakeMark.gameObject.SetActive(true);
    }

    protected void AddOccupiedMarkToList(Vector2 position)
    {
        var occupiedMark = OccupiedMarkPool.Instance.Get();
        GameManager.Instance.occupiedRockList.Add(occupiedMark);
        occupiedMark.transform.position = position;
        occupiedMark.gameObject.SetActive(true);
    }


   


    public void Die()
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(null);
    }


}

public enum RockType
{
    Pawn,
    Rook,
    Knight,
    Bishop,
    Queen,
    King
}

public enum RockColor
{
    White,
    Black
}
public enum DirectionInWhichItIsoccupied
{
    Forward,
    Back,
    Right,
    Left,
    ForwardRightCross,
    BackRightCross,
    ForwardLeftCross,
    BackLeftCross
}

[Serializable]
public struct RockScore
{
    public int score;
}
