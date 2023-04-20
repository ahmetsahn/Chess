using System.Linq;
using UnityEngine;

public class Rook : BaseRock
{
    private Vector2 startPos;
    public Vector2 StartPos => startPos;

    protected override void Start()
    {
        base.Start();
        startPos = transform.position;
    }

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



        RightMoveControl();
        LeftMoveControl();
        ForwardMoveControl();
        BackMoveControl();

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

    }

    public override void DetermineOccupiedRock()
    {
        bool loopTerminator1 = false;
        bool loopTerminator2 = false;
        bool loopTerminator3 = false;
        bool loopTerminator4 = false;
        

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

    }


    public override void OccupiedMove()
    {
        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Forward)
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

    }

    public override void DetermineShahStateMove()
    {
        for (int i = 1; i < 8; i++)
        {
            


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
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y - i)))
            {
                var fakeMark = FakeMarkPool.Instance.Get();
                fakeMark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                fakeMark.gameObject.SetActive(true);
                GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

            }
        }

    }


    public override void ShahStateMove()
    {
        for (int i = 1; i < 8; i++)
        {
            


            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + i, transform.position.y)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x + i, transform.position.y);
                mark.gameObject.SetActive(true);
                
            }
            
        }

        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - i, transform.position.y)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x - i, transform.position.y);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y + i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y + i);
                mark.gameObject.SetActive(true);
                
            }
        }

        for (int i = 1; i < 8; i++)
        {
            

            if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x, transform.position.y - i)))
            {
                var mark = MarkPool.Instance.Get();
                mark.transform.position = new Vector2(transform.position.x, transform.position.y - i);
                mark.gameObject.SetActive(true);
                
            }
        }
        
    }



}
