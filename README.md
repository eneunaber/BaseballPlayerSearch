
# BaseballPlayerSearch
A simple application displaying baseball statistics and uses a feature flag provided by LaunchDarkly to pivot between simple and enhanced statistics

## Prerequisites

### .NET 6.0 SDK
The .Net 6.0 SDK is needed to run this project. To begin, navigate to this link: https://dotnet.microsoft.com/en-us/download. Run the installation for your appropriate environment. 

### LaunchDarkly
The application uses feature flags provided by LaunchDarkly. A LaunchDarkly account and subsequent feature flag must be created for this application. To begin navigate to this link: https://app.launchdarkly.com/signup and create a free LaunchDarkly trial account.

**LaunchDarkly Setup**

Feature Flag:
Navigate to LaunchDarkly admin screen and go to the *FeatureFlags* section.

Locate and press the *Create flag* button.
In the form enter the following values:

- Name: EnhancedStatistics
- Key: EnhancedStatistics

The remaining fields can be left with default or empty values.

Locate and press the *Save flag* button.

Project:
*If a LaunchDarkly Project does not already exist create one for this application*

Navigate to LaunchDarkly admin screen and go to the *Account settings* section.

Locate and click the *Projects* tab.

Locate and press the *Create project* button.
In the form enter the following values:

- Name: BaseballPlayerSearch
- Key: baseball-player-sear
	- *note: Key is limited to 20 characters and is truncated*

Locate and press the *Create Project* button.

Take note of the screen that appears afterwards. A project defaults to creating two environments (Test and Production). For this application, choose an *Environment* to work with. Locate the *SDK Key* for the chosen Environment. This key will be used later in the application.

### Git SCM or Ability to unzip a file
For this demo the project must either be cloned or downloaded and extracted via the GitHub UI to your computer.


## Running the application
### Insert SDK Key into Codebase
After the project is installed on your machine the first step is to insert the SDK key for the targeted LaunchDarkly project and environment. 

With text editor of your choice open the file LaunchDarklyService.cs. The file is located under the following folder structure:
{Project Root} > Services {folder} > LaunchDarklyService.cs

Find and replace the value **Change-me** with the *SDK Key* for the desired project and environment.

Save changes to the file.

### Build & Run the application
After the *SDK Key* has been inserted it is time to build and run the application

Launch a terminal and navigate to the root of the Project folder. 

Run the following command:  
```  
dotnet build 
``` 
In the output you should see:
`0 Error(s)`


Then run the following command:  
```  
dotnet run
``` 
In the output you should see multiple lines. One line should contain:
`Now listening on : https://localhost:7057`

## Testing the application
Using the browser of your choice, go to: https://localhost:7057

### First time run
The *EnhancedStatistics* Feature Flag created in the LaunchDarkly setup step should be turned off and the application should display the "standard" baseball statistics.

The menu at the top of the application has two options

- Batter Statistics
- Pitcher Statistics

Browse each page and observe the data that is displayed on the page.

### Enable Feature Flag
Navigate to LaunchDarkly admin screen and go to the *FeatureFlags* section.

Toggle the *EnhancedStatistics* flag from *Off* to *On*. Confirm by pressing *Save changes* button. (Note: *Make sure you are in the correct Environment*)

Go back to your browser, refresh the page, and again browse each page. Observe the data that is displayed on the page is showing more columns of data for each type than before. These new columns represent the "Enhanced" baseball statistics.

### Continued Testing
At this time you can continue to turn the feature flag off and on to test the application as described above.
