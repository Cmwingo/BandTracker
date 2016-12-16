using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_EmptyAtFirst()
    {
      //Arrange, Act
      int result = Venue.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_EqualOverrideTrueForSameName()
    {
      //Arrange, Act
      Venue firstVenue = new Venue("Name");
      Venue secondVenue = new Venue("Name");

      //Assert
      Assert.Equal(firstVenue, secondVenue);
    }

    [Fact]
    public void Test_Save()
    {
      //Arrange
      Venue testVenue = new Venue("Name");
      testVenue.Save();

      //Act
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_SaveAssignsIdToObject()
    {
      //Arrange
      Venue testVenue = new Venue("Name");
      testVenue.Save();

      //Act
      Venue savedVenue = Venue.GetAll()[0];

      Console.WriteLine(testVenue.GetName());
      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_FindFindsVenueInDatabase()
    {
      //Arrange
      Venue testVenue = new Venue("Name");
      testVenue.Save();

      //Act
      Venue result = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, result);
    }
    [Fact]
    public void Test_AddBand_AddsBandToVenue()
    {
      //Arrange
      Venue testVenue = new Venue("Name");
      testVenue.Save();

      Band testBand = new Band("Other object name");
      testBand.Save();

      //Act
      testVenue.AddBand(testBand);

      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band>{testBand};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_GetBands_ReturnsAllVenueBands()
    {
      //Arrange
      Venue testVenue = new Venue("Name");
      testVenue.Save();

      Band testBand1 = new Band("Other object name");
      testBand1.Save();

      Band testBand2 = new Band("Another object name");
      testBand2.Save();

      //Act
      testVenue.AddBand(testBand1);
      List<Band> result = testVenue.GetBands();
      List<Band> testList = new List<Band> {testBand1};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Delete_DeletesVenueAssociationsFromDatabase()
    {
      //Arrange
      Band testBand = new Band("Other object name");
      testBand.Save();

      string testName = "Name";
      Venue testVenue = new Venue(testName);
      testVenue.Save();

      //Act
      testVenue.AddBand(testBand);
      testVenue.Delete();

      List<Venue> resultBandVenues = testBand.GetVenues();
      List<Venue> testBandVenues = new List<Venue> {};

      //Assert
      Assert.Equal(testBandVenues, resultBandVenues);
    }


    [Fact]
    public void Test_Update_UpdatesInDb()
    {
      Venue testVenue = new Venue("Name");
      testVenue.Save();
      testVenue.Update("Other name");

      Venue newVenue = new Venue("Other name", testVenue.GetId());

      Assert.Equal(testVenue, newVenue);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
  }
}
