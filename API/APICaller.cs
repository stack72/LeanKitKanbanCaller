using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using API.DTO;
using API.Interfaces;
using Newtonsoft.Json;

namespace API
{
    public class ApiCaller: IApiCaller
    {
        private IBoardControllerData _data;

        public ApiCaller(IBoardControllerData data)
        {
            _data = data;
        }

        /// <summary>
        /// This method takes a board Id and returns all of the information about that board
        /// this includes card types, users associated with the board and lane names
        /// </summary>
        /// <param name="boardId">string BoardId</param>
        /// <returns>string of JSON data</returns>
        public string GetBoardIdentifiers(string boardId)
        {
            //This method is used to get all the necessary Identifiers for a Board used within the other API calls.
            //This method takes the Id of the Board which can be derived from the URL when viewing the Board or by calling using the GetBoards method
            //Ex. - http://test.leankitkanban.com/Boards/Show/12345 - BoardId = 12345
            //Example of output
            //{"ReplyCode":200,"ReplyText":"The Board Identifiers were retrieved successfully.","ReplyData":[{"BoardId":101,"CardTypes":[{"Id":1,"Name":"Defect"},{"Id":2,"Name":"Improvement"},{"Id":3,"Name":"Feature"},{"Id":4,"Name":"Task"}],"BoardUsers":[{"Id":101,"Name":"testuser@test.com"},{"Id":102,"Name":"testmanager@test.com"},{"Id":103,"Name":"testreadonly@test.com"},{"Id":1,"Name":"info@bandit-software.com"}],"Lanes":[{"Id":303,"Name":"Backlog"},{"Id":304,"Name":"Archive"},{"Id":305,"Name":"Lane 1"},{"Id":306,"Name":"Lane 2"},{"Id":307,"Name":"Lane 3"}],"ClassesOfService":[{"Id":104,"Name":"Date Dependent"},{"Id":102,"Name":"Expedite"},{"Id":103,"Name":"Regulatory"},{"Id":101,"Name":"Standard"}]}]}

            var response = Requester(string.Format("/Kanban/Api/Board/{0}/GetBoardIdentifiers", boardId), "GET");

            return response;
        }

        /// <summary>
        /// This method takes a board Id and returns all of its attributes
        /// </summary>
        /// <param name="boardId"></param>
        /// <returns></returns>
        public string GetBoardAttributes(string boardId)
        {
            //Returns a listing of the Board attributes, the Lanes within the Board and all the Cards within those lanes.  Does not include the Cards within the Archive. 
            //Example of output
            //{"ReplyCode":200,"ReplyText":"Board successfully retrieved.","ReplyData":[{"Id":1,"Title":"Realistic Board","Description":"","Version":8,"Active":false,"OrganizationId":1,"Lanes":[{"Id":3,"Active":true,"Title":"Work Queue","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":20,"Cards":[{"Id":1,"LaneId":0,"Title":"aaa","Description":"","ClassType":0,"TypeName":"Feature","Size":0,"Active":false,"Color":"Green","Version":8,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":4,"Active":true,"Title":"Design","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":20,"Cards":[{"Id":2,"LaneId":0,"Title":"bbb","Description":"","ClassType":2,"TypeName":"Defect","Size":0,"Active":false,"Color":"Red","Version":9,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":5,"Active":true,"Title":"Doing","Description":"","CardLimit":2,"ClassType":0,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},{"Id":6,"Active":true,"Title":"Code Review","Description":"","CardLimit":4,"ClassType":0,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},{"Id":7,"Active":true,"Title":"QA Test","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},{"Id":8,"Active":true,"Title":"Deploy Queue","Description":"","CardLimit":6,"ClassType":0,"Width":2,"Version":20,"Cards":[],"UserSubscription":0},{"Id":9,"Active":true,"Title":"Done","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":20,"Cards":[],"UserSubscription":0}],"BoardUsers":[{"Id":1,"FullName":"root root","EmailAddress":"chris.hefley@imihealth.com"}],"Backlog":{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},"Archive":{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},"UserSubscription":0}]}

            var response = Requester(string.Format("/Kanban/Api/Boards/{0}", boardId), "GET");

            return response;
        }

        /// <summary>
        /// Gets a List of all the Items currently in the backlog
        /// </summary>
        /// <param name="boardId">string BoardId</param>
        /// <returns>string of JSON data</returns>
        public string GetListOfItemsInBackLog(string boardId)
        {
            //Gets a listing of all the Cards contained in the Backlog
            //This method takes the Id of the Board which can be derived from the URL when viewing the Board or by calling using the GetBoards method
            //Ex. - http://test.leankitkanban.com/Boards/Show/12345 - BoardId = 12345
            //Example of output
            //{"ReplyCode":200,"ReplyText":"Backlog successfully retrieved.","ReplyData":[{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":18,"Cards":[],"UserSubscription":0}]}

            var response = Requester(string.Format("/Kanban/Api/Board/{0}/Backlog", boardId), "GET");

            return response;
        }

        /// <summary>
        /// Gets a List of all the Items currently in the Archive
        /// </summary>
        /// <param name="boardId">string boardId</param>
        /// <returns>string of JSON data</returns>
        public string GetListOfItemsInArchive(string boardId)
        {
            //Gets a listing of all the Cards contained in the Archive
            //This method takes the Id of the Board which can be derived from the URL when viewing the Board or by calling using the GetBoards method
            //Ex. - http://test.leankitkanban.com/Boards/Show/12345 - BoardId = 12345
            //Example of output
            //{"ReplyCode":200,"ReplyText":"Archive successfully retrieved.","ReplyData":[{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":19,"Cards":[],"UserSubscription":0}]}

            var response = Requester(string.Format("/Kanban/Api/Board/{0}/Archive", boardId), "GET");

            return response;
        }

        /// <summary>
        /// Gets all the Boards for a Specified Account - if a user has access to any boards. Admin returns ALL boards
        /// </summary>
        /// <returns>string of JSON data</returns>
        public string GetListOfAllBoardsForAnAccount()
        {
            //Lists all the Boards for the Organization
            //Example of output
            //{"ReplyCode":200,"ReplyText":"Board(s) successfully retrieved.","ReplyData":[[{"Id":1,"Title":"Realistic Board","Description":"","Version":8,"Active":false,"OrganizationId":1,"Lanes":[{"Id":3,"Active":true,"Title":"Work Queue","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":20,"Cards":[{"Id":1,"LaneId":0,"Title":"aaa","Description":"","ClassType":0,"TypeName":"Feature","Size":0,"Active":false,"Color":"Green","Version":8,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":4,"Active":true,"Title":"Design","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":20,"Cards":[{"Id":2,"LaneId":0,"Title":"bbb","Description":"","ClassType":2,"TypeName":"Defect","Size":0,"Active":false,"Color":"Red","Version":9,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":5,"Active":true,"Title":"Doing","Description":"","CardLimit":2,"ClassType":0,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},{"Id":6,"Active":true,"Title":"Code Review","Description":"","CardLimit":4,"ClassType":0,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},{"Id":7,"Active":true,"Title":"QA Test","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},{"Id":8,"Active":true,"Title":"Deploy Queue","Description":"","CardLimit":6,"ClassType":0,"Width":2,"Version":20,"Cards":[],"UserSubscription":0},{"Id":9,"Active":true,"Title":"Done","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":20,"Cards":[],"UserSubscription":0}],"BoardUsers":[{"Id":1,"FullName":"root root","EmailAddress":"chris.hefley@imihealth.com"}],"Backlog":{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},"Archive":{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":20,"Cards":[],"UserSubscription":0},"UserSubscription":0}]]}

            var response = Requester(string.Format("/Kanban/Api/Boards"), "GET");

            return response;
        }

        /// <summary>
        /// Adds a New Ticket for given data
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="laneId"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public string AddCard(string boardId, string laneId, CardItem card)
        {
            //Example of output (output would be quite long, since it returns all board infrastructure for re-rendering)
            //{"ReplyCode":201,"ReplyText":"The Card was successfully added.","ReplyData":[{"Id":1,"Title":"Realistic Board","Description":"","Version":11,"Active":false,"OrganizationId":1,"Lanes":[{"Id":3,"Active":true,"Title":"Work Queue","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":23,"Cards":[{"Id":1,"LaneId":0,"Title":"aaa","Description":"","ClassType":0,"TypeName":"Feature","Size":0,"Active":false,"Color":"Green","Version":9,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":4,"Active":true,"Title":"Design","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":23,"Cards":[{"Id":4,"LaneId":0,"Title":"Test Card","Description":"","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":1,"AssignedUserId":0,"IsBlocked":false},{"Id":2,"LaneId":0,"Title":"bbb","Description":"","ClassType":2,"TypeName":"Defect","Size":0,"Active":false,"Color":"Red","Version":11,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":5,"Active":true,"Title":"Doing","Description":"","CardLimit":2,"ClassType":0,"Width":1,"Version":23,"Cards":[{"Id":3,"LaneId":0,"Title":"cccc","Description":"<p>asdasd</p>","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":1,"AssignedUserId":0,"IsBlocked":false}],"UserSubscription":0},{"Id":6,"Active":true,"Title":"Code Review","Description":"","CardLimit":4,"ClassType":0,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},{"Id":7,"Active":true,"Title":"QA Test","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},{"Id":8,"Active":true,"Title":"Deploy Queue","Description":"","CardLimit":6,"ClassType":0,"Width":2,"Version":23,"Cards":[],"UserSubscription":0},{"Id":9,"Active":true,"Title":"Done","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":23,"Cards":[],"UserSubscription":0}],"BoardUsers":[{"Id":1,"FullName":"root root","EmailAddress":"chris.hefley@imihealth.com"}],"Backlog":{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},"Archive":{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":23,"Cards":[],"UserSubscription":0},"UserSubscription":0}]}

            var response = Requester(string.Format("/Kanban/Api/Board/{0}/AddCard/Lane/{1}/Position/0", boardId, laneId), "POST", JsonConvert.SerializeObject(card));

            return response;
        }

        /// <summary>
        /// Moves a given card to a new lane
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="cardId"></param>
        /// <param name="laneId"></param>
        /// <returns></returns>
        public string MoveCard(string boardId, string cardId, string laneId)
        {
            //Example of output
            //{"ReplyCode":202,"ReplyText":"The Card was moved successfully.","ReplyData":[11]} 
            //ReplyData is a new board version

            var response =
                Requester(
                    string.Format("/Kanban/Api/Board/{0}/MoveCard/{1}/Lane/{2}/Position/0", boardId, cardId, laneId),
                    "POST");
            
            return response;
        }

        /// <summary>
        /// Updates a specified card
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="laneId"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public string UpdateCard(string boardId, string laneId, CardItem card)
        {
            //Example of output (output would be quite long, since it returns all board infrastructure for re-rendering)
            //{"ReplyCode":202,"ReplyText":"The Card was successfully updated.","ReplyData":[{"Id":1,"Title":"RealisticBoard","Description":"","Version":16,"Active":false,"OrganizationId":1,"Lanes":[{"Id":3,"Active":true,"Title":"Work Queue","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":27,"Cards":[{"Id":1,"LaneId":0,"Title":"aaa","Description":"","ClassType":0,"TypeName":"Feature","Size":0,"Active":false,"Color":"Green","Version":15,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":4,"Active":true,"Title":"Design","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":27,"Cards":[{"Id":4,"LaneId":0,"Title":"Test Card","Description":"","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":5,"AssignedUserId":0,"IsBlocked":false},{"Id":2,"LaneId":0,"Title":"bbb","Description":"","ClassType":2,"TypeName":"Defect","Size":0,"Active":false,"Color":"Red","Version":16,"AssignedUserId":1,"IsBlocked":false}],"UserSubscription":0},{"Id":5,"Active":true,"Title":"Doing","Description":"","CardLimit":2,"ClassType":0,"Width":1,"Version":27,"Cards":[{"Id":5,"LaneId":0,"Title":"Test Card With WIP Override","Description":"","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":4,"AssignedUserId":0,"IsBlocked":false},{"Id":3,"LaneId":0,"Title":"cccc","Description":"<p>asdasd</p>","ClassType":0,"TypeName":"Feature","Size":12,"Active":false,"Color":"Green","Version":6,"AssignedUserId":0,"IsBlocked":false}],"UserSubscription":0},{"Id":6,"Active":true,"Title":"Code Review","Description":"","CardLimit":4,"ClassType":0,"Width":1,"Version":27,"Cards":[],"UserSubscription":0},{"Id":7,"Active":true,"Title":"QA Test","Description":"","CardLimit":3,"ClassType":0,"Width":1,"Version":27,"Cards":[],"UserSubscription":0},{"Id":8,"Active":true,"Title":"Deploy Queue","Description":"","CardLimit":6,"ClassType":0,"Width":2,"Version":27,"Cards":[],"UserSubscription":0},{"Id":9,"Active":true,"Title":"Done","Description":"","CardLimit":15,"ClassType":0,"Width":3,"Version":27,"Cards":[],"UserSubscription":0}],"BoardUsers":[{"Id":1,"FullName":"root root","EmailAddress":"chris.hefley@imihealth.com"}],"Backlog":{"Id":1,"Active":false,"Title":"Backlog","Description":"","CardLimit":0,"ClassType":1,"Width":1,"Version":27,"Cards":[],"UserSubscription":0},"Archive":{"Id":2,"Active":false,"Title":"Archive","Description":"","CardLimit":0,"ClassType":2,"Width":1,"Version":27,"Cards":[],"UserSubscription":0},"UserSubscription":0}]}

            var response = Requester(string.Format("/Kanban/Api/Board/{0}/AddCard/Lane/{1}/Position/0", boardId, laneId), "POST", JsonConvert.SerializeObject(card));

            return response;
        }


        private string Requester(string address, string method)
        {
            return Requester(address, method, string.Empty);
        }

        private string Requester(string address, string method, string body)
        {
            var request = (HttpWebRequest)WebRequest.Create(_data.Address + address);
            request.Method = method;
            request.Credentials = new NetworkCredential(_data.Username, _data.Password);
            request.PreAuthenticate = true;

            if (method == "POST")
            {
                if (!string.IsNullOrEmpty(body))
                {
                    var requestBody = Encoding.UTF8.GetBytes(body);
                    request.ContentLength = requestBody.Length;
                    request.ContentType = "application/json";
                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestBody, 0, requestBody.Length);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }
            }

            request.Timeout = 15000;
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);

            string output = string.Empty;
            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                    {
                        output = stream.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        output = stream.ReadToEnd();
                    }
                }
                else if (ex.Status == WebExceptionStatus.Timeout)
                {
                    output = "Request timeout is expired.";
                }
            }

            Console.WriteLine(output);
            return output;
        }
    }
}
