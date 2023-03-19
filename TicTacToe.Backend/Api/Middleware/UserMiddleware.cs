using Core.RegularExpressions;
using Infrastructure.Repository.Interfaces;

namespace Api.Middleware
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;

        public UserMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context, IUserRepository repository, AuthRegularExpressions regular)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = regular.ValidateToken(token);

            //Сохранение пользователя в хранилище для дальнейшего использования
            if (userId != null)
            {
                context.Items["User"] = await repository.GetUserByIdAsync(userId.Value);
            }

            await _next(context);
        }
    }
}
