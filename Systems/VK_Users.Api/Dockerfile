#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/VK_Users.Api/VK_Users.Api.csproj", "Systems/VK_Users.Api/"]
COPY ["Data/VK_Users.Context/VK_Users.Context.csproj", "Data/VK_Users.Context/"]
COPY ["Shared/VK_Users.Settings/VK_Users.Settings.csproj", "Shared/VK_Users.Settings/"]
COPY ["Data/VK_Users.Context.Migrations/VK_Users.Context.Migrations.csproj", "Data/VK_Users.Context.Migrations/"]
RUN dotnet restore "Systems/VK_Users.Api/VK_Users.Api.csproj"
COPY . .
WORKDIR "/src/Systems/VK_Users.Api"
RUN dotnet build "VK_Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VK_Users.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VK_Users.Api.dll"]