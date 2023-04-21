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
        var pos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                    || x.pos == pos && x.isOccupied == false))
        {

            GetMark(pos);
        }
    }

    private void RightBackMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                    || x.pos == pos && x.isOccupied == false))
        {
            GetMark(pos);
        }
    }

    private void BackLeftMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x - 1, transform.position.y - 2);
        
        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                    || x.pos == pos && x.isOccupied == false))
        {


            GetMark(pos);



        }
    }

    private void BackRightMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y - 2);
        
        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == pos && x.isOccupied == false))
        {


            GetMark(pos);



        }
    }

    private void LeftForwardMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == pos && x.isOccupied == false))
        {

            GetMark(pos);


        }
    }

    private void RightForwardMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == pos && x.isOccupied == false))
        {


            GetMark(pos);



        }
    }

    private void ForwardLeftMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x - 1, transform.position.y + 2);
        
        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                || x.pos == pos && x.isOccupied == false))
        {

            GetMark(pos);


        }
    }

    private void ForwardRightMoveControlForOccupied()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos && x.isOccupied == true
                        && x.GetComponentInChildren<BaseRock>().rockColor != rockColor
                        || x.pos == pos && x.isOccupied == false))
        {

            GetMark(pos);
        }
    }

   

    public override void DetermineAllTheNodesItCanGoTo()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos,GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y + 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x + 1, transform.position.y - 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y - 2);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }

        pos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesList.Any(x => x.pos == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
        }
    }

    public override void DetermineShahStateMove()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x + 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }

        pos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);
        }



    }


    public override void ShahStateMove()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y + 2);
        
        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y + 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y + 2)))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x + 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y + 1)))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x - 2, transform.position.y + 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y + 1)))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x + 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 1, transform.position.y - 2)))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x - 1, transform.position.y - 2);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y - 2)))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x + 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y - 1)))
        {
            GetMark(pos);
        }

        pos = new Vector2(transform.position.x - 2, transform.position.y - 1);

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y - 1)))
        {
            GetMark(pos);
        }

        

    }
    
    
}
