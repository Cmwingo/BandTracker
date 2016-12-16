using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_BandsEmptyAtFirst()
    {
      //Arrange, Act
      int result = Band.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Band firstBand = new Band("Name");
      Band secondBand = new Band("Name");

      //Assert
      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
    public void Test_Save_SavesBandToDatabase()
    {
      //Arrange
      Band testBand = new Band("Name");
      testBand.Save();

      //Act
      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToBandObject()
    {
      //Arrange
      Band testBand = new Band("Name");
      testBand.Save();

      //Act
      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int testId = testBand.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsBandInDatabase()
    {
      //Arrange
      Band testBand = new Band("Name");
      testBand.Save();

      //Act
      Band foundBand = Band.Find(testBand.GetId());

      //Assert
      Assert.Equal(testBand, foundBand);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }
    [Fact]
    public void Test_Delete_DeletesBandFromDatabase()
    {
      //Arrange
      string name1 = "Name";
      Band testBand1 = new Band(name1);
      testBand1.Save();

      string name2 = "Other name";
      Band testBand2 = new Band(name2);
      testBand2.Save();

      //Act
      testBand1.Delete();
      List<Band> resultBands = Band.GetAll();
      List<Band> testBandList = new List<Band> {testBand2};

      //Assert
      Assert.Equal(testBandList, resultBands);
    }
    [Fact]
    public void Test_AddVenue_AddsVenueToBand()
    {
     //Arrange
      Band testBand = new Band("Name");
      testBand.Save();

      Venue testVenue = new Venue("Object name");
      testVenue.Save();

      Venue testVenue2 = new Venue("Other object name");
      testVenue2.Save();

     //Act
      testBand.AddVenue(testVenue);
      testBand.AddVenue(testVenue2);

      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue>{testVenue, testVenue2};

     //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_GetVenues_ReturnsAllBandVenues()
    {
      //Arrange
      Band testBand = new Band("Name");
      testBand.Save();

      Venue testVenue1 = new Venue("Object name");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Other object name");
      testVenue2.Save();

      //Act
      testBand.AddVenue(testVenue1);
      List<Venue> savedVenues = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue1};

      //Assert
      Assert.Equal(testList, savedVenues);
    }
    [Fact]
    public void Test_Delete_DeletesBandAssociationsFromDatabase()
    {
      //Arrange
      Venue testVenue = new Venue("Object name");
      testVenue.Save();

      string testName = "Name";
      Band testBand = new Band(testName);
      testBand.Save();

      //Act
      testBand.AddVenue(testVenue);
      testBand.Delete();

      List<Band> resultVenueBands = testVenue.GetBands();
      List<Band> testVenueBands = new List<Band> {};

      //Assert
      Assert.Equal(testVenueBands, resultVenueBands);
    }
  }
}
