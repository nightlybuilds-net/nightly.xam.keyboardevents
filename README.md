
# Welcome to nightly.xam.keyboardevents

This project is developed for Xamarin Forms (iOS and Android) and exposes 2 events related to the keyboard:

    public interface ICrossKeyboard    
    {    
	    event EventHandler OnKeyboardShow;
	    event EventHandler OnKeyboardHide;    
    }

## Usage ##

You can subscribe to the two events simply like this:
     

    CrossKeyboard.Instance.Value.OnKeyboardShow += (sender, args) =>
        {   
		    Console.WriteLine("OPEN");    
	    };
    
    CrossKeyboard.Instance.Value.OnKeyboardHide += (sender, args) =>    
	    {
		    Console.WriteLine("CLOSED");    
	    };   

Please just remember this Android initialization in you MainActivity.cs file:

    CrossKeyboard.Activity  =  this;

## Packages ##


Package name                              | Nuget      | 
-----------------------|-------------------------------------------|-----------------------------|------------------------
`nightly.xam.keyboardevents` | [![Nuget](https://img.shields.io/nuget/v/nightly.xam.keyboardevents)](https://www.nuget.org/packages/Xam.Zero.Sem/) | [![Build Status](https://dev.azure.com/nightlybuilds-net/Xam.Zero/_apis/build/status/markjackmilian.Xam.Zero?branchName=master)](https://dev.azure.com/nightlybuilds-net/Xam.Zero/_build/latest?definitionId=11&branchName=master)|

All packages are compliant with [Semantic Versioning](https://semver.org/)
