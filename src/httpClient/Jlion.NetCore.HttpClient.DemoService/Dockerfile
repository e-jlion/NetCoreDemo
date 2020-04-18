#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/httpClient/Jlion.NetCore.HttpClient.DemoService/Jlion.NetCore.HttpClient.DemoService.csproj", "src/httpClient/Jlion.NetCore.HttpClient.DemoService/"]
RUN dotnet restore "src/httpClient/Jlion.NetCore.HttpClient.DemoService/Jlion.NetCore.HttpClient.DemoService.csproj"
COPY . .
WORKDIR "/src/src/httpClient/Jlion.NetCore.HttpClient.DemoService"
RUN dotnet build "Jlion.NetCore.HttpClient.DemoService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jlion.NetCore.HttpClient.DemoService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jlion.NetCore.HttpClient.DemoService.dll"]