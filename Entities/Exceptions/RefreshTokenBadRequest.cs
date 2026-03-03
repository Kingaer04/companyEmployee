namespace Entities.Exceptions
{
    public class RefreshTokenBadRequest : BadRequestException
    {
        public RefreshTokenBadRequest()
            : base("Invalid client Request. The tokenDto has some invalid values") 
        {
        }
    }
}
