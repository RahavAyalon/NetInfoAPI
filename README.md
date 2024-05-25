### Overview ###

NetInfoAPI  is a basic C# REST API that returns information about IP configuration of existing network interfaces in a system, running under .NET Core 6 + ASP.NETsing using Docker.

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
