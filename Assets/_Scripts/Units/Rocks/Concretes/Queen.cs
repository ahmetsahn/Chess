using System.Linq;
using UnityEngine;

public class Queen : BaseRock
{
    public override void ShowNodesItCanGo()
    {
        if (GameManager.Instance.occupiedRockList.Any(x => x.transform.position == transform.position))
        {
            OccupiedMove();
            return;
        }

        if (GameManager.Instance.isWhiteKingShahed || GameManager.Instance.isBlackKingShahed)
        {
            ShahStateMove();
            return;
        }


        ForwardMoveControl();
        BackMoveControl();
        RightMoveControl();
        LeftMoveControl();
        ForwardRightCrossMoveControl();
        BackRightCrossMoveControl();
        ForwardLeftCrossMoveControl();
        BackLeftCrossMoveControl();



    }

    private void BackLeftCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                mark.gameObject.SetActive(true);
                break;

            }
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void ForwardLeftCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                mark.gameObject.SetActive(true);
                break;
            }


            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void BackRightCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                mark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void ForwardRightCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                mark.gameObject.SetActive(true);
                break;
            }
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void BackMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {


                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                mark.gameObject.SetActive(true);
                break;
            }
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void ForwardMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                mark.gameObject.SetActive(true);
                break;
            }
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void LeftMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                mark.gameObject.SetActive(true);
                break;
            }
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                mark.gameObject.SetActive(true);

            }
        }
    }

    private void RightMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                mark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == false))
            {

                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                mark.gameObject.SetActive(true);

            }
        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                fakeMark.gameObject.SetActive(true);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                fakeMark.gameObject.SetActive(true);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);

            }
        }


        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
            }
        }


        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);

            }
        }


        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
                break;
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == false))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);

            }
        }

    }

    public override void DetermineOccupiedRock()
    {
        bool loopTerminator1 = false;
        bool loopTerminator2 = false;
        bool loopTerminator3 = false;
        bool loopTerminator4 = false;
        bool loopTerminator5 = false;
        bool loopTerminator6 = false;
        bool loopTerminator7 = false;
        bool loopTerminator8 = false;


        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator1) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator1 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator1 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x + i, transform.position.y)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Left;

                    }
                }
            }

        }





        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator2) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator2 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator2 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x - i, transform.position.y)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Right;
                    }
                }
            }


        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator3) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator3 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator3 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x, transform.position.y);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x, transform.position.y + i)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Back;

                    }
                }
            }


        }

        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator4) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator4 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator4 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x, transform.position.y - i)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.Forward;
                    }
                }
            }

        }

        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator5) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator5 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator5 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.BackLeftCross;
                    }
                }
            }

        }

        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator6) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator6 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator6 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.ForwardRightCross;
                    }
                }
            }

        }

        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator7) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator7 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator7 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.ForwardLeftCross;
                    }
                }
            }

        }

        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator8) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator8 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator8 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType == RockType.King))
                    {
                        var occupiedMark = OccupiedMarkPool.Instance.Get();
                        GameManager.Instance.occupiedRockList.Add(occupiedMark);
                        occupiedMark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                        occupiedMark.gameObject.SetActive(true);

                        var occupiedRock = GameManager.Instance.nodesList.Find
                        (x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i)).GetComponentInChildren<BaseRock>().
                        directionInWhichItIsoccupied = DirectionInWhichItIsoccupied.BackRightCross;
                    }
                }
            }

        }



    }


    public override void OccupiedMove()
    {
        if(directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Forward)
        {
            ForwardMoveControl();
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Back)
        {
            BackMoveControl();
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Right)
        {
            RightMoveControl();
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Left)
        {
            LeftMoveControl();
        }
        
        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.ForwardRightCross)
        {
            ForwardRightCrossMoveControl();
        }
        
        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.ForwardLeftCross)
        {
            ForwardLeftCrossMoveControl();
        }
        
        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.BackRightCross)
        {
            BackRightCrossMoveControl();
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.BackLeftCross)
        {
            BackLeftCrossMoveControl();
        }
    }

    public override void DetermineShahStateMove()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y + i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y - i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y + i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y - i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y - i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y + i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }


    }


    public override void ShahStateMove()
    {
        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                mark.gameObject.SetActive(true);
                
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y + i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y - i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y + i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y - i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y - i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y - i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y - i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i, transform.position.y + i) && x.isOccupied == true)) break;

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y + i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                mark.gameObject.SetActive(true);
                
            }
        }

        
    }


}