using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IApiCaller
    {
        Wrapper GetBoardIdentifiers(string boardId);
        //string GetBoardAttributes(string boardId);
        //string GetListOfItemsInBackLog(string boardId);
        //string GetListOfItemsInArchive(string boardId);
        //string GetListOfAllBoardsForAnAccount();
        //string AddCard(string boardId, string laneId, CardItem card);
        //string MoveCard(string boardId, string cardId, string laneId);
        //string UpdateCard(string boardId, string laneId, CardItem card);
    }
}
