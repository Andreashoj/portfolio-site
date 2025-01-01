using backend.data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class UserService(AppDbContext dbContext)
{
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await dbContext.Users.FirstAsync(user => user.Email == email);

        if (user is null)
            throw new ArgumentNullException("Couldnt find user with email: $\"email\"");

        return user;
    }
}