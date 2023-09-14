FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KheftProject/KheftProject.csproj", "KheftProject/"]
RUN dotnet restore "KheftProject/KheftProject.csproj"
COPY . .
WORKDIR "/src/KheftProject"
RUN dotnet build "KheftProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KheftProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KheftProject.dll"]
