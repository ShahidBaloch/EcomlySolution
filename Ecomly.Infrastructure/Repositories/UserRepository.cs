using Dapper;
using Ecomly.Core.DTOs;
using Ecomly.Core.Entities;
using Ecomly.Core.RepositoryContracts;
using Ecomly.Infrastructure.DbContext;

namespace Ecomly.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        string query = "INSERT INTO public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\")  VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";
        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }

        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" Where \"Email\" =@Email AND \"Password\"= @Password";
        var paramters = new { Email = email, Password = password };
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, paramters);
        //return new ApplicationUser
        //{
        //    UserID = Guid.NewGuid(),
        //    Email = email,
        //    Password = password,
        //    PersonName = "Person Name",
        //    Gender = GenderOptions.Male.ToString(),
        //};
        return user;
    }
}
