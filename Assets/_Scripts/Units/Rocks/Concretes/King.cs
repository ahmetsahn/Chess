using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class King : BaseRock
{
    private Vector2 startPos;
    private bool whiteKingCanMakeShortCastro = true;
    private bool whiteKingCanMakeLongCastro = true;
    private bool BlackKingCanMakeShortCastro = true;
    private bool BlackKingCanMakeLongCastro = true;

    
    

    protected override void Start()
    {
        base.Start();
        SetStartPost();
    }

    private void SetStartPost()
    {
        startPos = transform.position;
    }

    public void HasItEverMovedControl()
    {
        HasItEverMovedControlForWhite();
        HasItEverMovedControlForBLack();
        CanWhiteKingMakeShortCastroControl();
        CanWhiteKingMakeLongCastroControl();
        CanBlackKingMakeShortCastroControl();
        CanBlackKingMakeLongCastroControl();

    }

    private void CanBlackKingMakeLongCastroControl()
    {
        if ((Vector2)GameManager.Instance.blackRookLeft.transform.position != GameManager.Instance.blackRookLeft.StartPos)
        {
            BlackKingCanMakeLongCastro = false;
        }
    }

    private void CanBlackKingMakeShortCastroControl()
    {
        if ((Vector2)GameManager.Instance.blackRookRight.transform.position != GameManager.Instance.blackRookRight.StartPos)
        {
            BlackKingCanMakeShortCastro = false;
        }
    }

    private void CanWhiteKingMakeLongCastroControl()
    {
        if ((Vector2)GameManager.Instance.whiteRookLeft.transform.position != GameManager.Instance.whiteRookLeft.StartPos)
        {
            whiteKingCanMakeLongCastro = false;
        }
    }

    private void CanWhiteKingMakeShortCastroControl()
    {
        if ((Vector2)GameManager.Instance.whiteRookRight.transform.position != GameManager.Instance.whiteRookRight.StartPos)
        {
            whiteKingCanMakeShortCastro = false;
        }
    }

    private void HasItEverMovedControlForBLack()
    {
        if (rockColor == RockColor.Black)
        {
            if ((Vector2)transform.position != startPos)
            {
                BlackKingCanMakeShortCastro = false;
                BlackKingCanMakeLongCastro = false;
            }
        }
    }

    private void HasItEverMovedControlForWhite()
    {
        if (rockColor == RockColor.White)
        {
            if ((Vector2)transform.position != startPos)
            {
                whiteKingCanMakeShortCastro = false;
                whiteKingCanMakeLongCastro = false;
            }
        }
    }

    public override void ShowNodesItCanGo()
    {

        if (GameManager.Instance.isWhiteKingShahed || GameManager.Instance.isBlackKingShahed)
        {
            ThreatenedDirection();
            ShahStateMove();
            return;
        }

        HasItEverMovedControl();
        CanGoRightControl();
        CanGoLeftControl();
        CanGoForwardControl();
        CanGoBackControl();
        CanGoForwardRightControl();
        CanGoBackLeftControl();
        CanGoBackRightControl();
        CanGoForwardLeftControl();
        WhiteKingCanMakeCastroControl();
        BlackKingCanMakeCastroControl();

    }

    private void BlackKingCanMakeCastroControl()
    {
        if (rockColor == RockColor.Black && GameManager.Instance.isBlackKingShahed == false)
        {
            BlackKingCanMakeLongCastroControl();
            BlackKingCanMakeShortCastroControl();

        }
    }

    private void WhiteKingCanMakeCastroControl()
    {
        if (rockColor == RockColor.White && GameManager.Instance.isWhiteKingShahed == false)
        {
            WhiteKingCanMakeLongCastroControl();
            WhiteKingCanMakeShortCastroControl();

        }
    }

    private void BlackKingCanMakeShortCastroControl()
    {
        if (BlackKingCanMakeShortCastro)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y)) == false
            && GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 2, transform.position.y)) == false)))
            {
                var castroMark = CastroMarkPool.Instance.Get();
                castroMark.transform.position = new Vector2(transform.position.x + 2, transform.position.y);
                castroMark.gameObject.SetActive(true);
            }


        }
    }

    private void BlackKingCanMakeLongCastroControl()
    {
        if (BlackKingCanMakeLongCastro)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y)) == false
            && GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 2, transform.position.y)) == false
            && GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 3, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 3, transform.position.y)) == false))))
            {
                var castroMark = CastroMarkPool.Instance.Get();
                castroMark.transform.position = new Vector2(transform.position.x - 2, transform.position.y);
                castroMark.gameObject.SetActive(true);
            }


        }
    }

    private void WhiteKingCanMakeShortCastroControl()
    {
        if (whiteKingCanMakeShortCastro)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y)) == false
            && GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 2, transform.position.y)) == false)))
            {
                var castroMark = CastroMarkPool.Instance.Get();
                castroMark.transform.position = new Vector2(transform.position.x + 2, transform.position.y);
                castroMark.gameObject.SetActive(true);
            }


        }
    }

    private void WhiteKingCanMakeLongCastroControl()
    {
        if (whiteKingCanMakeLongCastro)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y)) == false
            && GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 2, transform.position.y)) == false
            && GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 3, transform.position.y) && x.isOccupied == false
            && GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 3, transform.position.y)) == false))))
            {
                var castroMark = CastroMarkPool.Instance.Get();
                castroMark.transform.position = new Vector2(transform.position.x - 2, transform.position.y);
                castroMark.gameObject.SetActive(true);
            }


        }
    }

    private void CanGoForwardLeftControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoBackRightControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoBackLeftControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoForwardRightControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoBackControl()
    {
        newPos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoForwardControl()
    {
        newPos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoLeftControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void CanGoRightControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y);

        if (IsNodeEmpty(newPos) || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        DetermineRightMoveControl();
        DetermineLeftMoveControl();
        DetermineForwardMoveControl();
        DetermineBackMoveControl();
        DetermineForwardRightMoveControl();
        DetermineBackLeftMoveControl();
        DetermineBackRightMoveControl();
        DetermineForwardLeftMoveControl();
    }

    private void DetermineForwardLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineBackRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineBackLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineForwardRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineBackMoveControl()
    {
        newPos = new Vector2(transform.position.x, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineForwardMoveControl()
    {
        newPos = new Vector2(transform.position.x, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y);


        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);

        }
    }

    private void DetermineRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))

        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    public void ThreatenedDirection()
    {

      
        Vector2 tehditYonu = GameManager.Instance.threateningRock.transform.position - transform.position;

    
        tehditYonu.Normalize();

     
        float tehditAci = Mathf.Atan2(tehditYonu.y, tehditYonu.x);

     
        float tehditAciDerece = tehditAci * Mathf.Rad2Deg;

        
        if (tehditAciDerece == 0)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Right;
        }
        else if (tehditAciDerece == 90)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Forward;
        }
        else if (tehditAciDerece == -90)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Back;
        }
        else if (tehditAciDerece == 180)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Left;
        }
        else if (tehditAciDerece == 45)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.ForwardRightCross;
        }
        else if (tehditAciDerece == -45)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.BackRightCross;
        }
        else if (tehditAciDerece == 135)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.ForwardLeftCross;
        }
        else if (tehditAciDerece == -135)
        {
            directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.BackLeftCross;
        }
        
     
    }

    public override void DetermineShahStateMove()
    {
        ThreatenedDirection();
        DetermineShahStateRightMove();
        DetermineShahStateLeftMove();
        DetermineShahStateForwardMove();
        DetermineShahStateBackMove();
        DetermineShahStateForwardRightMove();
        DetermineShahStateBackLeftMove();
        DetermineShahStateBackRightMove();
        DetermineShahStateForwardLeftMove();
    }

    private void DetermineShahStateForwardLeftMove()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackRightCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateBackRightMove()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardLeftCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateBackLeftMove()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardRightCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateForwardRightMove()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackLeftCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateBackMove()
    {
        newPos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Forward || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateForwardMove()
    {
        newPos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Back || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateLeftMove()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Right || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateRightMove()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Left || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    public override void ShahStateMove()
    {
        ShahStateRightMoveControl();
        ShahStateLeftMoveControl();
        ShahStateForwardMoveControl();
        ShahStateBackMoveControl();
        ShahStateForwardRightMoveControl();
        ShahStateBackLeftMoveControl();
        ShahStateBackRightMoveControl();
        ShahStateForwardLeftMoveControl();
    }

    private void ShahStateForwardLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackRightCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateBackRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardLeftCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }

    private void ShahStateBackLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardRightCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }

    private void ShahStateForwardRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackLeftCross || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }

    private void ShahStateBackMoveControl()
    {
        newPos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Forward || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }

    private void ShahStateForwardMoveControl()
    {
        newPos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Back || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }

    private void ShahStateLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Right || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }

    private void ShahStateRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y);

        if (IsNodeEmpty(newPos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Left || IsNodeOccupied(newPos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == newPos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == newPos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(newPos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(newPos);
            }
        }
    }
}
