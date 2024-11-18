# CommunityApp

**CommunityApp** is a WPF application using .NET 8, designed as a municipal community application. This version focuses on reporting and viewing issues, with two other core functionalities to be implemented in future updates. Currently, users can report issues and view them within the app.

## Functionality

- **On startup**, the user can select from the following tasks:
  - Report Issues
  - Local Events and Announcements
  - Service Requests

### Report Issues
- Upon selecting **Report Issues**, the user will be prompted to enter details about the issue:
  - **Location**
  - **Category**
  - **Description**
- The user will also be able to **attach a file** related to the issue.
- After reporting an issue, all reported issues will be displayed in a table for the user to view.

### Local Events and Announcements
- Upon selecting **Local Events and Announcements**, the user can:
  - List **all events**
  - Filter events by **category**
  - Filter events by **date**
  - Filter events by both **category and date**
  - **Search** for events by **name**
- Based on the user's **hardcoded interests** and **search history**, a **recommendations view** will be displayed.

### Service Requests
- Upon selecting **Service Requests**, the user can:
  - Click on the **Search** button to view all stored service requests.
  - Use the **combo box** to select a status (Pending, Ongoing, or Done) and click **Search** again to filter by the selected status.
  - While service requests are displayed, the user can change the status of a selected request:
    - Right-click on the desired service request.
    - Select **Update Status**.
    - Choose the appropriate status from the **combo box**.
    - Click **OK**.
- When the user searches for service requests again, the updated request status will be reflected accordingly.

## Installation

1. **Clone this repository**:
   ```bash
   git clone https://github.com/yourusername/communityapp.git
