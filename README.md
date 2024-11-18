# CommunityApp
This is a WPF applicattion using .net 8 designed as a municpal community application.
as of right now, this is only part of the application as there are two other core functionalities to be implemented.
this version will allow user to report issues and view them.

## Functionalitiy
- On startup, the user can select report issues task, Local Events and Announcements or Service requests
- upon selecting the report issues task, the user will be promted for details about the issue
    -Location
    -Category
    -Desciption
- The user will also be able to attach a file related to the issue
- After reporting an issue, all reported issue can be viewed in a table
- upon selecting Local Events and Announcements, the user will be able to:
  - list all events
  - filter by only category
  - filter by only date
  - filter by both category and date
  - search by name
- based on the  users hardcoded interests and the users search history - a recommendations view will be displayed
-  Upon selecting Service requests, the user will be can click on the search button for all stored service requests to be shown
-  the user can also click on the combo box to select a status (pending, ongoing or done) and then the search button again for the service requests with the selected status to be displayed
-  While there are service requests displayed on the screen, the user can change the status of the selected request
  - right click on the desired service request
  - click on update status
  - choose the appropriate status from the combo box
  - click ok
- when the user searches for service requests again, the updatee request will be displayed accordinly

## Installation
1. **clone this repository**
2. Open the solution
3. Run the project



