using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Bishoop : BaseRock
{
    public override void ShowNodesItCanGo()
    {
        ControlOccupiedStone();
        ControlShahState();
        

        ForwardRightCrossMoveControl();
        ForwardLeftCrossMoveControl();
        BackRightCrossMoveControl();
        BackLeftCrossMoveControl();
    }

    private void ControlOccupiedStone()
    {
        if (GameManager.Instance.occupiedRockList.Any(x => x.transform.position == transform.position))
        {
            OccupiedMove();
            return;
        }
    }

    private void ControlShahState()
    {
        if (GameManager.Instance.isWhiteKingShahed || GameManager.Instance.isBlackKingShahed)
        {
            ShahStateMove();
            return;
        }
    }

    private void BackLeftCrossMoveControl()
    {


        for (int i = 1; i < 8; i++)
        {
            var newPos = new Vector2(transform.position.x - i, transform.position.y - i);

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

    private void BackRightCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            var newPos = new Vector2(transform.position.x + i, transform.position.y - i);

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

    private void ForwardLeftCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            var newPos = new Vector2(transform.position.x - i, transform.position.y + i);

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

    private void ForwardRightCrossMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            var newPos = new Vector2(transform.position.x + i, transform.position.y + i);

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
        DetermineAllTheNodesItCanGoForForwardRightMove();
        DetermineAllTheNodesItCanGoForForwardLeftMove();
        DetermineAllTheNodesItCanGoForBackRightMove();
        DetermineAllTheNodesItCanGoForBackLeftMove();

    }

    private void DetermineAllTheNodesItCanGoForBackLeftMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y - i);

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

    private void DetermineAllTheNodesItCanGoForBackRightMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y - i);

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

    private void DetermineAllTheNodesItCanGoForForwardLeftMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y + i);

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

    private void DetermineAllTheNodesItCanGoForForwardRightMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y + i);

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
                        AddOccupiedMarkToList(new Vector2(transform.position.x + i, transform.position.y + i));

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
                        
                        AddOccupiedMarkToList(new Vector2(transform.position.x - i, transform.position.y - i));

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
                        
                        AddOccupiedMarkToList(new Vector2(transform.position.x + i, transform.position.y - i));

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
                        AddOccupiedMarkToList(new Vector2(transform.position.x - i, transform.position.y + i));

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
        DetermineShahStateForwardRightMove();
        DetermineShahStateForwardLeftMove();
        DetermineShahStateBackRightMove();
        DetermineShahStateBackLeftMove();

    }

    private void DetermineShahStateBackLeftMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y - i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateBackRightMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y - i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateForwardLeftMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y + i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    private void DetermineShahStateForwardRightMove()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y + i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
            }

        }
    }

    public override void ShahStateMove()
    {
        ShahStateForwardRightMoveControl();
        ShahStateForwardLeftMoveControl();
        ShahStateBackRightMoveControl();
        ShahStateBackLeftMoveControl();
    }

    private void ShahStateBackLeftMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y - i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateBackRightMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y - i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateForwardLeftMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x - i, transform.position.y + i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }

    private void ShahStateForwardRightMoveControl()
    {
        for (int i = 1; i < 8; i++)
        {
            newPos = new Vector2(transform.position.x + i, transform.position.y + i);

            if (IsNodeOccupied(newPos, true)) break;

            if (IsTheNodeInTheNodeList(newPos))
            {
                GetMark(newPos);
            }

        }
    }
}
