# Municipality Application

## Description
The South African Municipality Application is a WPF-based project developed as part of the PROG7312 module. It helps users report issues, view local events and announcements, and track service request statuses through an interactive and user-friendly interface.

---

## Part 1: Report Issues
### Features
- **MainMenu**: 
  - Three buttons: 
    - "Report Issues" (functional).
    - "Local Events and Announcements" (disabled).
    - "Service Request Status" (disabled).
- **Report Issues Page**:
  - Users can report an issue by providing:
    - Location.
    - Category.
    - Description.
    - Image or document attachment.
  - Displays the number of reports submitted.
  - Includes **progress bar** and **encouraging messages** to enhance user engagement.
  - Users can navigate back to the Main Menu or view submitted reports.
- **List of Submitted Reports**:
  - Displays reports in a data grid format (location, category, description, and attachments).
  - Navigation back to the Report Issues page.

---

## Part 2: Local Events and Announcements
### Features
- **LocalEvents Page**:
  - Displays a scrollable list of events and announcements.
  - Search functionality:
    - Search by category or substring of the category.
    - Search by date.
  - Unique categories displayed in a list box.
  - "Top 5 Searches" to analyze user search patterns.
  - Recommended events displayed based on search frequency.
  - Navigation back to the Main Menu.

---

## Part 3: Service Request Status
### Features
- **ServiceRequestStatus Page**:
  - Displays all service requests in a scrollable format.
  - Search by UUID or partial UUID.
  - Filter service requests by status ("Pending", "In Progress", "Completed").
  - View service requests by priority:
    - Lowest numerical value indicates the highest priority.
  - Retrieve the most urgent service request using the "Get Urgent" button.
  - View related service requests (by location).
  - Reset the view to show all service requests.

---

## Setting Up the Project

### Prerequisites
1. **Visual Studio**:
   - Ensure you have Visual Studio 2019 or later installed with the ".NET Desktop Development" workload.
2. **Git**:
   - Install Git from [Git's official website](https://git-scm.com/) if not already installed.
3. **NuGet Packages**:
   - Ensure NuGet Package Manager is enabled in Visual Studio.

---

### Steps to Set Up

#### Clone the Repository
1. Open a terminal or command prompt.
2. Run the following command:
   git clone https://github.com/ST10082679/Nilay_ST10082679_PROG7312_WPF_FINAL_POE.git


#### Open the Project in Visual Studio
1. Navigate to the cloned folder.
2. Locate the solution file (*.sln).
3. Double-click the .sln file to open it in Visual Studio.

#### Install Required Packages
1. Open the Package Manager Console in Visual Studio:
   - Tools → NuGet Package Manager → Package Manager Console.
2. Run the following command to restore all NuGet packages: Update-Package -reinstall
3. Alternatively, restore NuGet packages by right-clicking the solution in the Solution Explorer and selecting Restore NuGet Packages.

#### Build the Project
1. In Visual Studio, press Ctrl + Shift + B or go to Build → Build Solution.
2. Ensure there are no errors during the build process.

#### Run the Application