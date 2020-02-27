FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ProjectBackend/ProjectBackend.csproj", "ProjectBackend/"]
RUN dotnet restore "ProjectBackend/ProjectBackend.csproj"
COPY . .
WORKDIR "/src/ProjectBackend"
RUN dotnet build "ProjectBackend.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProjectBackend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjectBackend.dll"]