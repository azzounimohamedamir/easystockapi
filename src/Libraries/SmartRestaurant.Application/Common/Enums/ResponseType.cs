namespace SmartRestaurant.Application.Common.Enums
{
    public enum ResponseType
    {
        OK = 200,
        Created = 201,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        MethodNotAllowed = 405,
        PreconditionFailed = 412,
        InternalServerError = 500,
    }
}
