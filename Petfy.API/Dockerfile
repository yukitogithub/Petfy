#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Petfy.UI.WebAPI/Petfy.UI.WebAPI.csproj", "Petfy.UI.WebAPI/"]
COPY ["Petfy.Domain/Petfy.Domain.csproj", "Petfy.Domain/"]
COPY ["Petfy.Data/Petfy.Data.csproj", "Petfy.Data/"]
RUN dotnet restore "Petfy.UI.WebAPI/Petfy.UI.WebAPI.csproj"
COPY . .
WORKDIR "/src/Petfy.UI.WebAPI"
RUN dotnet build "Petfy.UI.WebAPI.csproj" -c Debug -r linux-x64 --self-contained true -o /app/build

FROM build AS publish
RUN dotnet publish "Petfy.UI.WebAPI.csproj" -c Debug -r linux-x64 --self-contained true -o /app/publish

FROM base AS final
WORKDIR /app
#ENV ASPNETCORE_URLS=http://*:5000
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Petfy.UI.WebAPI.dll
ENTRYPOINT ["dotnet", "Petfy.UI.WebAPI.dll"]