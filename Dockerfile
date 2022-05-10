#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PlatTraining/PlatTraining.csproj", "src/PlatTraining/"]
COPY ["src/PlatTraining.Services/PlatTraining.Services.csproj", "src/PlatTraining.Services/"]
COPY ["src/PlatTraining.Dal/PlatTraining.Dal.csproj", "src/PlatTraining.Dal/"]
RUN dotnet restore "src/PlatTraining/PlatTraining.csproj"
COPY . .
WORKDIR "/src/src/PlatTraining"
RUN dotnet build "PlatTraining.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlatTraining.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatTraining.dll"]