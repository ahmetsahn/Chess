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
             newPos = new Vector2(transform.position.x, transform.position.y - i);

            if (IsNodeOccupied(newPos, true))
                break;

            if (IsNodeOccupied(newPos, false))
            {
                GetMark(newPos);
                break;
            }

            if (IsNodeEmpty(newPos))
                GetMark(newPos);
        }
    }

    private void ForwardMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
             newPos = new Vector2(transform.position.x, transform.position.y + i);

            if (IsNodeOccupied(newPos, true))
                break;

            if (IsNodeOccupied(newPos, false))
            {
                GetMark(newPos);
                break;
            }

            if (IsNodeEmpty(newPos))
                GetMark(newPos);
        }
    }

    private void LeftMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
             newPos = new Vector2(transform.position.x - i, transform.position.y);

            if (IsNodeOccupied(newPos, true))
                break;

            if (IsNodeOccupied(newPos, false))
            {
                GetMark(newPos);
                break;
            }

            if (IsNodeEmpty(newPos))
                GetMark(newPos);
        }
    }

    private void RightMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
             newPos = new Vector2(transform.position.x + i, transform.position.y);

            if (IsNodeOccupied(newPos, true))
                break;

            if (IsNodeOccupied(newPos, false))
            {
                GetMark(newPos);
                break;
            }

            if (IsNodeEmpty(newPos))
                GetMark(newPos);
        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        DetermineTheNodeItCanGoToRightControl();
        DetermineTheNodeItCanGoToLeftControl();
        DetermineTheNodeItCanGoToForwardControl();
        DetermineTheNodeItCanGoToBackControl();

    }

    private void DetermineTheNodeItCanGoToBackControl()
    {
        for (int i = 1; i < 8; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - i);

            if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
            {
                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                    break;
                }

                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == false))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                }
            }
        }
    }

    private void DetermineTheNodeItCanGoToForwardControl()
    {
        for (int i = 1; i < 8; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + i);

            if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
            {
                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                    break;
                }

                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == false))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                }
            }
        }
    }

    private void DetermineTheNodeItCanGoToLeftControl()
    {
        for (int i = 1; i < 8; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x - i, transform.position.y);

            if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
            {
                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                    break;
                }

                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == false))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                }
            }
        }
    }

    private void DetermineTheNodeItCanGoToRightControl()
    {
        for (int i = 1; i < 8; i++)
        {
            Vector2 newPos = new Vector2(transform.position.x + i, transform.position.y);

            if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
            {
                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                    break;
                }

                if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == false))
                {
                    AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
                }
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

                        AddOccupiedMarkToList(new Vector2(transform.position.x + i, transform.position.y));

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
                        
                        AddOccupiedMarkToList(new Vector2(transform.position.x - i, transform.position.y));

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
                        
                        AddOccupiedMarkToList(new Vector2(transform.position.x, transform.position.y + i));

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
                        AddOccupiedMarkToList(new Vector2(transform.position.x, transform.position.y - i));

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
        DetermineShahStateRightMove();
        DetermineShahStateLeftMove();
        DetermineShahStateForwardMove();
        DetermineShahStateBackMove();

    }

    private void DetermineShahStateBackMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x, transform.position.y - i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateForwardMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x, transform.position.y + i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateLeftMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateRightMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
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

    }

    private void ShahStateBackMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x, transform.position.y - i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateForwardMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x, transform.position.y + i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateLeftMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateRightMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }
}
