##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["TimesheetLaikas.csproj", "./"]
#RUN dotnet restore "./TimesheetLaikas.csproj"
#COPY . .
#WORKDIR "/src/TimesheetLaikas"
#RUN dotnet test "./Timesheet.sln" --configuration Release --no-restore
#RUN dotnet build "TimesheetLaikas.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "TimesheetLaikas.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "TimesheetLaikas.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
COPY ["TimesheetLaikas.csproj", "./"]
WORKDIR ./TimeSheetLaikas
RUN dotnet restore

COPY TimesheetLaikas/. ./
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime
ENV ASPNETCORE_URLS https://+:80/
WORKDIR /app
COPY --from=build /app/TimesheetLaikas/out ./
ENTRYPOINT ["dotnet", "TimesheetLaikas.dll"]
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build

WORKDIR /src
COPY ["TimesheetLaikas/TimesheetLaikas.csproj", "./"]
COPY Setup.sh Setup.sh

RUN dotnet tool install --global dotnet-ef --version 2.1.14

RUN dotnet restore "TimesheetLaikas.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add DeploymentMigration

RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh