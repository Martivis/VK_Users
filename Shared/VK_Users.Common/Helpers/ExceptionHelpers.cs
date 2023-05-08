namespace VK_Users.Common;

public static class ExceptionHelpers
{
    public static ErrorResponse ToErrorResponse(this ApplicationException data)
    {
        var res = new ErrorResponse()
        {
            ErrorCode = 400,
            Message = data.Message
        };

        return res;
    }
}