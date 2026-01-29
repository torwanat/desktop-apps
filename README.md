# Desktop Applications Collection

A comprehensive collection of desktop and web applications built with C# (.NET), Python, and ASP.NET technologies. This repository contains various utility applications, learning projects, and practical tools for system management, file operations, and data handling.

## Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Applications](#applications)
  - [C# Desktop Applications](#c-desktop-applications)
  - [Python Desktop Applications](#python-desktop-applications)
  - [ASP.NET Web Applications](#aspnet-web-applications)
  - [Learning Projects](#learning-projects)
- [Getting Started](#getting-started)
- [Requirements](#requirements)
- [Contributing](#contributing)

## Overview

This collection showcases diverse application types ranging from simple utility tools to more complex systems with databases and networking features. Each application is self-contained and can be built and run independently.

## Project Structure

```
desktop-apps/
├── C# Applications/
│   ├── CheckIP/                 # Network information viewer
│   ├── Client/                  # TCP client with chat functionality
│   ├── Firma/                   # Company team management system
│   ├── KoloPunkt/               # Circle and point geometry calculator
│   ├── Port Scanner/            # Network port scanner utility
│   └── Zadania początkowe/      # Learning project - basic algorithms
├── Python Desktop Applications/
│   ├── AirQuality/              # Air quality monitoring app
│   ├── FileManager/             # File management utility
│   ├── Menu/                    # Sorting algorithms visualizer
│   ├── MysqlManager/            # MySQL database manager GUI
│   ├── TextEditor/              # Rich text editor
│   ├── TODO/                    # Task manager with SQLite
│   └── Wyswig/                  # WYSIWYG text editor
├── ASP.NET Web Applications/
│   ├── GuestBook/               # XML-based guest book
│   ├── MailForm/                # Email form handler
│   └── LibraryApp/              # Library management system
└── LibraryApp/sql/              # SQL database schema
```

## Applications

### C# Desktop Applications

#### CheckIP
**Network Information Viewer**

Displays comprehensive network configuration details including:
- Local hostname and IP addresses
- Active TCP/IP connections (client and server modes)
- Active UDP connections
- Network interface information
- Domain name resolution

**Technology**: C# Console Application  
**Location**: [CheckIP/](CheckIP/)

#### Client
**TCP Client Chat Application**

A Windows Presentation Foundation (WPF) client application that:
- Connects to TCP servers
- Enables real-time chat communication
- Displays received content in a web browser control
- Manages asynchronous network operations

**Technology**: C# WPF (Windows Presentation Foundation)  
**Location**: [Client/](Client/)

#### Firma
**Company Team Management System**

Object-oriented application for managing company organizational structure:
- Create and manage employee records (with personal and employment details)
- Support for different employee roles (Team Members, Team Leaders)
- Team organization and hierarchy
- Employee cloning and data manipulation

**Technology**: C# Console Application  
**Classes**: `Osoba`, `CzlonekZespolu`, `KierownikZespolu`, `Zespol`  
**Location**: [Firma/](Firma/)

#### KoloPunkt
**Circle and Point Geometry Calculator**

Educational geometry application demonstrating object-oriented programming:
- Point coordinate representation
- Circle creation with center and radius
- Calculate circle area and perimeter
- Geometric calculations and transformations

**Technology**: C# Console Application  
**Classes**: `point`, `Circle`  
**Location**: [KoloPunkt/](KoloPunkt/)

#### Port Scanner
**Network Port Scanner Utility**

WPF application for scanning open ports on network devices:
- Specify port range for scanning
- Multi-threaded scanning for performance
- Real-time display of results
- Connection status validation

**Technology**: C# WPF with Threading  
**Location**: [Port Scanner/](Port%20Scanner/)

#### Zadania początkowe
**Learning Project - Basic Algorithms**

Beginner-level programming exercises covering fundamental algorithms:
- Includes solutions for problems 1-11
- Basic mathematical calculations
- Algorithmic thinking exercises

**Technology**: C# Console Application  
**Location**: [Zadania początkowe/](Zadania%20początkowe/)

### Python Desktop Applications

#### AirQuality
**Air Quality Monitoring Application**

Real-time air quality monitoring for Polish cities using government API:
- Query air quality data from GIOS API (Polish National Institute of Environmental Protection)
- Display particulate matter (PM2.5, PM10) and chemical measurements
- City and station selection interface
- Tkinter-based GUI

**Technology**: Python with Tkinter  
**Dependencies**: `tkinter`, `requests`, `json`  
**Location**: [AirQuality/](AirQuality/)

#### FileManager
**File Management Utility**

Feature-rich file manager with modern Qt interface:
- Tree-based file system navigation
- Create folders and text files
- File operations: copy, move, delete, rename
- Text file viewing and editing
- Built-in text editor for file contents

**Technology**: Python with PySide6 (Qt)  
**Dependencies**: `PySide6`  
**Location**: [FileManager/](FileManager/)

#### Menu
**Sorting Algorithms Visualizer**

Educational application for visualizing sorting algorithms:
- Implement and demonstrate various sorting techniques
- Tkinter-based GUI with menu interface

**Technology**: Python with Tkinter  
**Location**: [Menu/](Menu/)

#### MysqlManager
**MySQL Database Manager GUI**

User-friendly tool for MySQL database administration:
- Login and connect to MySQL servers
- List existing databases
- Create new databases
- Remove databases
- Database selection and switching
- Tkinter-based interface with database utilities

**Technology**: Python with Tkinter and MySQL connector  
**Dependencies**: `tkinter`, `mysql-connector-python`  
**Location**: [MysqlManager/](MysqlManager/)

#### TextEditor
**Rich Text Editor**

Full-featured text editor with formatting support:
- File operations (create, open, save, close)
- Text formatting (bold, italic, underline)
- Font selection and customization
- Keyboard shortcuts for common operations
- Toolbar with action buttons

**Technology**: Python with PySide6 (Qt)  
**Dependencies**: `PySide6`  
**Location**: [TextEditor/](TextEditor/)

#### TODO
**Task Manager Application**

SQLite-based task management system:
- Create, edit, and delete tasks
- Set deadlines with date/time picker
- Mark tasks as completed
- Persistent storage with SQLite
- Auto-refresh functionality
- Task list with status tracking

**Technology**: Python with PySide6 and SQLite  
**Dependencies**: `PySide6`, `sqlite3`  
**Location**: [TODO/](TODO/)

#### Wyswig
**WYSIWYG Text Editor**

What-You-See-Is-What-You-Get text editor with formatting:
- Open and save text files
- Text formatting (bold, italic, underline)
- Tkinter-based GUI
- Simple and intuitive interface

**Technology**: Python with Tkinter  
**Location**: [Wyswig/](Wyswig/)

### ASP.NET Web Applications

#### GuestBook
**XML-Based Guest Book Application**

Classic web-based guest book system using XML and XSLT:
- Guest message submission form
- XML data storage
- XSLT transformation for presentation
- View all guest messages
- CSS styling for frontend

**Technology**: ASP.NET Web Forms, XML, XSLT  
**Files**: `GuestForm.aspx`, `View.aspx`, `book.xml`, `book.xslt`  
**Location**: [GuestBook/](GuestBook/)

#### MailForm
**Email Form Handler**

Web application for collecting and processing email submissions:
- Form-based email data collection
- ASP.NET Web Forms interface
- Email handling and processing

**Technology**: ASP.NET Web Forms  
**Location**: [MailForm/](MailForm/)

#### LibraryApp
**Library Management System**

Comprehensive web-based library management application:
- Manage book inventory
- Add/remove library items
- Database-backed persistence
- Connect to library database
- Book cataloging and search

**Technology**: ASP.NET Web Forms, SQL  
**Database**: SQL Server  
**Location**: [LibraryApp/](LibraryApp/)

## Getting Started

### Prerequisites

- **.NET Framework/Core** (for C# applications)
  - Visual Studio 2019+ or Visual Studio Code with C# extension
  - .NET Framework 4.5+ or .NET Core 3.1+

- **Python 3.7+** (for Python applications)
  - pip package manager

- **IIS or Visual Studio** (for ASP.NET web applications)

### Building and Running C# Applications

#### Using Visual Studio

1. Navigate to the application folder
2. Open the `.sln` (Solution) file in Visual Studio
3. Build the solution: `Build > Build Solution`
4. Run the application: `Debug > Start Debugging` or press `F5`

#### Using Command Line

```bash
cd CheckIP
dotnet build
dotnet run
```

### Running Python Applications

1. Install dependencies:
```bash
pip install -r requirements.txt
# or install individually
pip install PySide6
pip install requests
pip install mysql-connector-python
```

2. Run the application:
```bash
python main.py
```

Example:
```bash
cd TextEditor
pip install PySide6
python main.py
```

### Deploying ASP.NET Web Applications

1. Open the `.sln` file in Visual Studio
2. Right-click the project and select "Publish"
3. Choose deployment target (IIS, Azure, etc.)
4. Follow the publish wizard
5. Configure database connections in `Web.config`

## Requirements

### C# Applications
- .NET Framework 4.5+ or .NET 5+
- Visual Studio or Visual Studio Code
- Windows OS (for WPF applications)

### Python Applications
- Python 3.7 or higher
- Package managers: pip

### ASP.NET Web Applications
- .NET Framework 4.5+
- IIS (Internet Information Services) 7.5+
- SQL Server (for database-backed applications)

### Python Package Dependencies

Create a `requirements.txt` in project root with:

```
PySide6>=6.0.0
requests>=2.25.0
mysql-connector-python>=8.0.0
```

## Project Status

These applications represent various learning projects and utilities developed across different technology stacks. They demonstrate:
- Object-oriented programming principles
- GUI development with multiple frameworks
- Network programming and connectivity
- Database operations and management
- File system manipulation
- Web application development
