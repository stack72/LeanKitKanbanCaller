using System;
using API;
using API.DTO;
using API.IntegrationTests;
using API.Interfaces;
using Newtonsoft.Json;
using NUnit.Framework;

namespace APIIntegrationTests
{
    public class BoardControllerTests
    {
        private IApiCaller _caller;
        private BoardControllerTestData _data;

        [SetUp]
        public void Setup()
        {
            //override it with required data (local or prodcution)
            _data = BoardControllerTestData.GetDataExamples();
            _caller = new ApiCaller(BoardControllerTestData.GetDataExamples());
        }

        [Test]
        public void Example_of_using_api_GetBoardIdentifiers()
        {
            var output = _caller.GetBoardIdentifiers(_data.BoardId.ToString());
            Assert.That(output.Contains("The Board Identifiers were retrieved successfully."));
        }

        [Test]
        public void Example_of_using_api_Backlog()
        {
            var output = _caller.GetListOfItemsInBackLog(_data.BoardId.ToString());
            Assert.That(output.Contains("Backlog successfully retrieved."));
        }

        [Test]
        public void Example_of_using_api_Archive()
        {
            var output = _caller.GetListOfItemsInArchive(_data.BoardId.ToString());
            Assert.That(output.Contains("Archive successfully retrieved."));
        }

        [Test]
        public void Example_of_using_api_GetBoards()
        {
            var output = _caller.GetListOfAllBoardsForAnAccount();
            Assert.That(output.Contains("Board(s) successfully retrieved."));
        }

        [Test]
        public void Example_of_using_api_GetBoardAttributes()
        {
            var output = _caller.GetBoardAttributes(_data.BoardId.ToString());
            Assert.That(output.Contains("Board successfully retrieved."));
        }

        [Test]
        public void Example_of_using_api_AddCard()
        {
            //Adds a Card with the specified values into the specified Lane.
            //prerequisites (records with specified ids must exist in db)

            var dto = new CardItem
            {
                Id = 0,
                Title = "Test Card",
                TypeId = 1,
                Size = 12,
                AssignedUserId = 0,
                IsBlocked = false
            };

            //Example of output (output would be quite long, since it returns all board infrastructure for re-rendering)
            //{"ReplyCode":201,"ReplyText":"The Card was successfully added.","ReplyData":[{"Id":1,"Title":"Realistic Board","Description":"","Version":11,"Active":false,"OrganizationId":1,"Lanes":[{"Id":3,"Active":true,"Title":"Work Queue","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":23,"Cards":[{"Id":1,"LaneId":0,"Title":"aaa","Description":"","ClassType":0,"TypeName":"Feature","Size":0,"Active":false,"Color":"Green","Version":9,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":4,"Active":true,"Title":"Design","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":23,"Cards":[{"Id":4,"LaneId":0,"Title":"Test Card","Description":"","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":1,"AssignedUserId":0,"IsBlocked":false},{"Id":2,"LaneId":0,"Title":"bbb","Description":"","ClassType":2,"TypeName":"Defect","Size":0,"Active":false,"Color":"Red","Version":11,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":5,"Active":true,"Title":"Doing","Description":"","CardLimit":2,"ClassType":0,"Width":1,"Version":23,"Cards":[{"Id":3,"LaneId":0,"Title":"cccc","Description":"<p>asdasd</p>","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":1,"AssignedUserId":0,"IsBlocked":false}],"UserSubscription":0},{"Id":6,"Active":true,"Title":"Code Review","Description":"","CardLimit":4,"ClassType":0,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},{"Id":7,"Active":true,"Title":"QA Test","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},{"Id":8,"Active":true,"Title":"Deploy Queue","Description":"","CardLimit":6,"ClassType":0,"Width":2,"Version":23,"Cards":[],"UserSubscription":0},{"Id":9,"Active":true,"Title":"Done","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":23,"Cards":[],"UserSubscription":0}],"BoardUsers":[{"Id":1,"FullName":"root root","EmailAddress":"chris.hefley@imihealth.com"}],"Backlog":{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},"Archive":{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},"UserSubscription":0}]}

            var output = _caller.AddCard(_data.BoardId.ToString(), _data.LaneId.ToString(), dto);
            Assert.That(output.Contains("The Card was successfully added."));
        }

        [Test]
        public void Example_of_using_api_MoveCard()
        {
            //Moves a Card to the specified Lane in the specified position within that Lane.  
            //prerequisites (records with specified ids must exist in db)

            var output = _caller.MoveCard(_data.BoardId.ToString(), _data.CardId.ToString(), _data.LaneId.ToString());
            Assert.That(output.Contains("The Card was successfully added."));
        }

        [Test]
        public void Example_of_using_api_UpdateCard()
        {
            //Updates the Cards properties with the provided values.
            //prerequisites (records with specified ids must exist in db)

            var dto = new CardItem
            {
                Id = 5,
                Title = "Updated Card Title",
                TypeId = 3
            };

            var output = _caller.UpdateCard(_data.BoardId.ToString(), _data.LaneId.ToString(), dto);
            Assert.That(output.Contains("The Card was successfully updated."));
        }

        //[Test]
        //public void Example_of_using_api_AddCardWithWipOverride()
        //{
        //    //Adds a Card with the specified values into the specified Lane with a WIP Override comment if the destination Lane's WIP is going to be violated
        //    //prerequisites (records with specified ids must exist in db)

        //    var boardId = "101"; //id of the board, where move operation will be proceeded
        //    var laneId = "305"; //id of the lane where will be added     
        //    var position = "0"; //lane's position where card will be inserted
        //    var comment = "Add card comment";

        //    var dto = new CardItem
        //    {
        //        Id = 0,
        //        Title = "Test Card With WIP Override",
        //        TypeId = 2,
        //        Size = 12,
        //        LaneId = 5,
        //        AssignedUserId = 0,
        //        IsBlocked = false,
        //        UserWipOverrideComment = "Need to expedite this card."
        //    };

        //    //Example of output (output would be quite long, since it returns all board infrastructure for re-rendering)
        //    //{"ReplyCode":201,"ReplyText":"The Card was successfully added.","ReplyData":[{"Id":1,"Title":"Realistic Board","Description":"","Version":12,"Active":false,"OrganizationId":1,"Lanes":[{"Id":3,"Active":true,"Title":"Work Queue","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":24,"Cards":[{"Id":1,"LaneId":0,"Title":"aaa","Description":"","ClassType":0,"TypeName":"Feature","Size":0,"Active":false,"Color":"Green","Version":10,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":4,"Active":true,"Title":"Design","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":24,"Cards":[{"Id":4,"LaneId":0,"Title":"Test Card","Description":"","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":1,"AssignedUserId":0,"IsBlocked":false},{"Id":2,"LaneId":0,"Title":"bbb","Description":"","ClassType":2,"TypeName":"Defect","Size":0,"Active":false,"Color":"Red","Version":12,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":5,"Active":true,"Title":"Doing","Description":"","CardLimit":2,"ClassType":0,"Width":1,"Version":24,"Cards":[{"Id":5,"LaneId":0,"Title":"Test Card With WIP Override","Description":"","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":1,"AssignedUserId":0,"IsBlocked":false},{"Id":3,"LaneId":0,"Title":"cccc","Description":"<p>asdasd</p>","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":2,"AssignedUserId":0,"IsBlocked":false}],"UserSubscription":0},{"Id":6,"Active":true,"Title":"Code Review","Description":"","CardLimit":4,"ClassType":0,"Width":1,"Version":24,"Cards":[],"UserSubscription":0},{"Id":7,"Active":true,"Title":"QA Test","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":24,"Cards":[],"UserSubscription":0},{"Id":8,"Active":true,"Title":"Deploy Queue","Description":"","CardLimit":6,"ClassType":0,"Width":2,"Version":24,"Cards":[],"UserSubscription":0},{"Id":9,"Active":true,"Title":"Done","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":24,"Cards":[],"UserSubscription":0}],"BoardUsers":[{"Id":1,"FullName":"root root","EmailAddress":"chris.hefley@imihealth.com"}],"Backlog":{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":24,"Cards":[],"UserSubscription":0},"Archive":{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":24,"Cards":[],"UserSubscription":0},"UserSubscription":0}]}

        //    var output = _caller.Requester(string.Format("/Kanban/Api/Board/{0}/AddCardWithWipOverride/Lane/{1}/Position/{2}/Comment/{3}", boardId, laneId, position, comment), "POST", JsonConvert.SerializeObject(dto));
        //    Assert.That(output.Contains("The Card was successfully added."));
        //}

        //[Test]
        //public void Example_of_using_api_GetCardByExternalId()
        //{
        //    //Returns a listing of the Card attributes within the Board and restricted by External Card Id without a prefix (Prefix option in Card Id administration might be disabled or enabled)
        //    //Example of output
        //    //"{"ReplyCode":200,"ReplyText":"Card successfully retrieved.","ReplyData":[{"Id":13550969,"LaneId":13548652,"Title":"allow set global jurisdiction","Description":"","CreatedOn":"","TypeName":"Task","TypeId":13548847,"Priority":1,"Size":0,"Active":false,"Color":null,"Version":11,"AssignedUserId":0,"AssignedUserFullName":"","IsBlocked":false,"BlockReason":"","GravatarLink":"","SmallGravatarLink":"","Index":0,"Statistics":null,"DueDate":"","UserWipOverrideComment":null,"ExternalSystemName":"","ExternalSystemUrl":"","ClassOfServiceId":null,"ExternalCardID":"DEFF111"}]}"

        //    var output = _caller.Requester(string.Format("/Kanban/Api/Board/{0}/GetCardByExternalId/{1}", _data.BoardId, "778"), "GET");
        //    Assert.That(output.Contains("Card successfully retrieved."));
        //}

        //[Test]
        //public void Example_of_using_api_GetCardByExternalIdWithPrefix()
        //{
        //    //Returns a listing of the Card attributes within the Board and restricted by External Card Id with an prefix (Prefix option in CardId administration should be enabled)
        //    //Example of output
        //    //"{"ReplyCode":200,"ReplyText":"Card successfully retrieved.","ReplyData":[{"Id":13550969,"LaneId":13548652,"Title":"allow set global jurisdiction","Description":"","CreatedOn":"","TypeName":"Task","TypeId":13548847,"Priority":1,"Size":0,"Active":false,"Color":null,"Version":11,"AssignedUserId":0,"AssignedUserFullName":"","IsBlocked":false,"BlockReason":"","GravatarLink":"","SmallGravatarLink":"","Index":0,"Statistics":null,"DueDate":"","UserWipOverrideComment":null,"ExternalSystemName":"","ExternalSystemUrl":"","ClassOfServiceId":null,"ExternalCardID":"DEFF111"}]}"

        //    var output = _caller.Requester(string.Format("/Kanban/Api/Board/{0}/GetCardByExternalId/{1}", _data.BoardId, "BB778"), "GET");
        //    Assert.That(output.Contains("Card successfully retrieved."));
        //}

        //[Test]
        //public void Example_of_using_api_MoveCardWithWipOverride()
        //{
        //    //Moves a Card to the specified Lane in the specified position within that Lane but also specifies an override comment if the WIP is going to be violated.
        //    //prerequisites (records with specified ids must exist in db)
         
        //    var boardId = _data.BoardId; //id of the board, where move operation will be proceeded
        //    var cardId = _data.CardId; //id of the card to move
        //    var laneId = _data.LaneId; //id of the destination lane      
        //    var position = _data.Position; //lane's position where card will be inserted
        //    var comment = _data.OverrideComment; //wip comment
        //    var dto = new CommentItem { Comment = comment };

        //    //Example of output
        //    //{"ReplyCode":202,"ReplyText":"The Card was moved successfully.","ReplyData":[9]}

        //    var output = _caller.Requester(string.Format("/Kanban/Api/Board/{0}/MoveCardWithWipOverride/{1}/Lane/{2}/Position/{3}", boardId, cardId, laneId, position), "POST", JsonConvert.SerializeObject(dto));
        //    Assert.That(output.Contains("The Card was moved successfully."));
        //}
    }
}
