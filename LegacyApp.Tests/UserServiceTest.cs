using System;
using JetBrains.Annotations;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{    [Fact]
     public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
     {
         
         // Arrange
         var userService = new UserService();
 
         // Act
         var result = userService.AddUser(
             null, 
             "Kowalski", 
             "kowalski@kowalski.pl",
             DateTime.Parse("2000-01-01"),
             1
             );
 
         // Assert
         // Assert.Equal(false, result);
         Assert.False(result);
     }
     
     [Fact]
     public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
     {
         
         var userService = new UserService();
 
         var result = userService.AddUser(
             "Jan", 
             "Kowalski", 
             "kowalskikowalskipl",
             DateTime.Parse("2000-01-01"),
             1
             );
 
         Assert.False(result);
     }
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThan21YearsOld()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2010-01-01"),
            1
        );

        Assert.False(result);
    }
    
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2000-01-01"),
            2 
        );

        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2000-01-01"),
            3 
        );

        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2000-01-01"),
            5
        );

        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();

        var result = userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2000-01-01"),
           1 
        );

        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        var userService = new UserService();

        Action action = () => userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2000-01-01"),
            -1
        );

        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();

        Action action = () => userService.AddUser(
            "John",
            "Doe",
            "john.doe@example.com",
             DateTime.Parse("2000-01-01"),
            -1
        );

        Assert.Throws<ArgumentException>(action);
    }
     
     [Fact]
     public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
     {
         
         var userService = new UserService();
 
         Action action = () => userService.AddUser(
             "Jan", 
             "Kowalski", 
             "kowalski@kowalski.pl",
             DateTime.Parse("2000-01-01"),
             100
         );
 
         // Assert
         Assert.Throws<ArgumentException>(action);
     }
}