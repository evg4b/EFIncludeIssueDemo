# EFIncludeIssueDemo

The example shows issues of loading data into EF through `.Include`. In case when navigation property was initialized in constructor EF 3.0 or higher cannot be loaded it correctly.

## Example: 

This query cannot load `User`

``` CS 
var profiles = await context.Profile
    .Include(p => p.User)
    .ToArrayAsync();
```

For following models:

```CS 
public class User
{
    public User()
    {
        // This is incorrect
        Profile = new Profile();
    }

    public int Id { get; set; }
    public string Email { get; set; }
    
    public Profile Profile { get; set; }
}

public class Profile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public User User { get; set; }
}
```

For more information see files in folder `Case` in 
- **[DemoConsoleApp5](https://github.com/evg4b/EFIncludeIssueDemo/tree/master/DemoConsoleApp5)** - For dotnet 5.0 RC
- **[DemoConsoleApp31](https://github.com/evg4b/EFIncludeIssueDemo/tree/master/DemoConsoleApp31)** - For dotnet 3.1
- **[DemoConsoleApp21](https://github.com/evg4b/EFIncludeIssueDemo/tree/master/DemoConsoleApp21)** - Example of completely correct behavior on dotnet 2.1

**Don't forget set the correct connection strings in `appsettings.json`**
