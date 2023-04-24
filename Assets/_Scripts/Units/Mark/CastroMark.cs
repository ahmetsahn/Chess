using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CastroMark : MonoBehaviour
{
    private void OnMouseDown()
    {
        WhiteLongCastlingMarkClickControl();
        WhiteShortCastlingMarkClickControl();
        BlackLongCastlingMarkClickControl();
        BlackShortCastlingMarkClickControl();

        CastroMarkPool.Instance.ReturnToPool(this);
        GameManager.Instance.ToggleState();


    }

    private void BlackShortCastlingMarkClickControl()
    {
        if ((Vector2)transform.position == new Vector2(6, 7))
        {
            BlackKingShortCastlingMove();
            BlackRookShortCastlingMove();
        }
    }

    private void BlackLongCastlingMarkClickControl()
    {
        if ((Vector2)transform.position == new Vector2(2, 7))
        {
            BlackKingLongCastlingMove();
            BlackRookLongCastlingMove();
        }
    }

    private void WhiteShortCastlingMarkClickControl()
    {
        if ((Vector2)transform.position == new Vector2(6, 0))
        {
            WhiteKingShortCastlingMove();
            WhiteRookShortCastlingMove();
        }
    }

    private void WhiteLongCastlingMarkClickControl()
    {
        if ((Vector2)transform.position == new Vector2(2, 0))
        {
            WhiteKingLongCastlingMove();
            WhiteRookLongCastlingMove();
        }
    }

    private static void BlackRookShortCastlingMove()
    {
        GameManager.Instance.blackRookRight.transform.SetParent(null);
        GameManager.Instance.blackRookRight.transform.DOMove(new Vector2(5, 7), 0.5f).onComplete += () =>
        GameManager.Instance.blackRookRight.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.blackRookRight.transform.position).transform);
    }

    private static void BlackKingShortCastlingMove()
    {
        GameManager.Instance.blackKing.transform.SetParent(null);
        GameManager.Instance.blackKing.transform.DOMove(new Vector2(6, 7), 0.5f).onComplete += () =>
        GameManager.Instance.blackKing.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.blackKing.transform.position).transform);
    }

    private static void BlackRookLongCastlingMove()
    {
        GameManager.Instance.blackRookLeft.transform.SetParent(null);
        GameManager.Instance.blackRookLeft.transform.DOMove(new Vector2(3, 7), 0.5f).onComplete += () =>
        GameManager.Instance.blackRookLeft.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.blackRookLeft.transform.position).transform);
    }

    private static void BlackKingLongCastlingMove()
    {
        GameManager.Instance.blackKing.transform.SetParent(null);
        GameManager.Instance.blackKing.transform.DOMove(new Vector2(2, 7), 0.5f).onComplete += () =>
        GameManager.Instance.blackKing.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.blackKing.transform.position).transform);
    }

    private static void WhiteRookShortCastlingMove()
    {
        GameManager.Instance.whiteRookRight.transform.SetParent(null);
        GameManager.Instance.whiteRookRight.transform.DOMove(new Vector2(5, 0), 0.5f).onComplete += () =>
        GameManager.Instance.whiteRookRight.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.whiteRookRight.transform.position).transform);
    }

    private static void WhiteKingShortCastlingMove()
    {
        GameManager.Instance.whiteKing.transform.SetParent(null);
        GameManager.Instance.whiteKing.transform.DOMove(new Vector2(6, 0), 0.5f).onComplete += () =>
        GameManager.Instance.whiteKing.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.whiteKing.transform.position).transform);
    }

    private static void WhiteRookLongCastlingMove()
    {
        GameManager.Instance.whiteRookLeft.transform.SetParent(null);
        GameManager.Instance.whiteRookLeft.transform.DOMove(new Vector2(3, 0), 0.5f).onComplete += () =>
        GameManager.Instance.whiteRookLeft.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.whiteRookLeft.transform.position).transform);
    }

    private static void WhiteKingLongCastlingMove()
    {
        GameManager.Instance.whiteKing.transform.SetParent(null);
        GameManager.Instance.whiteKing.transform.DOMove(new Vector2(2, 0), 0.5f).onComplete += () =>
        GameManager.Instance.whiteKing.transform.SetParent(GameManager.Instance.nodesList.Find(x => x.pos == (Vector2)GameManager.Instance.whiteKing.transform.position).transform);
    }
}
