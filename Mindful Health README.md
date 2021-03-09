# Mindful Health
## Mike Davidson, Ashley Petty, Sam Mourfield, Joshua  Wright

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Mindful Health is a C# WebAPI built to provide a back-end capable of registering and tracking new users, receiving information from those users, and providing a comprehensive lifestyle plan that will assist users in taking steps toward healthier diet- and fitness-related habits.

## Features

- Build and track profiles for new users containing key information on a user's lifestyle goals, metabolic needs, and current diet and fitness restrictions
- Provide users with regularly evolved goals and plans, which will provide users will important steps and milestones on their way to improving their overall lifestyle
- Adjust and track users' progress within the database

## Tech

Mindful Health was built using:

- [Visual Studio Community][vsc] - an integrated development environment (IDE) from Microsoft
- [Dillinger][dill] - HTML--->Markdown converter; open source with a [public repository][dill]
- [Github][github] - collaboration and version control website used to build this app
- [Postman][postman] - API testing software used to simulate front-end and test endpoints

Source code: [Mindful Health][repo]

## Installation

Mindful Health requires:
- [EntityFramework][ef] - Microsoft's recommended data access tech for new WebAPIs/apps [source linked]
- [jQuery][j] - JavaScript Library
- [Microsoft.AspNet.WebAPI packages][asp] - "an open-source, server-side web-application framework designed for web development to produce dynamic web pages" [source linked]
- [Microsoft.Owin][owin] - "Community-owned open-source project that is a standard for an interface between .NET Web applications and Web servers" [source linked]


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [repo]: <https://github.com/joshuawright89/Blue_Badge_Project>
   [postman]: <https://www.postman.com/>
   [github]: <https://github.com/>
   [dill]: <https://dillinger.io/>
   [vsc]: <https://www.microsoft.com/en-us/resilience/remote-development-solutions?ef_id=01302fc58d8a1164b8794f8341d417ed:G:s&OCID=AID2100424_SEM_01302fc58d8a1164b8794f8341d417ed:G:s&msclkid=01302fc58d8a1164b8794f8341d417ed>
   [ef]: <https://docs.microsoft.com/en-us/aspnet/entity-framework#:~:text=Entity%20Framework.%20Entity%20Framework%20(EF)%20is%20an%20object-relational,to%20work%20with%20relational%20data%20using%20domain-specific%20objects.>
   [asp]: <https://docs.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity>
   [owin]: <https://docs.microsoft.com/en-us/aspnet/core/fundamentals/owin?view=aspnetcore-5.0>
   [j]: <https://jquery.com/>