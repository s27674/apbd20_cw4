namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameISEmpty()
    {
        //Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        //Assert
        //Assert.Equal(false, result);
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        //Arrange
        var userService = new UserService();

        //Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            100
        );

        //Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDontInEmail()
    {
        //Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskikowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        //Assert
        Assert.False(result);
    }    
   
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //Arrange
        var userService = new UserService();

        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2005-01-01"),
            1
        );

        //Assert
        Assert.False(result);
    }
    
    // AddUser_ReturnsTrueWhenVeryImportantClient
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Malewski",
            "malewski@gmail.pl",
            DateTime.Parse("2000-01-01"),
            2
        );
        
        //Assert
        Assert.True(result);
    }
    
    // AddUser_ReturnsTrueWhenImportantClient
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Smith",
            "smith@gmail.pl",
            DateTime.Parse("2000-01-01"),
            3
        );
        
        //Assert
        Assert.True(result);
    } 
    
    // AddUser_ReturnsTrueWhenNormalClient
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //Arrange

        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kwiatkowski",
            "kwiatkowski@wp.pl",
            DateTime.Parse("2000-01-01"),
            5
        );
        //Assert
        
        Assert.True(result);
    }
    
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@wp.pl",
            DateTime.Parse("2000-01-01"),
            6);
        
        //Assert
        Assert.False(result);
    } 
    
    // AddUser_ThrowsExceptionWhenUserDoesNotExist
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            100);
        
        //Assert
        Assert.Throws<ArgumentException>(action);
    } 
    
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();

        //Act

        Action action = () => userService.AddUser(
            "Jan",
            "Andrzejewicz",
            "andrzejewicz@wp.pl",
            DateTime.Parse("2000-01-01"),
            6
        );
    
        //Assert
    
        Assert.Throws<ArgumentException>(action);
    } 
}