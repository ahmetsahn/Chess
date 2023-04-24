using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class King : BaseRock
{
    private Vector2 startPos;
    private bool canWhiteKingMakeShortCastro = true;
    private bool canWhiteKingMakeLongCastro = true;
    private bool canBlackKingMakeShortCastro = true;
    private bool canBlackKingMakeLongCastro = true;

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
            canBlackKingMakeLongCastro = false;
        }
    }

    private void CanBlackKingMakeShortCastroControl()
    {
        if ((Vector2)GameManager.Instance.blackRookRight.transform.position != GameManager.Instance.blackRookRight.StartPos)
        {
            canBlackKingMakeShortCastro = false;
        }
    }

    private void CanWhiteKingMakeLongCastroControl()
    {
        if ((Vector2)GameManager.Instance.whiteRookLeft.transform.position != GameManager.Instance.whiteRookLeft.StartPos)
        {
            canWhiteKingMakeLongCastro = false;
        }
    }

    private void CanWhiteKingMakeShortCastroControl()
    {
        if ((Vector2)GameManager.Instance.whiteRookRight.transform.position != GameManager.Instance.whiteRookRight.StartPos)
        {
            canWhiteKingMakeShortCastro = false;
        }
    }

    private void HasItEverMovedControlForBLack()
    {
        if (rockColor == RockColor.Black)
        {
            if ((Vector2)transform.position != startPos)
            {
                canBlackKingMakeShortCastro = false;
                canBlackKingMakeLongCastro = false;
            }
        }
    }

    private void HasItEverMovedControlForWhite()
    {
        if (rockColor == RockColor.White)
        {
            if ((Vector2)transform.position != startPos)
            {
                canWhiteKingMakeShortCastro = false;
                canWhiteKingMakeLongCastro = false;
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


        var pos = new Vector2(transform.position.x + 1, transform.position.y);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos,false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x - 1, transform.position.y);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }

        pos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeEmpty(pos) || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }
    




        if (rockColor == RockColor.White && GameManager.Instance.isWhiteKingShahed == false)
        {

            if (canWhiteKingMakeLongCastro)
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

            if (canWhiteKingMakeShortCastro)
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

        if (rockColor == RockColor.Black && GameManager.Instance.isBlackKingShahed == false)
        {

            if (canBlackKingMakeLongCastro)
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

            if (canBlackKingMakeShortCastro)
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



    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + 1)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - 1)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 1)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 1)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 1)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 1)))

        {
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);

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

        var pos = new Vector2(transform.position.x + 1, transform.position.y);
        
        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied!= DirectionInWhichItIsoccupied.Left || IsNodeOccupied(pos,false))
            
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x - 1, transform.position.y);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Right || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Back || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Forward || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackLeftCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardRightCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardLeftCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }

        pos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackRightCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    public override void ShahStateMove()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Left || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Right || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Back || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.Forward || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackLeftCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardRightCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.ForwardLeftCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeEmpty(pos) && directionInWhichItIsoccupied != DirectionInWhichItIsoccupied.BackRightCross || IsNodeOccupied(pos, false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == pos);
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == pos);

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                GetMark(pos);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                GetMark(pos);
            }

        }
    }

}
