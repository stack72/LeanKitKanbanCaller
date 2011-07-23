namespace API.DTO
{
    public class CardItem
    {
        //Fields for CardDTO 

        //(Name       /    datatype  /  Required / Notes

        //Id                Int64       True   (Card identifiers can be determined from the Board's Get method)

        //Title             string      True   (255 character limit)

        //Description       string      False  (3000 characters limit)

        //TypeId            Int64       True   (The ID values can be obtained using the GetBoardIdentifiers method)

        //Priority          Int32       False  (Defaults to Normal)  0 - Low, 1 - Normal, 2 - High, 3 - Critical

        //Size              Int32       False

        //AssignedUserId    Int64       False  (The ID values for the Board Users can be obtained using the GetBoardIdentifiers method)

        //IsBlocked         bool        False  (Defaults to False)

        //BlockReason       string      False  (Required if IsBlocked is True)(255 character limit)

        //Index             Int32       False  (Represents the position of the Card in the Lane, 0 -first position, n+1 - last position) (Defaults to 0 if not specified)

        //DueDate           string      False  (dd/MM/yyyy or MM/dd/yyyy or yyyy/MM/dd  - This will be determined based on the user's date format that is used to make the API call)

        //ExternalSystemName string     False  The name of the link assigned to the Card. (255 character limit)

        //ExternalSystemUrl  string     False  The URL of the link to the external system

        //ClassOfServiceId  Int64(nullable) False The Identifier of the Class of Service assigned to the card. (The ID values can be obtained using the GetBoardIdentifiers method)

        public int Id   { get; set; }
        public string Title  { get; set; }
        public int TypeId { get; set; }
        public int Size { get; set; }
        public int LaneId { get; set; }
        public int AssignedUserId { get; set; }
        public bool IsBlocked { get; set; }
        public string UserWipOverrideComment { get; set; }
    }
}