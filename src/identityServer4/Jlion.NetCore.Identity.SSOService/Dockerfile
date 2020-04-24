#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/identityServer4/Jlion.NetCore.Identity.SSOService/Jlion.NetCore.Identity.SSOService.csproj", "src/identityServer4/Jlion.NetCore.Identity.SSOService/"]
RUN dotnet restore "src/identityServer4/Jlion.NetCore.Identity.SSOService/Jlion.NetCore.Identity.SSOService.csproj"
COPY . .
WORKDIR "/src/src/identityServer4/Jlion.NetCore.Identity.SSOService"
RUN dotnet build "Jlion.NetCore.Identity.SSOService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jlion.NetCore.Identity.SSOService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jlion.NetCore.Identity.SSOService.dll"]