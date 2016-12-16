# _Hair Salon_

#### _A Nancy web app utilizing ADO .NET to create an interface for a user to keep track of bands and venues_

#### By _**Chris Wingo**_

## Description

_This program will allow the user to enter in information about a venue. It will also allow the user to associate venues with bands and vice versa. The user can edit the details of the venues as well as delete individual venues._

## Specs

| Behavior - Plain English | Sample Input                                                                                                                                   | Sample Output                                                | Descriptive Sentence                                                                           |
|--------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------|------------------------------------------------------------------------------------------------|
| Saves a venue            | new Venue("Crystal Ballroom") CrystalBallroom.Save()                                                                                           | All Venues: Crystal Ballroom                                 | Creates one venue and checks to make sure it was added to the list of all venues               |
| Deletes a venue          | CrystalBallroom.Delete()                                                                                                                       | All Venues: {}                                               | Checks to see if the venue we just added is removed when deleted                               |
| Lists all venues         | new Venue("Crystal Ballroom") CrystalBallroom.Save() new Venue("Aladdin Theater") AladdinTheater.Save()                                        | All Venues: Crystal Ballroom, Aladdin Theater                | Makes sure that all bands are saved and recalled properly, not just the most recently created  |
| Updates a venue          | All Venues: Crystal Ballroom CrystalBallroom.Update("Wonder Ballroom")                                                                         | All Venues: Wonder Ballroom                                  | Ensures the user can update the venue's info                                                   |
| Saves a band             | new Band("Crystal Castles")CrystalCastles.Save()                                                                                               | All Bands: Crystal Castles                                   | Creates one band and checks to make sure it was added to the list of all bands                 |
| Lists all bands          | new Band("CrystalCastles") CrystalCastles.Save() new Band("M83") M83.Save()                                                                    | All Bands: Crystal Castles, M83                              | Makes sure that all venues are saved and recalled properly, not just the most recently created |
| Adds a band to a venue   | new Venue("Crystal Ballroom") CrystalBallroom.Save() new Band("CrystalCastles") CrystalCastles.Save() CrystalBallroom.Add("Crystal Castles")   | Bands that have played at Crystal Ballroom: Crystal Castles  | Makes sure bands are properly associated with a venue                                          |
| Adds a venue to a band   | new band("CrystalCastles") Crystal Castles.Save() new Venue("Crystal Ballroom")  CrystalBallroom.Save() CrystalCastles.Add("Crystal Ballroom") | Venues that Crystal Castles have played at: Crystal Ballroom | Makes sure venues are properly associated with a band                                          |

## Setup/Installation Requirements

### Must have current version of .Net and Mono installed

### SQL Database Set-Up Instructions

In SQLCMD:<br>
\>CREATE DATABASE band_tracker <br>
\>GO <br>
\>USE band_tracker <br>
\>GO <br>
\>CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255)); <br>
\>CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255)); <br>
\>CREATE TABLE bands_venues (id INT IDENTITY(1,1), band_id INT, venue_id INT); <br>
\>GO
\>QUIT

* Copy all files and folders to your desktop or {git clone} the project.
* Navigate to the folder in your Windows power shell and run {dnx test} at the command line to ensure all tests are passing and the database was set up correctly
* Run {dnx kestrel} to start the web server. Then, in your address bar, navigate to {//localhost:5004} to get to the home page_


## Known Bugs

_No known issues at this time_

## Support and contact details

_Please feel free to contact me with questions, comments, or contributions to improve the program at cmwingo@gmail.com_

### License

*https://creativecommons.org/licenses/by-nc/3.0/us/legalcode*

Copyright (c) 2016 **_Chris Wingo_**
