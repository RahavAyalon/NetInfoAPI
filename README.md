### Overview ###

NetInfoAPI  is a basic REST API that returns information about IP configuration of existing network interfaces in the system.

While this code is OS-agnostic, it can be run easily using Docker
- OS: Linux Ubuntu 18.04 / 20.04 (can use a docker or a cloud VM)
- Server infrastructure is written in C# and running under .NET Core 6 + ASP.NET
- A single GET endpoint to obtain the network interfaces configuration is enough, however the system can have multiple network interfaces and multiple IP addresses per single interface

### Getting Started

1. Get inside the project source code directory:
```bash
cd NetworkInfoAPI
```
2. Compile the code:
```bash
dotnet publish -c Release
```
3. Build the Docker image:
```bash
docker build -t networkinfoimage . 
```
4. Start a new container: 
```bash
docker run -d --rm -p 5000:5000 --name networkinfocontainer networkinfoimage
```
5. Send a request to the containerized API (for example, using Postman)
```
http://localhost:5000/network
```
### Future Improvements
1. Tests
