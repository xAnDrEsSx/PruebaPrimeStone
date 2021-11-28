namespace Test.CoreApi.Model
{
    public class ResponseMessages
    {
        public int Code200 { get; set; } = 200;
        public int Code400 { get; set; } = 400;
        public string MessageOk { get; set; } = " Ok.";
        public string MessageFail { get; set; } = " Fail.";
        public string MessageNotFound { get; set; } = " Not Found.";
    }
}
