using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Bishoop : BaseRock
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

        ForwardRightCrossMoveControl();
        ForwardLeftCrossMoveControl();
        BackRightCrossMoveControl();
        BackLeftCrossMoveControl();
    }

    private void BackLeftCrossMoveControl()
    {


        for (int i = 1; i < 8; i++)
        {
            var pos = new Vector2(transform.position.x - i, transform.position.y - i);

            if (IsNodeOccupied(pos, true))
                break;

            if (IsNodeOccupied(pos, false))
            {
                GetMarkNode(pos);
                break;
            }

            if (IsNodeEmpty(pos))
                GetMarkNode(pos);
        }
    }

    private void BackRightCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            var pos = new Vector2(transform.position.x + i, transform.position.y - i);

            if (IsNodeOccupied(pos, true))
                break;

            if (IsNodeOccupied(pos, false))
            {
                GetMarkNode(pos);
                break;
            }

            if (IsNodeEmpty(pos))
                GetMarkNode(pos);
        }
    }

    private void ForwardLeftCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            var pos = new Vector2(transform.position.x - i, transform.position.y + i);

            if (IsNodeOccupied(pos, true))
                break;

            if (IsNodeOccupied(pos, false))
            {
                GetMarkNode(pos);
                break;
            }

            if (IsNodeEmpty(pos))
                GetMarkNode(pos);
        }
    }

    private void ForwardRightCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            var pos = new Vector2(transform.position.x + i, transform.position.y + i);

            if (IsNodeOccupied(pos, true))
                break;

            if (IsNodeOccupied(pos, false))
            {
                GetMarkNode(pos);
                break;
            }

            if (IsNodeEmpty(pos))
                GetMarkNode(pos);
        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
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

    }

    public override void DetermineOccupiedRock()
    {

        bool loopTerminator1 = false;
        bool loopTerminator2 = false;
        bool loopTerminator3 = false;
        bool loopTerminator4 = false;


        for (int i = 1; i < 8; i++)
        {

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true
            && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) break;

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i, transform.position.y + i) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
            {
                for (int j = 1; j < 6; j++)
                {
                    if (loopTerminator1) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator1 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator1 = true; break; }

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
                    if (loopTerminator2) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator2 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator2 = true; break; }

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
                    if (loopTerminator3) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator3 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + i + j, transform.position.y - i - j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator3 = true; break; }

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
                    if (loopTerminator4) break;

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor == rockColor)) { loopTerminator4 = true; break; }

                    if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - i - j, transform.position.y + i + j) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor && x.GetComponentInChildren<BaseRock>().rockType != RockType.King)) { loopTerminator4 = true; break; }

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
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y + i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
            }

        }


        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y - i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
            }

        }


        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y - i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
            }

        }


        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y + i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                fakeMark.gameObject.SetActive(true);
            }

        }

    }

    public override void ShahStateMove()
    {
        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y + i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y + i);
                mark.gameObject.SetActive(true);
            }

        }


        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y + i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y + i);
                mark.gameObject.SetActive(true);
            }

        }


        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y - i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y - i);
                mark.gameObject.SetActive(true);
            }

        }


        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y - i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y - i);
                mark.gameObject.SetActive(true);
            }

        }

    }



}
