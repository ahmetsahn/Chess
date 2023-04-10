using System.Linq;
using UnityEngine;

public class King : BaseRock
{
    private Vector2 startPos;
    public bool canWhiteKingMakeShortCastro = true;
    private bool canWhiteKingMakeLongCastro = true;
    private bool canBlackKingMakeShortCastro = true;
    private bool canBlackKingMakeLongCastro = true;

    protected override void Start()
    {
        base.Start();
        startPos = transform.position;
    }

    public void HasItEverMovedControl()
    {
        if (rockColor == RockColor.White)
        {
            if ((Vector2)transform.position != startPos)
            {
                canWhiteKingMakeShortCastro = false;
                canWhiteKingMakeLongCastro = false;
            }
        }
        else
        {
            if ((Vector2)transform.position != startPos)
            {
                canBlackKingMakeShortCastro = false;
                canBlackKingMakeLongCastro = false;
            }
        }

        if ((Vector2)GameManager.Instance.whiteRookRight.transform.position != GameManager.Instance.whiteRookRight.StartPos)
        {
            canWhiteKingMakeShortCastro = false;
        }

        if ((Vector2)GameManager.Instance.whiteRookLeft.transform.position != GameManager.Instance.whiteRookLeft.StartPos)
        {
            canWhiteKingMakeLongCastro = false;
        }

        if ((Vector2)GameManager.Instance.blackRookRight.transform.position != GameManager.Instance.blackRookRight.StartPos)
        {
            canBlackKingMakeShortCastro = false;
        }

        if ((Vector2)GameManager.Instance.blackRookLeft.transform.position != GameManager.Instance.blackRookLeft.StartPos)
        {
            canBlackKingMakeLongCastro = false;
        }


    }

    public override void ShowNodesItCanGo()
    {

        HasItEverMovedControl();


        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y) && x.isOccupied == false))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + 1) && x.isOccupied == false))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + 1) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - 1) && x.isOccupied == false))
        {

            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - 1) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 1) && x.isOccupied == false))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 1) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 1) && x.isOccupied == false))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 1) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {

            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 1) && x.isOccupied == false))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 1) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                mark.gameObject.SetActive(true);
            }
        }


        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 1) && x.isOccupied == false))
        {

            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }
        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 1) && x.isOccupied == true
               && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                mark.gameObject.SetActive(true);
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

    public override void DetermineShahStateMove()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + 1) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - 1) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 1) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 1) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 1) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y - 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x + 1, transform.position.y - 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 1) && x.isOccupied == false))

        {
            bool anyEqualForBlack = GameManager.Instance.nodesListTheBlackCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y + 1));
            bool anyEqualForWhite = GameManager.Instance.nodesListTheWhiteCanGoTo.Any(y => y == new Vector2(transform.position.x - 1, transform.position.y + 1));

            if (anyEqualForBlack == false && rockColor == RockColor.White)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

            if (anyEqualForWhite == false && rockColor == RockColor.Black)
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);
            }

        }
    }

}
