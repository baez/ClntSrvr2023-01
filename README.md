# ClntSrvr2023-01

ClntSrvr2023-01 is a C# project dedicated to exploring the client-server paradigm through multiple communication protocols. This repository serves as a comprehensive guide to understanding and implementing different protocols, including HTTP, TCP/IP, and WebSockets, demonstrating how clients and servers interact in each context.

## Features

- **HTTP Communication**: Implements RESTful APIs to facilitate client-server interactions over the HTTP protocol.
- **TCP/IP Sockets**: Provides examples of low-level socket programming to establish reliable connections and data exchange.
- **WebSockets**: Demonstrates real-time, full-duplex communication between client and server using WebSockets.
- **Asynchronous Operations**: Utilizes asynchronous programming patterns to handle non-blocking I/O operations, enhancing performance and scalability.

## Project Structure

- `ConsoleApp1/`: A console application serving as a client or server in various protocol implementations.
- `DataModels/`: Defines data structures used for communication between clients and servers.
- `DocumentAPIClient/`: Contains client implementations that interact with document-based APIs.
- `DocumentClientConsole/`: A console-based client application for document services.
- `DocumentService/`: Implements server-side logic for handling document-related requests.
- `ExampleAPI/`: Provides example implementations of APIs using different protocols.
- `Interfaces/`: Declares interfaces to promote code modularity and testability.
- `Repositories/`: Implements data access layers following repository patterns.
- `TCPClient/`: Contains implementations of clients using the TCP/IP protocol.
- `TCPServer/`: Houses server-side code for handling TCP/IP client connections.
- `WebPageServerApp/`: A web server application serving HTML pages to clients.
- `WebServerApp/`: Implements a basic web server handling HTTP requests and responses.
- `.gitattributes` & `.gitignore`: Configuration files for Git version control.
- `ClntSrvr2023-01.sln`: Visual Studio solution file for managing the project.

## Getting Started

### Prerequisites

- .NET SDK installed
- Visual Studio or another compatible C# IDE
- Git (optional, for cloning the repository)

### Installation & Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/baez/ClntSrvr2023-01.git

### Open the solution file:

Navigate to the project directory and open ClntSrvr2023-01.sln in Visual Studio.

Restore dependencies and build the solution:

Use Visual Studio's build feature to restore NuGet packages and compile the project.

### Run the application:

Execute the desired client or server application using Visual Studio's debugging tools or CLI commands.

### Purpose and Learnings
This project was created to delve into:

Client-Server Architecture: Understanding the foundational principles of client-server interactions.
Protocol Implementation: Gaining hands-on experience with various communication protocols such as HTTP, TCP/IP, and WebSockets.
Asynchronous Programming: Applying asynchronous patterns to manage I/O operations efficiently.
Practical Networking: Building practical skills in network programming and troubleshooting.
License

### This project is licensed under the Apache License 2.0 – feel free to use and modify it.
