FROM ubuntu:20.04

WORKDIR /app

COPY bin/Release/net6.0/publish /app

RUN apt-get update && \
    apt-get install -y wget apt-transport-https && \
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb

RUN apt-get update && \
    apt-get install -y dotnet-sdk-6.0

RUN apt-get clean && \
    rm -rf /var/lib/apt/lists/*

ENTRYPOINT [ "dotnet", "NetworkInfoAPI.dll" ]
