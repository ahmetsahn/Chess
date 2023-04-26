using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class Knight : BaseRock
{
    public override void ShowNodesItCanGo()
    {
        if (GameManager.Instance.isWhiteKingShahed || GameManager.Instance.isBlackKingShahed)
        {
            ShahStateMove();
            return;
        }

        if (GameManager.Instance.occupiedRockList.Any(x => x.transform.position == transform.position)) return;

     
        ForwardRightMoveControlForOccupied();
        ForwardLeftMoveControlForOccupied();
        RightForwardMoveControlForOccupied();
        LeftForwardMoveControlForOccupied();
        BackRightMoveControlForOccupied();
        BackLeftMoveControlForOccupied();
        RightBackMoveControlForOccupied();
        LeftBackMoveControlForOccupied();

    }

    private void LeftBackMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                    || x.pos == newPos && x.isOccupied == false))
        {

            GetMark(newPos);
        }
    }

    private void RightBackMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                    || x.pos == newPos && x.isOccupied == false))
        {
            GetMark(newPos);
        }
    }

    private void BackLeftMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 2);
        
        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                    || x.pos == newPos && x.isOccupied == false))
        {


            GetMark(newPos);



        }
    }

    private void BackRightMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 2);
        
        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == newPos && x.isOccupied == false))
        {


            GetMark(newPos);



        }
    }

    private void LeftForwardMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == newPos && x.isOccupied == false))
        {

            GetMark(newPos);


        }
    }

    private void RightForwardMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == newPos && x.isOccupied == false))
        {


            GetMark(newPos);



        }
    }

    private void ForwardLeftMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 2);
        
        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == newPos && x.isOccupied == false))
        {

            GetMark(newPos);


        }
    }

    private void ForwardRightMoveControlForOccupied()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos && x.isOccupied == true
                        && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                        || x.pos == newPos && x.isOccupied == false))
        {

            GetMark(newPos);
        }
    }

   

    public override void DetermineAllTheNodesItCanGoTo()
    {
        DetermineForwardRigthMoveControl();
        DetermineForwardLeftMoveControl();
        DetermineRightForwardMoveControl();
        DetermineLeftForwardMoveControl();
        DetermineBackRightMoveControl();
        DetermineBackLeftMoveControl();
        DetermineRightBackMoveControl();
        DetermineLeftBackMoveControl();
    }

    private void DetermineLeftBackMoveControl()
    {
        newPos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineRightBackMoveControl()
    {
        newPos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineBackLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineBackRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineLeftForwardMoveControl()
    {
        newPos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineRightForwardMoveControl()
    {
        newPos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineForwardLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    private void DetermineForwardRigthMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    public override void DetermineShahStateMove()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x - 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x + 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x - 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        newPos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }



    }


    public override void ShahStateMove()
    {
        ShahStateForwardRightMoveControl();
        ShahStateForwardLeftMoveControl();
        ShahStateRightForwardMoveControl();
        ShahStateLeftForwardMoveControl();
        ShahStateBackRightMoveControl();
        ShahStateBackLeftMoveControl();
        ShahStateRightBackMoveControl();
        ShahStateLeftBackMoveControl();
    }

    private void ShahStateLeftBackMoveControl()
    {
        newPos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y - 1)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateRightBackMoveControl()
    {
        newPos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y - 1)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateBackLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y - 2)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateBackRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 1, transform.position.y - 2)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateLeftForwardMoveControl()
    {
        newPos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y + 1)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateRightForwardMoveControl()
    {
        newPos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y + 1)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateForwardLeftMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y + 2)))
        {
            GetMark(newPos);
        }
    }

    private void ShahStateForwardRightMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos))
        {
            GetMark(newPos);
        }
    }

}
