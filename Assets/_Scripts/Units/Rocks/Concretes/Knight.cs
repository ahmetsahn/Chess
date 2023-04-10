using System.Linq;
using UnityEngine;


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

        ForwardRightMoveControl();
        ForwardLeftMoveControl();
        RightForwardMoveControl();
        LeftForwardMoveControl();
        BackRightMoveControl();
        BackLeftMoveControl();
        RightBackMoveControl();
        LeftBackMoveControl();
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
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y - 1) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 2, transform.position.y - 1);
            mark.gameObject.SetActive(true);



        }
    }

    private void RightBackMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y - 1) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {



            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 2, transform.position.y - 1);
            mark.gameObject.SetActive(true);



        }
    }

    private void BackLeftMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 2) && x.isOccupied == true
                    && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 2);
            mark.gameObject.SetActive(true);



        }
    }

    private void BackRightMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 2) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 2);
            mark.gameObject.SetActive(true);



        }
    }

    private void LeftForwardMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y + 1) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 2, transform.position.y + 1);
            mark.gameObject.SetActive(true);


        }
    }

    private void RightForwardMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y + 1) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 1);
            mark.gameObject.SetActive(true);



        }
    }

    private void ForwardLeftMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 2) && x.isOccupied == true
                && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 2);
            mark.gameObject.SetActive(true);



        }
    }

    private void ForwardRightMoveControlForOccupied()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 2) && x.isOccupied == true
                        && x.GetComponentInChildren<BaseRock>().rockColor != rockColor))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 2);
            mark.gameObject.SetActive(true);

        }
    }

    private void LeftBackMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y - 1) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 2, transform.position.y - 1);
            mark.gameObject.SetActive(true);


        }
    }

    private void RightBackMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y - 1) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 2, transform.position.y - 1);
            mark.gameObject.SetActive(true);



        }
    }

    private void BackLeftMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 2) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 2);
            mark.gameObject.SetActive(true);



        }
    }

    private void BackRightMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 2) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 2);
            mark.gameObject.SetActive(true);



        }
    }

    private void LeftForwardMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y + 1) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 2, transform.position.y + 1);
            mark.gameObject.SetActive(true);



        }
    }

    private void RightForwardMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y + 1) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 1);
            mark.gameObject.SetActive(true);



        }
    }

    private void ForwardLeftMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 2) && x.isOccupied == false))
        {


            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 2);
            mark.gameObject.SetActive(true);



        }
    }

    private void ForwardRightMoveControl()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 2) && x.isOccupied == false))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 2);
            mark.gameObject.SetActive(true);


        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 2)))
        {

          
            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 2);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 2)))
        {



            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 2);
            fakeMark.gameObject.SetActive(true);


        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y + 1)))
        {



            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y + 1)))
        {



            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 2, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 2)))
        {


            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 2);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 2)))
        {


            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 2);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 2, transform.position.y - 1)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x + 2, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);

        }

        if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 2, transform.position.y - 1)))
        {



            var fakeMark = FakeMarkPool.Instance.Get();
            GameManager.Instance.allTheNodesListTheOpponentCanGoTo.Add(fakeMark);
            fakeMark.transform.position = new Vector2(transform.position.x - 2, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);

        }
    }

    public override void DetermineShahStateMove()
    {
        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 1, transform.position.y + 2)))
        {
            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 2);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y + 2)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 2);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);


        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y + 1)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y + 1)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x - 2, transform.position.y + 1);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);



        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 1, transform.position.y - 2)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 2);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);



        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y - 2)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 2);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);

        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y - 1)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x + 2, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);


        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y - 1)))
        {

            var fakeMark = FakeMarkPool.Instance.Get();
            fakeMark.transform.position = new Vector2(transform.position.x - 2, transform.position.y - 1);
            fakeMark.gameObject.SetActive(true);
            GameManager.Instance.nodesListTheCanGoToShahedState.Add(fakeMark);


        }



    }


    public override void ShahStateMove()
    {
       

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 1, transform.position.y + 2)))
        {
            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y + 2);
            mark.gameObject.SetActive(true);
            

        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y + 2)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y + 2);
            mark.gameObject.SetActive(true);
            

        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y + 1)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 1);
            mark.gameObject.SetActive(true);
            
        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y + 1)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 2, transform.position.y + 1);
            mark.gameObject.SetActive(true);
            


        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 1, transform.position.y - 2)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 1, transform.position.y - 2);
            mark.gameObject.SetActive(true);
            

        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 1, transform.position.y - 2)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 1, transform.position.y - 2);
            mark.gameObject.SetActive(true);
            
        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x + 2, transform.position.y - 1)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x + 2, transform.position.y - 1);
            mark.gameObject.SetActive(true);
            
        }

        if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == new Vector2(transform.position.x - 2, transform.position.y - 1)))
        {

            var mark = MarkPool.Instance.Get();
            mark.transform.position = new Vector2(transform.position.x - 2, transform.position.y - 1);
            mark.gameObject.SetActive(true);
            
        }

        

    }
    
    
}
